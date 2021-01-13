using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialCut : Ability
{
    public AerialCut()
    {
        AbilityName = AbilityNames.AERIAL_CUT;
        AbilityType = AbilityTypes.Ranged;
        Range = 5f;
        ManaCost = 10;
        Cooldown = 2;
    }

    public override void AbilityEffect()
    {
        float damage = CombatTurns.s_Instance.ActiveCharacter.Strength * 1.5f + CombatTurns.s_Instance.ActiveCharacter.Agility;

        if (CombatCalculations.s_Instance.CalculateIfHit(90))
        {
            DealDamage(999, "Aerial Cut", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
            if (CombatCalculations.s_Instance.CalculateIfHit(50))
            {
                WaitToAddNotification("And applied bleed!", 1.5f, "Aerial Cut");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Bleed, "Bleed");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Aerial Cut, but <color=grey>missed</color>!", 1.5f, "Aerial Cut");
        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
