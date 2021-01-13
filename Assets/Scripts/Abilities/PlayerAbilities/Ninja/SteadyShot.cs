using UnityEngine;
public class SteadyShot : Ability
{
    public SteadyShot()
    {
        AbilityName = AbilityNames.STEADY_SHOT;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 15;
        Cooldown = 2;
    }

    public override void AbilityEffect()
    {
        Shoot(999, 1.5f, "Steady Shot");
        BattleUI.s_UpdateBothInfo();
    }
}