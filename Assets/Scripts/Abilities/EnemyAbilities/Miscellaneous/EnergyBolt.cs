using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBolt : Ability
{
    public EnergyBolt()
    {
        AbilityName = AbilityNames.ENERGY_BOLT;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 5;
        Cooldown = 0;
    }

    public override void AbilityEffect()
    {
        int damage = Mathf.RoundToInt(CombatTurns.s_Instance.ActiveCharacter.Intellect * 0.8f);

        if (CombatCalculations.s_Instance.CalculateIfHit(90))
        {
            DealDamage(999, "Energy Bolt", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Energy Bolt, but <color=grey>missed</color>!", 1.5f, "Energy Bolt");
        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
