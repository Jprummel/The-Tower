using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunder : Ability
{
    public Plunder()
    {
        AbilityName = AbilityNames.PLUNDER;
        AbilityType = AbilityTypes.Ranged;
        Range = 50;
        ManaCost = 10;
        Cooldown = 4;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(90))
            {
                DealDamage(999, "Plunder", CombatCalculations.s_Instance.CalculateDamage(0.8f));

                int goldStolen = (int)PlayerData.s_Instance.Gold / 100 * 5;
                PlayerData.s_Instance.Gold -= goldStolen;
                WaitToAddNotification("And stole <color=yellow>" + goldStolen + "</color> gold!", 1.35f, "GoldPouch");
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Plunder!" + ", but <color=grey>missed</color>!", 1.5f);
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Plunder!" + ", but <color=grey>missed</color>!", 1.5f);
        }
        BattleUI.s_UpdateBothInfo();
    }
}
