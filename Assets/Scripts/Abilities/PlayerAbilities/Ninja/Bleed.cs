public class Bleed : Ability
{
    public Bleed()
    {
        AbilityName = AbilityNames.BLEED;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 10;
        Cooldown = 6;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(99))
            {
                Attack(999, 0.8f, "Bleed");
                int attackDamage = CombatTurns.s_Instance.ActiveCharacter.Strength * 5;
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Ignite, "Bleed", value: attackDamage);
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Bleed!" + ", but <color=grey>missed</color>!", 1.5f, "Bleed");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Bleed!" + ", but <color=grey>missed</color>!", 1.5f, "Bleed");
        }
        BattleUI.s_UpdateBothInfo();
    }
}