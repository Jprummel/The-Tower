using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : Ability
{
    public Stab()
    {
        AbilityName = AbilityNames.STAB;
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
                Attack(999, 0.8f, "Stab");

                if (CombatCalculations.s_Instance.CalculateIfHit(34))
                {
                    WaitToAddNotification("And applied Bleed!", 1.5f, "Bleed");

                    int attackDamage = CombatTurns.s_Instance.ActiveCharacter.Strength * 2;
                    Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Bleed, "Bleed", value: attackDamage);
                }
                
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Stab!" + ", but <color=grey>missed</color>!", 1.5f, "Stab");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Stab!" + ", but <color=grey>missed</color>!", 1.5f);
        }
        BattleUI.s_UpdateBothInfo();
    }
}
