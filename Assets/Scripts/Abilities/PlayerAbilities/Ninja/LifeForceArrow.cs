public class LifeForceArrow : Ability
{
    public LifeForceArrow()
    {
        AbilityName = AbilityNames.LIFE_FORCE_ARROW;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 20;
        Cooldown = 6;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(85))
            {
                DealDamage(999, "Life Force Arrow", CombatCalculations.s_Instance.CalculateDamage(1.5f));
                int debuffDamage = (int)(CombatTurns.s_Instance.IdleCharacter.MaxHealth + CombatTurns.s_Instance.IdleCharacter.MaxHealthBonus) / 100 * 15;
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 2, DebuffNames.LifeForceDrain, "Life Force Arrow", value: debuffDamage);
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Life Force Arrow!" + ", but <color=grey>missed</color>!", 1.5f, "Life Force Arrow");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Life Force Arrow!" + ", but <color=grey>missed</color>!", 1.5f, "Life Force Arrow");
        }
        BattleUI.s_UpdateBothInfo();
    }
}