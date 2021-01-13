using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : Ability
{
    public Blizzard()
    {
        AbilityName = AbilityNames.BLIZZARD;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 25;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        int damage = CombatTurns.s_Instance.ActiveCharacter.Intellect * 2;

        if (CombatCalculations.s_Instance.CalculateIfHit(90))
        {
            DealDamage(999, "Blizzard", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
            if (CombatCalculations.s_Instance.CalculateIfHit(33))
            {
                WaitToAddNotification("And applied Frost!", 1.5f, "Frost");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 1 , DebuffNames.Stun, "Frost");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Blizzard, but <color=grey>missed</color>!", 1.5f, "Blizzard");

        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
