public class Assassinate : Ability
{
    public Assassinate()
    {
        AbilityName = AbilityNames.ASSASSINATE;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 200;
        Cooldown = 9;
    }

    public override void AbilityEffect()
    {
        int opponentMaxHP = (int)CombatTurns.s_Instance.IdleCharacter.MaxHealth + CombatTurns.s_Instance.IdleCharacter.MaxHealthBonus;

        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(90))
            {
                if (CombatTurns.s_Instance.IdleCharacter.CurrentHealth <= (opponentMaxHP / 100 * 20))
                {
                    DealDamage(999, "Assassinate", CombatTurns.s_Instance.IdleCharacter.CurrentHealth);
                }
                else
                {
                    DealDamage(999, "Assassinate", CombatCalculations.s_Instance.CalculateDamage(1f));
                }
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Assassinate!" + ", but <color=grey>missed</color>!", 1.5f, "Assassinate");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Assassinate!" + ", but <color=grey>missed</color>!", 1.5f);
        }
        BattleUI.s_UpdateBothInfo();
    }
}