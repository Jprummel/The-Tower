using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : Ability
{
    public Smash()
    {
        AbilityName = AbilityNames.SMASH;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 15;
        Cooldown = 2;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(90))
            {
                Attack(999, 1.2f, "Smash");
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Smash!" + ", but <color=grey>missed</color>!", 1.5f, "Smash");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Smash!" + ", but <color=grey>missed</color>!", 1.5f, "Smash");
        }
        BattleUI.s_UpdateBothInfo();
    }
}
