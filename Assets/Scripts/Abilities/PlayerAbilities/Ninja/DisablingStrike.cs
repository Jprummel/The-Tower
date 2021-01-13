public class DisablingStrike : Ability
{
    public DisablingStrike()
    {
        AbilityName = AbilityNames.DISABLING_STRIKE;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 10;
        Cooldown = 5;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(99))
            {
                Attack(999, 1.2f, "Disabling Strike");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 2, DebuffNames.Disable, "Disabling Strike");
            }
            else
            {
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Disabling Strike!" + ", but <color=grey>missed</color>!", 1.5f, "Disabling Strike");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Disabling Strike!" + ", but <color=grey>missed</color>!", 1.5f, "Disabling Strike");
        }
        BattleUI.s_UpdateBothInfo();
    }
}