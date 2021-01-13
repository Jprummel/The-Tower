public class WeakeningStrike : Ability
{
    public WeakeningStrike()
    {
        AbilityName = AbilityNames.WEAKENING_STRIKE;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 100;
        Cooldown = 7;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(90))
            {
                Attack(999, 1.2f, "Weakening Strike");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Weaken, AbilityNames.WEAKENING_STRIKE);
            }
            else
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Weakening Strike!" + ", but <color=grey>missed</color>!", 1.5f, "Weakening Strike");
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Weakening Strike!" + ", but <color=grey>missed</color>!", 1.5f, "Weakening Strike");
        }
        BattleUI.s_UpdateBothInfo();
    }
}