public class LifeDrain : Ability
{
    public LifeDrain()
    {
        AbilityName = AbilityNames.LIFEDRAIN;
        AbilityType = AbilityTypes.Buff;
        Range = 50f;
        ManaCost = 75;
        Cooldown = 6;
    }

    public override void AbilityEffect()
    {
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Life Drain!", 1f, "Life Drain");
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Drain, "Life Drain", CombatTurns.s_Instance.ActiveCharacter.Intellect);
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.ActiveCharacter, 3, DebuffNames.HealingOverTime, "Life Drain", CombatTurns.s_Instance.ActiveCharacter.Intellect / 2);
        BattleUI.s_UpdateBothInfo();
    }
}