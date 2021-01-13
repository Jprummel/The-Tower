using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Ability
{
    public Shoot()
    {
        AbilityName = AbilityNames.SHOOT;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 0;
        Cooldown = 0;
    }

    public override void AbilityEffect()
    {

        if (CombatCalculations.s_Instance.CalculateIfHit(90))
        {
            DealDamage(999, "Shoot", CombatCalculations.s_Instance.CalculateDamage(1f));
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Shoot, but <color=grey>missed</color>!", 1.5f, "Shoot");
        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
