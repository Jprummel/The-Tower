public class Weaken : Ability
{
    public Weaken()
    {
        AbilityName = AbilityNames.WEAKEN;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 80;
        Cooldown = 6;
    }

    public override void AbilityEffect()
    {
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Weaken!", 1f, "Weaken");
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Weaken,"Weaken");
    }
}