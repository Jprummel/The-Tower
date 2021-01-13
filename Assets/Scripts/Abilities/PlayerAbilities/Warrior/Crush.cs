public class Crush : Ability
{
    public Crush()
    {
        AbilityName = AbilityNames.CRUSH;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 25;
        Cooldown = 4;
    }

    public override void AbilityEffect()
    {
        float damage = CombatCalculations.s_Instance.CalculateDamage(1f) + (CombatTurns.s_Instance.ActiveCharacter.MaxHealth + CombatTurns.s_Instance.ActiveCharacter.MaxHealthBonus) / 100 * 20;
        DealDamage(90, "Crush", damage);
    }
}