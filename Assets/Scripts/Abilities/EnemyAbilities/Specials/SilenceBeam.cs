using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceBeam : Ability
{
    public SilenceBeam()
    {
        AbilityName = AbilityNames.SILENCE_BEAM;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 25;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        int damage = CombatTurns.s_Instance.ActiveCharacter.Intellect * 2;

        if (CombatCalculations.s_Instance.CalculateIfHit(950))
        {
            DealDamage(999, "Silence Beam", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
            WaitToAddNotification("And applied silence!", 1.5f, "Disabling Strike");
            Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 2, DebuffNames.Disable,"Disabling Strike");
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Silence Beam, but <color=grey>missed</color>!", 1.5f, "Silence Beam");

        }
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}
