public class DivineArrow : Ability
{
    public DivineArrow()
    {
        AbilityName = AbilityNames.DIVINE_ARROW;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 30;
        Cooldown = 5;
    }

    public override void AbilityEffect()
    {
        float missingHPDamage = ((CombatTurns.s_Instance.IdleCharacter.MaxHealth + CombatTurns.s_Instance.IdleCharacter.MaxHealthBonus) - CombatTurns.s_Instance.IdleCharacter.CurrentHealth) / 100 * 25;
        Shoot(85, 0.9f, "Divine Arrow", missingHPDamage);
        BattleUI.s_UpdateBothInfo();
    }
}
