using DG.Tweening;

public class PhantomStrike : Ability
{
    public PhantomStrike()
    {
        AbilityName = AbilityNames.PHANTOM_STRIKE;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 10;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            float damage = CombatCalculations.s_Instance.CalculateDamage(0.8f);
            Sequence phantomStrikeSequence = DOTween.Sequence();
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Phantom Strike!", 1.5f, "Phantom Strike");
            DealDamage(200, "Light attack", damage, false);
            phantomStrikeSequence.AppendInterval(0.6f).OnComplete(() => DealDamage(99, "Light attack", damage, false));
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Phantom Strike!" + ", but <color=grey>missed</color>!", 1.5f, "Phantom Strike");
        }
    }
}