using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellfire : Ability
{
    public Hellfire()
    {
        AbilityName = AbilityNames.FLAMESTRIKE;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 20;
        Cooldown = 4;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfHit(75))
        {
            DealDamage(999, "Hellfire", CombatCalculations.s_Instance.CalculateDamage(1.25f));
            if (CombatCalculations.s_Instance.CalculateIfHit(999))
            {
                int igniteDamage = Mathf.RoundToInt(CombatTurns.s_Instance.ActiveCharacter.Strength * 0.5f);
                WaitToAddNotification("And applied Ignite!", 1.5f, "Ignite");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Ignite, "Ignite", value: igniteDamage);
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Hellfire, but <color=grey>missed</color>!", 1.5f, "Hellfire");

        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
