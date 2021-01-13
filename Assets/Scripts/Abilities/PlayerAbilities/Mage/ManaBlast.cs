public class ManaBlast : Ability
{
    public ManaBlast()
    {
        AbilityName = AbilityNames.MANA_BLAST;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 0;
        Cooldown = 1;
    }

    public override void AbilityEffect()
    {
        int damage = (int)CombatTurns.s_Instance.ActiveCharacter.CurrentMana;
        CombatTurns.s_Instance.ActiveCharacter.CurrentMana -= damage;
        DealDamage(200, "Mana Blast", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage), true);
        BattleUI.s_UpdateBothInfo();
    }
}