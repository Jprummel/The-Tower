using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoubleSwipe : Ability
{
    public DoubleSwipe()
    {
        AbilityName = AbilityNames.DOUBLE_SWIPE;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 10;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            float damage = CombatCalculations.s_Instance.CalculateDamage(0.7f);
            Sequence doubleStrikeSequence = DOTween.Sequence();
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Double Swipe!", 1.5f, "Double Swipe");
            DealDamage(200, "Light attack", damage, false);
            doubleStrikeSequence.AppendInterval(0.6f).OnComplete(() => DealDamage(999, "Light attack", damage, false));
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Double Swipe!" + ", but <color=grey>missed</color>!", 1.5f, "Double Swipe");
        }
    }
}
