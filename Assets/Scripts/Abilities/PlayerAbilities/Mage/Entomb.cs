public class Entomb : Ability
{
    public Entomb()
    {
        AbilityName = AbilityNames.ENTOMB;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 100;
        Cooldown = 8;
    }
    
    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfHit(85))
        {
            Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 2, DebuffNames.MovementBlock, "Entomb");
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Entomb!", 1f,"Entomb");
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Entomb, but missed.", 1f,"Entomb");
        }
        base.AbilityEffect();
    }
}