public class FrostArrow : Ability
{
    public FrostArrow()
    {
        AbilityName = AbilityNames.FROST_ARROW;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 15;
        Cooldown = 4;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(80))
            {
                DealDamage(999, "Frost Arrow", CombatCalculations.s_Instance.CalculateDamage(1.5f));
                if (CombatCalculations.s_Instance.CalculateIfHit(60))
                {
                    WaitToAddNotification("And applied a stun!", 1.25f, "FrostArrow");
                    Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 1, DebuffNames.Stun, AbilityNames.FROST_ARROW);
                }
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Frost Arrow!" + ", but <color=grey>missed</color>!", 1.5f, "FrostArrow");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Frost Arrow!" + ", but <color=grey>missed</color>!", 1.5f, "FrostArrow");
        }
        BattleUI.s_UpdateBothInfo();
    }
}