public class DivineBlessing : Ability
{
    public DivineBlessing()
    {
        AbilityName = AbilityNames.DIVINE_BLESSING;
        AbilityType = AbilityTypes.Buff;
        Range = 1.25f;
        ManaCost = 0;
        Cooldown = 8;
    }

    public override void AbilityEffect()
    {
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Divine Blessing!", 1f, "Divine Blessing");
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.ActiveCharacter, 2, DebuffNames.Immune, AbilityNames.DIVINE_BLESSING);
    }
}