using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAndDecay : Ability
{
    public DeathAndDecay()
    {
        AbilityName = AbilityNames.DEATH_AND_DECAY;
        AbilityType = AbilityTypes.Ranged;
        Range = 99f;
        ManaCost = 15;
        Cooldown = 5;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfHit(85))
        {
            DealDamage(999, "Death & Decay", CombatCalculations.s_Instance.CalculateDamage(1));

            if (CombatCalculations.s_Instance.CalculateIfHit(100))
            {
                WaitToAddNotification("And applied Poison!", 1.5f, "Poison");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Ignite, "Leeching Strike", value: (int)(CombatTurns.s_Instance.ActiveCharacter.Strength * 1.5f));
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Death & Decay, but <color=grey>missed</color>!", 1.5f, "Death & Decay");
        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
