using UnityEngine;
using DG.Tweening;

public class Ability : CombatActions
{
    public enum AbilityTypes
    {
        Melee,
        Ranged,
        Buff,
        Debuff
    }

    public AbilityTypes AbilityType;
    public string AbilityName;
    public float Range;
    public int ManaCost;
    public bool HasEnoughMana;
    public int Cooldown;
    public float CastTime = 1f;
    public int TurnsActive;

    public void UseAbility(bool PassTurn = true)
    {
        ManaCheck();
        if (HasEnoughMana)
        {
            StartAbility(PassTurn,waitTime:CastTime);
            AbilityEffect();
        }
    }

    public void StartAbility(bool waitToComplete = true, float waitTime = 1f)
    {
        bool IsPlayer;
        if(CombatTurns.s_Instance.ActiveCharacter == PlayerData.s_Instance)
        {
            IsPlayer = true;
            if (Cooldown > 0 && !PlayerAbilityManager.s_PlayerCooldowns.ContainsKey(AbilityName))
            {
                PlayerAbilityManager.s_PlayerCooldowns.Add(AbilityName, Cooldown);
                ActionBar.s_Instance.AddUnavailableAction(AbilityName);
            }
        }
        else
        {
            IsPlayer = false;
            int CD = Cooldown + 1;
            if (Cooldown > 0 && !OpponentCombatAI.s_OpponentCooldowns.ContainsKey(AbilityName))
            {
                OpponentCombatAI.s_OpponentCooldowns.Add(AbilityName, CD);
            }
        }
        CombatTurns.s_Instance.ActiveCharacter.CurrentMana -= ManaCost;
        BattleUI.s_UpdateBothInfo();
        if (waitToComplete)
        {
            if (IsPlayer)
            {
                ActionSelected();
            }
            WaitToCompleteAction(waitTime);
        }
    }

    public virtual void AbilityEffect() { }

    protected void ManaCheck()
    {
        if(CombatTurns.s_Instance.ActiveCharacter.CurrentMana >= ManaCost)
        {
            HasEnoughMana = true;
        }
        else
        {
            HasEnoughMana = false;
        }
    }

    protected void WaitToAddNotification(string notification, float animationTime, string ability)
    {
        Sequence NotificationSequence = DOTween.Sequence();
        NotificationSequence.AppendInterval(0.5f);
        NotificationSequence.AppendCallback(() => CombatNotification.s_Instance.AddNotification(notification, animationTime, ability));        
    }
}