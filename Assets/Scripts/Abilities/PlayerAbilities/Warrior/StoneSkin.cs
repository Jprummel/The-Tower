public class StoneSkin : Ability
{
    public StoneSkin()
    {
        AbilityName = AbilityNames.STONE_SKIN;
        AbilityType = AbilityTypes.Buff;
        Range = 1.25f;
        ManaCost = 15;
        Cooldown = 5;
    }

    public override void AbilityEffect()
    {
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Stone Skin!", 1f, "Stone Skin");
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.ActiveCharacter, 3, DebuffNames.DamageReduction, "Stone Skin");
    }
}