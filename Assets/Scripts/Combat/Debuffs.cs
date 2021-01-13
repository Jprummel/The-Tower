using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff
{
    public string DebuffName;
    public int EffectTime;
    public int TimesToTrigger;
    public bool LateTrigger = false;
    public bool EndTurn = false;
    public delegate void Effect();
    public Effect DebuffEffect;
    public Effect RemoveEffect;
}

public enum DebuffNames{

    MovementBlock,
    Weaken,
    DefenseBuff,
    Ignite,
    Stun,
    Drain,
    Bleed,
    LifeForceDrain,
    Disable,
    Immune,
    DamageReduction,
    HealingOverTime
}

public class Debuffs : MonoBehaviour
{
    public static Debuffs s_Instance;

    void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    void AbilityBlock(Character characterToDebuff, bool Completed = false)
    {
        if (!Completed)
            characterToDebuff.Disabled = true;
        else { }
            characterToDebuff.Disabled = false; //Debug.Log("Remove Disable");
    }

    /*void Drain(Character caster, Character characterToDebuff, bool Completed = false)
    {
        if (!Completed)
        {
            float damage = caster.Intellect;
            float OGDamage = damage;

            if (CombatTurns.s_Instance.IdleCharacter.ShieldValue > 0)
            {
                if (damage >= CombatTurns.s_Instance.IdleCharacter.ShieldValue)
                {
                    damage -= CombatTurns.s_Instance.IdleCharacter.ShieldValue;
                    CombatTurns.s_Instance.IdleCharacter.ShieldValue = 0;
                }
                else
                {
                    CombatTurns.s_Instance.IdleCharacter.ShieldValue -= (int)damage;
                    DamagePopup.s_Instance.PopupAnimation(CombatTurns.s_Instance.IdleCharacter.transform.position, (int)OGDamage, CombatTurns.s_Instance.IdleCharacter.RightSide);
                }
                BattleUI.s_UpdateBothInfo();
            }

            if (characterToDebuff.CurrentHealth > damage)
            {
                characterToDebuff.CurrentHealth = Mathf.Clamp(characterToDebuff.CurrentHealth -= damage, 1, int.MaxValue);
            }
            else if (characterToDebuff.CurrentHealth > 1)
            {
                OGDamage = characterToDebuff.CurrentHealth - 1;
                characterToDebuff.CurrentHealth = 1;
            }
            else
                OGDamage = 0;

            float hp = Mathf.Clamp(caster.CurrentHealth + OGDamage, 0, caster.MaxHealth + caster.MaxHealthBonus);
            float healing = hp - caster.CurrentHealth;
            caster.CurrentHealth = hp;
            DamagePopup.s_Instance.PopupAnimation(characterToDebuff.transform.position, (int)OGDamage, characterToDebuff.RightSide);
            //HealingPopup.s_Instance.PopupAnimation(caster.transform.position, (int)healing, !caster.RightSide);
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.IdleCharacter.Name + " got drained for " + OGDamage + "!", 1.5f);
            BattleUI.s_UpdateBothInfo();
            TweenEffects.s_Instance.GetDamagedEffect(CombatTurns.s_Instance.IdleCharacter);
        }
        else
            return;
    }*/

    void Stun(Character characterToDebuff, bool Completed = false)
    {
        if (!Completed)
        {
            characterToDebuff.CanMove = false;
            characterToDebuff.CanAttack = false;

        }
        else
        {
            characterToDebuff.CanMove = true;
            characterToDebuff.CanAttack = true;
        }
    }

    void DamageOverTime(Character characterToDebuff,int damage, bool Completed = false)
    {
        if (!Completed)
            characterToDebuff.TakeDamage(damage, false);
        else
            return;
    }

    void FrozenArmor(Character characterToDebuff, int defenseValue, bool Completed = false)
    {
        if (!Completed)
            characterToDebuff.Defense += defenseValue;
        else
            characterToDebuff.Defense -= defenseValue;
    }

    void MovementBlock(Character characterToDebuff, bool Completed = false)
    {
        if (!Completed)
            characterToDebuff.CanMove = false;
        else
            characterToDebuff.CanMove = true;
    }

    void Weaken(Character characterToDebuff, bool Completed = false)
    {
        if (!Completed)
            characterToDebuff.Strength = characterToDebuff.Strength / 2;
        else
            characterToDebuff.Strength = characterToDebuff.Strength * 2;
    }

    void Immune(Character characterToDebuff, bool Completed = false)
    {
        if (!Completed)
            characterToDebuff.Immune = true;
        else
            characterToDebuff.Immune = false;
    }

    void ReduceDamage(Character characterToDebuff, bool Completed = false)
    {
        if (!Completed)
            characterToDebuff.DamageAmplifier -= 0.2f;
        else
            characterToDebuff.DamageAmplifier += 0.2f;
    }

    void HealOverTime(Character characterToDebuff, int healing, bool Completed = false)
    {
        float hp = Mathf.Clamp(characterToDebuff.CurrentHealth + healing, 0, characterToDebuff.MaxHealth + characterToDebuff.MaxHealthBonus);
        float finalHealing = hp - characterToDebuff.CurrentHealth;
        characterToDebuff.CurrentHealth = hp;
        HealingPopup.s_Instance.PopupAnimation(characterToDebuff.transform.position, (int)healing, !characterToDebuff.RightSide);
    }

    public void AddDebuff(Character characterToDebuff, int effectTime, DebuffNames debuff,string talentName , int value = 0, Character caster = null)
    {
        switch (debuff)
        {
            case DebuffNames.MovementBlock:
                Debuff MovementDebuff = new Debuff() {
                    DebuffName = DebuffNames.MovementBlock.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = 1,
                    DebuffEffect = () => MovementBlock(characterToDebuff),
                    RemoveEffect = () => MovementBlock(characterToDebuff, true)
                };
                if (CanAddDebuff(characterToDebuff, MovementDebuff))
                {
                    characterToDebuff.ActiveDebuffs.Add(MovementDebuff);
                    AddStatusEffectUI(false,talentName, effectTime, DebuffNames.MovementBlock.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.MovementBlock.ToString(), false);
                break;
            case DebuffNames.Weaken:
                Debuff StrengthDebuff = new Debuff() {
                    DebuffName = DebuffNames.Weaken.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = 1,
                    LateTrigger = true,
                    DebuffEffect = () => Weaken(characterToDebuff),
                    RemoveEffect = () => Weaken(characterToDebuff, true)
                };
                if (CanAddDebuff(characterToDebuff, StrengthDebuff))
                {
                    characterToDebuff.ActiveDebuffs.Add(StrengthDebuff);
                    AddStatusEffectUI(false, "Weaken", effectTime, DebuffNames.Weaken.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.Weaken.ToString(), false);
                break;
            case DebuffNames.DefenseBuff:
                Debuff DefenseBuff = new Debuff()
                {
                    DebuffName = DebuffNames.DefenseBuff.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = 1,
                    DebuffEffect = () => FrozenArmor(characterToDebuff, value),
                    RemoveEffect = () => FrozenArmor(characterToDebuff, value, true)
                };
                if (CanAddDebuff(characterToDebuff, DefenseBuff, true))
                {
                    characterToDebuff.ActiveDebuffs.Add(DefenseBuff);
                    AddStatusEffectUI(true,talentName, effectTime, DebuffNames.DefenseBuff.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.DefenseBuff.ToString(), true);

                DefenseBuff.DebuffEffect(); DefenseBuff.TimesToTrigger--;
                break;
            case DebuffNames.Ignite:
                Debuff Ignite = new Debuff()
                {
                    DebuffName = DebuffNames.Ignite.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = effectTime,
                    DebuffEffect = () => DamageOverTime(characterToDebuff, value),
                    RemoveEffect = () => DamageOverTime(characterToDebuff,value, true)
                };
                if (CanAddDebuff(characterToDebuff, Ignite))
                {
                    characterToDebuff.ActiveDebuffs.Add(Ignite);
                    AddStatusEffectUI(false,talentName, effectTime, DebuffNames.Ignite.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.Ignite.ToString(), false);
                break;
            case DebuffNames.Stun:
                Debuff StunEffect = new Debuff()
                {
                    DebuffName = DebuffNames.Stun.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = 1,
                    DebuffEffect = () => Stun(characterToDebuff),
                    RemoveEffect = () => Stun(characterToDebuff, true)
                };
                if (CanAddDebuff(characterToDebuff, StunEffect))
                {
                    characterToDebuff.ActiveDebuffs.Add(StunEffect);
                    AddStatusEffectUI(false,talentName, effectTime, DebuffNames.Stun.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.Stun.ToString(), false);
                break;
            case DebuffNames.Drain:
                Debuff DrainDebuff = new Debuff()
                {
                    DebuffName = DebuffNames.Drain.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = effectTime,
                    DebuffEffect = () => DamageOverTime(characterToDebuff, value),
                    RemoveEffect = () => DamageOverTime(characterToDebuff, value, true)
                };
                if (CanAddDebuff(characterToDebuff, DrainDebuff))
                {
                    characterToDebuff.ActiveDebuffs.Add(DrainDebuff);
                    AddStatusEffectUI(false,talentName, effectTime, DebuffNames.Drain.ToString());
                }
                else
                {
                    RefreshStatusEffectUI(effectTime, DebuffNames.Drain.ToString(), false);
                }
                break;
            case DebuffNames.Bleed:
                Debuff BleedDebuff = new Debuff()
                {
                    DebuffName = DebuffNames.Bleed.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = effectTime,
                    DebuffEffect = () => DamageOverTime(characterToDebuff, value),
                    RemoveEffect = () => DamageOverTime(characterToDebuff, value, true)
                };
                if (CanAddDebuff(characterToDebuff, BleedDebuff))
                {
                    characterToDebuff.ActiveDebuffs.Add(BleedDebuff);
                    AddStatusEffectUI(false,talentName, effectTime, DebuffNames.Bleed.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.Bleed.ToString(), false);
                break;
            case DebuffNames.LifeForceDrain:
                Debuff LifeForceDebuff = new Debuff()
                {
                    DebuffName = DebuffNames.LifeForceDrain.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = effectTime,
                    DebuffEffect = () => DamageOverTime(characterToDebuff, value),
                    RemoveEffect = () => DamageOverTime(characterToDebuff, value, true)
                };
                if (CanAddDebuff(characterToDebuff, LifeForceDebuff))
                {
                    characterToDebuff.ActiveDebuffs.Add(LifeForceDebuff);
                    AddStatusEffectUI(false, talentName, effectTime, DebuffNames.LifeForceDrain.ToString());
                    AddStatusEffectUI(true, talentName, effectTime, DebuffNames.LifeForceDrain.ToString());
                }
                else
                {
                    RefreshStatusEffectUI(effectTime, DebuffNames.LifeForceDrain.ToString(), false);
                    RefreshStatusEffectUI(effectTime, DebuffNames.LifeForceDrain.ToString(), true);
                }
                break;
            case DebuffNames.Disable:
                Debuff DisableDebuff = new Debuff()
                {
                    DebuffName = DebuffNames.Disable.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = 1,
                    EndTurn = true,
                    DebuffEffect = () => AbilityBlock(characterToDebuff),
                    RemoveEffect = () => AbilityBlock(characterToDebuff, true)
                };
                if (CanAddDebuff(characterToDebuff, DisableDebuff))
                {
                    characterToDebuff.ActiveDebuffs.Add(DisableDebuff);
                    characterToDebuff.Disabled = true;
                    AddStatusEffectUI(false,talentName, effectTime, DebuffNames.Disable.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.Disable.ToString(), false);
                break;
            case DebuffNames.Immune:
                Debuff ImmunityBuff = new Debuff()
                {
                    DebuffName = DebuffNames.Immune.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = 1,
                    DebuffEffect = () => Immune(characterToDebuff),
                    RemoveEffect = () => Immune(characterToDebuff, true)
                };
                if (CanAddDebuff(characterToDebuff, ImmunityBuff, true))
                {
                    characterToDebuff.ActiveDebuffs.Add(ImmunityBuff);
                    AddStatusEffectUI(true, talentName, effectTime, DebuffNames.Immune.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.Immune.ToString(), true);

                ImmunityBuff.DebuffEffect(); ImmunityBuff.TimesToTrigger--;
                break;
            case DebuffNames.DamageReduction:
                Debuff ReduceDamageBuff = new Debuff()
                {
                    DebuffName = DebuffNames.DamageReduction.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = 1,
                    DebuffEffect = () => ReduceDamage(characterToDebuff),
                    RemoveEffect = () => ReduceDamage(characterToDebuff, true)
                };
                if (CanAddDebuff(characterToDebuff, ReduceDamageBuff, true))
                {
                    characterToDebuff.ActiveDebuffs.Add(ReduceDamageBuff);
                    AddStatusEffectUI(true, talentName, effectTime, DebuffNames.DamageReduction.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.DamageReduction.ToString(), true);

                ReduceDamageBuff.DebuffEffect(); ReduceDamageBuff.TimesToTrigger--;
                break;
            case DebuffNames.HealingOverTime:
                Debuff HealingBuff = new Debuff()
                {
                    DebuffName = DebuffNames.HealingOverTime.ToString(),
                    EffectTime = effectTime,
                    TimesToTrigger = effectTime,
                    DebuffEffect = () => HealOverTime(characterToDebuff, value),
                    RemoveEffect = () => HealOverTime(characterToDebuff, value, true)
                };
                if (CanAddDebuff(characterToDebuff, HealingBuff, true))
                {
                    characterToDebuff.ActiveDebuffs.Add(HealingBuff);
                    AddStatusEffectUI(true, talentName, effectTime, DebuffNames.HealingOverTime.ToString());
                }
                else
                    RefreshStatusEffectUI(effectTime, DebuffNames.HealingOverTime.ToString(), true);
                break;
        }
    }

    private bool CanAddDebuff(Character character, Debuff debuffToAdd, bool buff = false)
    {
        for (int i = 0; i < character.ActiveDebuffs.Count; i++)
        {
            if (character.ActiveDebuffs[i].DebuffName == debuffToAdd.DebuffName)
            {
                if (buff)
                    character.ActiveDebuffs[i].EffectTime = debuffToAdd.EffectTime - 1;
                else
                    character.ActiveDebuffs[i].EffectTime = debuffToAdd.EffectTime;

                if (debuffToAdd.TimesToTrigger > 1) { character.ActiveDebuffs[i].TimesToTrigger = debuffToAdd.TimesToTrigger; }
                return false;
            }
        }

        return true;
    }

    private void AddStatusEffectUI(bool buff,string talentName,int duration, string debuffName)
    {
        if (buff)
        {
            if(CombatTurns.s_Instance.CurrentCharacterTurn == CombatTurns.Characters.PLAYER)
            {
                ManageStatusEffectUI.s_Instance.AddPlayerStatusEffect(TalentManager.s_Instance.GetTalentByName(talentName).TalentIcon, duration, true, debuffName);
            }
            else
            {
                ManageStatusEffectUI.s_Instance.AddOpponentStatusEffect(Resources.Load<Sprite>("Abilities/" + talentName), duration, true, debuffName);
            }
        }
        else
        {
            if (CombatTurns.s_Instance.CurrentCharacterTurn == CombatTurns.Characters.PLAYER)
            {
                
                ManageStatusEffectUI.s_Instance.AddOpponentStatusEffect(TalentManager.s_Instance.GetTalentByName(talentName).TalentIcon, duration, false, debuffName);
            }
            else
            {
                ManageStatusEffectUI.s_Instance.AddPlayerStatusEffect(Resources.Load<Sprite>("Abilities/" + talentName), duration, false, debuffName);
            }
        }
    }

    private void RefreshStatusEffectUI(int duration, string debuffName, bool buff)
    {
        if (!buff)
        {
            if(CombatTurns.s_Instance.CurrentCharacterTurn == CombatTurns.Characters.OPPONENT)
                ManageStatusEffectUI.s_Instance.RefreshPlayerStatusEffect(duration, debuffName, true);
            else
                ManageStatusEffectUI.s_Instance.RefreshPlayerStatusEffect(duration, debuffName, false);
        }
        else
        {
            if (CombatTurns.s_Instance.CurrentCharacterTurn == CombatTurns.Characters.PLAYER)
                ManageStatusEffectUI.s_Instance.RefreshPlayerStatusEffect(duration, debuffName, true);
            else
                ManageStatusEffectUI.s_Instance.RefreshPlayerStatusEffect(duration, debuffName, false);
        }
    }
}
