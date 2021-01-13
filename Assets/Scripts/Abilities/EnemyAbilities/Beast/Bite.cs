using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : Ability
{
    public Bite()
    {
        AbilityName = AbilityNames.BITE;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 10;
        Cooldown = 1;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(90))
            {
                Attack(999, 1f, "Bite");
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Bite!" + ", but <color=grey>missed</color>!", 1.5f);
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Bite!" + ", but <color=grey>missed</color>!", 1.5f);
        }
        BattleUI.s_UpdateBothInfo();
    }
}
