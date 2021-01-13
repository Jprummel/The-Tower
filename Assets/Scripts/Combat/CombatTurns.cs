using System.Collections;
using UnityEngine;

public class CombatTurns : MonoBehaviour {

    public enum Characters
    {
        PLAYER,
        OPPONENT
    }

    public delegate void ActionComplete();
    public static ActionComplete s_OnActionCompleted;

    public static CombatTurns s_Instance;

    public Characters CurrentCharacterTurn;
    public Character ActiveCharacter;
    public Character IdleCharacter;
    public Opponent Opponent;
    bool m_BattleIsOngoing;

    private void Awake()
    {
        Init();

        SetTurn(Characters.PLAYER);

        s_OnActionCompleted += SwitchTurn;
        m_BattleIsOngoing = true;
    }

    private void Start()
    {
        ActiveCharacter = PlayerData.s_Instance;
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        IdleCharacter = Opponent;
        if (TalentManager.s_Instance.HasAbility("Berserk"))
            ActiveCharacter.DamageAmplifier += 0.1f;

        ActiveCharacter.CanAttack = true;
        ActiveCharacter.CanMove = true;
    }

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetTurn(Characters character)
    {
        CurrentCharacterTurn = character;
    }

    public void SwitchTurn()
    {
        if (m_BattleIsOngoing)
        {
            if (CurrentCharacterTurn == Characters.PLAYER)
            {
                //Start opponent turn
                SetTurn(Characters.OPPONENT);
                ActiveCharacter = Opponent;
                StartCoroutine(TriggerDebuffs(ActiveCharacter, false));
                StartCoroutine(TriggerEndOfTurnDebuffs(PlayerData.s_Instance, true));

            }
            else
            {
                //Start player turn
                SetTurn(Characters.PLAYER);
                StartCoroutine(TriggerDebuffs(PlayerData.s_Instance, true));
                StartCoroutine(TriggerEndOfTurnDebuffs(Opponent, false));
            }
        }
    }

    IEnumerator WaitToTrigger(Character character)
    {
        int amountOfBuffs = character.ActiveDebuffs.Count;
        float waitTime = 0.5f * amountOfBuffs;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(TriggerEndOfTurnDebuffs(IdleCharacter, false));
    }

    void PlayerStun()
    {
        ActionBar.s_Instance.ToggleAllActions(false);
        CombatActions.SkipTurn();
    }

    IEnumerator TriggerLateDebuffs(Character character, bool player)
    {
        for (int i = 0; i < character.ActiveDebuffs.Count; i++)
        {
            if (character.ActiveDebuffs[i].LateTrigger)
            {
                if (character.ActiveDebuffs[i].TimesToTrigger > 0)
                {
                    if (character.ActiveDebuffs[i].EffectTime > 0)
                    {
                        character.ActiveDebuffs[i].DebuffEffect();
                        character.ActiveDebuffs[i].TimesToTrigger--;
                    }
                }
                if (character.ActiveDebuffs[i].EffectTime > 0)
                {
                    character.ActiveDebuffs[i].EffectTime--;
                    ManageStatusEffectUI.s_Instance.ReduceStatusEffectDurations(character.ActiveDebuffs[i].DebuffName, player);

                    if (character.ActiveDebuffs[i].EffectTime == 0)
                    {
                        ManageStatusEffectUI.s_Instance.RemoveStatusEffect(character.ActiveDebuffs[i].DebuffName, player);
                        character.ActiveDebuffs[i].RemoveEffect();
                        character.ActiveDebuffs.Remove(character.ActiveDebuffs[i]);
                        if (character.ActiveDebuffs.Count > 0)
                            i--;
                    }
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    IEnumerator TriggerDebuffs(Character character, bool player)
    {

        for (int i = 0; i < character.ActiveDebuffs.Count; i++)
        {
            if(!character.ActiveDebuffs[i].LateTrigger && !character.ActiveDebuffs[i].EndTurn)
            {
                if (character.ActiveDebuffs[i].TimesToTrigger > 0)
                {
                    if (character.ActiveDebuffs[i].EffectTime > 0)
                    {
                        character.ActiveDebuffs[i].DebuffEffect();
                        character.ActiveDebuffs[i].TimesToTrigger--;
                    }
                }
                if (character.ActiveDebuffs[i].EffectTime > 0)
                {
                    character.ActiveDebuffs[i].EffectTime--;
                    ManageStatusEffectUI.s_Instance.ReduceStatusEffectDurations(character.ActiveDebuffs[i].DebuffName, player);

                    if(character.ActiveDebuffs[i].EffectTime == 0)
                    {
                        ManageStatusEffectUI.s_Instance.RemoveStatusEffect(character.ActiveDebuffs[i].DebuffName, player);
                    }
                }
                else
                {
                    ManageStatusEffectUI.s_Instance.RemoveStatusEffect(character.ActiveDebuffs[i].DebuffName, player);
                    character.ActiveDebuffs[i].RemoveEffect();
                    character.ActiveDebuffs.Remove(character.ActiveDebuffs[i]);
                    if (character.ActiveDebuffs.Count > 0)
                        i--;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
        StartCoroutine(TriggerLateDebuffs(IdleCharacter, player));

        if(!player){
            IdleCharacter = PlayerData.s_Instance;
            yield return new WaitForSeconds(0.45f);
            OpponentCombatAI.s_OnOpponentTurn();
            OpponentCombatAI.s_ReduceCooldowns();
        }
        else{
            IdleCharacter = Opponent;
            ActiveCharacter = PlayerData.s_Instance;
            PlayerAbilityManager.s_Instance.ReducePlayerCooldowns();
            if (!ActiveCharacter.CanAttack && !ActiveCharacter.CanMove)
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " is stunned!", 1f, "Stun");
                PlayerStun();
            }
            else if (ActiveCharacter.Disabled)
            {
                ActionBar.s_Instance.DisableAbilities();
                ActionBar.s_Instance.ToggleAllActions(true);
            }
            else
                ActionBar.s_Instance.ToggleAllActions(true);
        }
    }

    IEnumerator TriggerEndOfTurnDebuffs(Character character, bool player)
    {
        for (int i = 0; i < character.ActiveDebuffs.Count; i++)
        {
            if (character.ActiveDebuffs[i].EndTurn)
            {
                if (character.ActiveDebuffs[i].TimesToTrigger > 0)
                {
                    if (character.ActiveDebuffs[i].EffectTime > 0)
                    {
                        character.ActiveDebuffs[i].DebuffEffect();
                        character.ActiveDebuffs[i].TimesToTrigger--;
                    }
                }
                if (character.ActiveDebuffs[i].EffectTime > 0)
                {
                    character.ActiveDebuffs[i].EffectTime--;
                    ManageStatusEffectUI.s_Instance.ReduceStatusEffectDurations(character.ActiveDebuffs[i].DebuffName, player);


                    if (character.ActiveDebuffs[i].EffectTime == 0)
                    {
                        ManageStatusEffectUI.s_Instance.RemoveStatusEffect(character.ActiveDebuffs[i].DebuffName, player);
                        character.ActiveDebuffs[i].RemoveEffect();
                        character.ActiveDebuffs.Remove(character.ActiveDebuffs[i]);
                        if (character.ActiveDebuffs.Count > 0)
                            i--;
                    }
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    public void EndBattle()
    {
        ActionBar.s_Instance.ClearCooldowns();
        m_BattleIsOngoing = false;
        if (IdleCharacter == PlayerData.s_Instance)
        {
            //Game Over
            PlayerData.s_Instance.Losses++;
            PanelManager.s_Instance.ShowPanel("BattleLostPanel");
            int GoldLost = Mathf.RoundToInt(PlayerData.s_Instance.Gold * 0.1f);
            EndOfCombatPopups.s_Instance.SetDefeatText(GoldLost);
            PlayerData.s_Instance.Gold = PlayerData.s_Instance.Gold - GoldLost;
            PlayerData.s_Instance.CurrentHealth = PlayerData.s_Instance.MaxHealth + PlayerData.s_Instance.MaxHealthBonus;
            PlayerData.s_Instance.CurrentMana = PlayerData.s_Instance.MaxMana + PlayerData.s_Instance.MaxManaBonus;
        }else if(IdleCharacter == Opponent)
        {
            //Won battle
            PlayerData.s_Instance.Wins++;
            PanelManager.s_Instance.ShowPanel("BattleWonPanel");
            
            for (int i = 0; i < AchievementDictionary.s_Achievements.Count; i++)
            {
                if(Opponent.Name == AchievementDictionary.s_Achievements[i].TargetName)
                {
                    if (!AchievementDictionary.s_Achievements[i].IsComplete)
                    {
                        AchievementDictionary.s_Achievements[i].AddToCurrentAmount(1);
                    }
                }
            }

            EndOfCombatPopups.s_Instance.SetVictoryText(Opponent.XPToGive, Opponent.GoldToGive);
            if (PlayerData.s_Instance.MaxFloor < Opponent.AdvanceToMaxFloor)
            {
                FloorManager.s_Advance = true;
                PlayerData.s_Instance.MaxFloor = Opponent.AdvanceToMaxFloor;
                PlayerData.s_Instance.AvailableTalentPoints++;
                PlayerData.s_Instance.TotalEarnedTalentPoints++;
            }
        }

        for (int i = 0; i < PlayerData.s_Instance.ActiveDebuffs.Count; i++)
        {
            PlayerData.s_Instance.ActiveDebuffs[i].RemoveEffect();
            PlayerData.s_Instance.ActiveDebuffs.Remove(PlayerData.s_Instance.ActiveDebuffs[i]);
        }

        SaveLoadPlayerData.s_Instance.SavePlayer();
    }

    IEnumerator WaitToPassTurn()
    {
        yield return new WaitForSeconds(0.3f);
    }
}