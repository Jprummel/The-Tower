using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamestrike : Ability
{
    public Flamestrike()
    {
        AbilityName = AbilityNames.FLAMESTRIKE;
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
            DealDamage(999, "Flamestrike", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
            if (CombatCalculations.s_Instance.CalculateIfHit(40))
            {
                int igniteDamage = Mathf.RoundToInt(CombatTurns.s_Instance.ActiveCharacter.Intellect * 0.75f);
                WaitToAddNotification("And applied Ignite!", 1.5f, "Ignite");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Ignite, "Ignite", value:igniteDamage);
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Flamestrike, but <color=grey>missed</color>!", 1.5f, "Flamestrike");

        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
