using UnityEngine;

public class LeechingStrike : Ability
{
    public LeechingStrike()
    {
        AbilityName = AbilityNames.LEECHING_STRIKE;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 0;
        Cooldown = 4;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            float damage = CombatCalculations.s_Instance.CalculateDamage(1f);
            if (CombatCalculations.s_Instance.CalculateIfHit(99))
            {
                DealDamage(999, "Leeching Strike", damage);
                float hp = Mathf.Clamp(CombatTurns.s_Instance.ActiveCharacter.CurrentHealth + (damage / 2), 0, CombatTurns.s_Instance.ActiveCharacter.MaxHealth + CombatTurns.s_Instance.ActiveCharacter.MaxHealthBonus);
                float healing = hp - CombatTurns.s_Instance.ActiveCharacter.CurrentHealth;
                CombatTurns.s_Instance.ActiveCharacter.CurrentHealth = hp;
                HealingPopup.s_Instance.PopupAnimation(CombatTurns.s_Instance.ActiveCharacter.transform.position, (int)healing, !CombatTurns.s_Instance.ActiveCharacter.RightSide);
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Leeching Strike!" + ", but <color=grey>missed</color>!", 1.5f, "Leeching Strike");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Leeching Strike!" + ", but <color=grey>missed</color>!", 1.5f, "Leeching Strike");
        }
    }
}