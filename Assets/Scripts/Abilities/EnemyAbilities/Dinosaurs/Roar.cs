using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : Ability
{
    public Roar()
    {
        AbilityName = AbilityNames.ROAR;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 25;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        float damage = CombatCalculations.s_Instance.CalculateDamage(0.8f);

        if (CombatCalculations.s_Instance.CalculateIfHit(100))
        {
            DealDamage(999, "Roar", damage);
            WaitToAddNotification("And applied weaken!", 1.5f, "Weaken");
            Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Weaken, "Weaken");
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Roar, but <color=grey>missed</color>!", 1.5f, "Roar");

        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
