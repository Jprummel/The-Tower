using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBlast : Ability
{
    public RockBlast()
    {
        AbilityName = AbilityNames.ROCK_BLAST;
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
            DealDamage(999, "Rock blast", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
            if (CombatCalculations.s_Instance.CalculateIfHit(33))
            {
                WaitToAddNotification("And applied weaken!", 1.5f, "Weaken");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Weaken, "Weaken");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Rock blast, but <color=grey>missed</color>!", 1.5f, "Rock blast");

        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
