using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : Ability
{
    public Earthquake()
    {
        AbilityName = AbilityNames.EARTHQUAKE;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 20;
        Cooldown = 5;
    }

    public override void AbilityEffect()
    {
        int damage = CombatTurns.s_Instance.ActiveCharacter.Intellect + CombatTurns.s_Instance.ActiveCharacter.Strength + Mathf.RoundToInt(CombatTurns.s_Instance.ActiveCharacter.Stamina * 0.25f);

        if (CombatCalculations.s_Instance.CalculateIfHit(999))
        {
            DealDamage(999, "Earthquake", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
            if (CombatCalculations.s_Instance.CalculateIfHit(33))
            {
                WaitToAddNotification("And applied a stun!", 1.5f, "Earthquake");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Stun, "Stun");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Earthquake, but <color=grey>missed</color>!", 1.5f, "Earthquake");

        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
