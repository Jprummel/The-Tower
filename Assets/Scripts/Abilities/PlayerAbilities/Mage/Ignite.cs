public class Ignite : Ability
{
    public Ignite()
    {
        AbilityName = AbilityNames.IGNITE;
        AbilityType = AbilityTypes.Debuff;
        Range = 50f;
        ManaCost = 30;
        Cooldown = 6;
    }

    public override void AbilityEffect()
    {
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Ignite!", 1f, "Ignite");
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Ignite, "Ignite",value: (int)(CombatTurns.s_Instance.IdleCharacter.MaxHealth + CombatTurns.s_Instance.IdleCharacter.MaxHealthBonus) / 100 * 5);
        BattleUI.s_UpdateBothInfo();
    }
}