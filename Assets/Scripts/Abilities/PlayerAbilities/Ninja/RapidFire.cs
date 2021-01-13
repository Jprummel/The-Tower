using DG.Tweening;

public class RapidFire : Ability
{
    public RapidFire()
    {
        AbilityName = AbilityNames.RAPID_FIRE;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 25;
        Cooldown = 4;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Rapid Fire!", 1.5f, "Rapid Fire");
            RapidFireSequence();
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Rapid Fire!" + ", but <color=grey>missed</color>!", 1.5f, "Rapid Fire");
        }
        BattleUI.s_UpdateBothInfo();
    }

    void RapidFireSequence()
    {
        Sequence RapidFireSequence = DOTween.Sequence();
        RapidFireSequence.AppendCallback(() => RapidFireShot());
        RapidFireSequence.AppendInterval(0.25f);
        RapidFireSequence.SetLoops(2);
    }

    void RapidFireShot()
    {
        if (CombatCalculations.s_Instance.CalculateIfHit(80)) { DealDamage(999, "Rapid Fire", CombatCalculations.s_Instance.CalculateDamage(0.9f), false); }
    }
}