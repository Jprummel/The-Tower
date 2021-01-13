using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Grab : Ability
{
    public Grab()
    {
        AbilityName = AbilityNames.GRAB;
        AbilityType = AbilityTypes.Ranged;
        Range = 20f;
        ManaCost = 20;
        Cooldown = 5;
        CastTime = 1.6f;
    }

    public override void AbilityEffect()
    {
        float tweenTime = Mathf.Clamp(Vector2.Distance(CombatTurns.s_Instance.ActiveCharacter.transform.position, CombatTurns.s_Instance.IdleCharacter.transform.position) / 10, 0.25f, 1.25f);

        StartAbility(false);
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Grab!", 1f, "Grab");
        float position;

        if (!CombatTurns.s_Instance.ActiveCharacter.RightSide)
        {
            position = CombatTurns.s_Instance.ActiveCharacter.transform.position.x + 1.24f;
        }
        else
        {
            position = CombatTurns.s_Instance.ActiveCharacter.transform.position.x - 1.24f;
        }
        CombatTurns.s_Instance.IdleCharacter.transform.DOMoveX(position, tweenTime).SetEase(Ease.OutExpo).OnComplete(() => DealDamage(999, "Charge", CombatCalculations.s_Instance.CalculateDamage(1f), false));
    }
}
