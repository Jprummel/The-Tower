using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : Ability
{
    public Sting()
    {
        AbilityName = AbilityNames.STING;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 15;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfHit(95))
        {
            DealDamage(999, "Sting", CombatCalculations.s_Instance.CalculateDamage(1));

            if (CombatCalculations.s_Instance.CalculateIfHit(66))
            {
                WaitToAddNotification("And applied Poison!", 1.5f, "Poison");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Ignite, "Leeching Strike", value: (int)(CombatTurns.s_Instance.ActiveCharacter.Strength*1.5f));
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Sting, but <color=grey>missed</color>!", 1.5f, "Sting");
        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
