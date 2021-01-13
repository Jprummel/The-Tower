using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trample : Ability
{
    public Trample()
    {
        AbilityName = AbilityNames.CHARGE;
        AbilityType = AbilityTypes.Ranged;
        Range = 4f;
        ManaCost = 10;
        Cooldown = 5;
        CastTime = 1.6f;
    }

    public override void AbilityEffect()
    {
        float tweenTime = Mathf.Clamp(Vector2.Distance(CombatTurns.s_Instance.ActiveCharacter.transform.position, CombatTurns.s_Instance.IdleCharacter.transform.position) / 10, 0.25f, 1.25f);

        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Trample!", 1f, "Trample");
        float position;

        if (!CombatTurns.s_Instance.ActiveCharacter.RightSide)
        {
            position = CombatTurns.s_Instance.IdleCharacter.transform.position.x - 1.24f;
        }
        else
        {
            position = CombatTurns.s_Instance.IdleCharacter.transform.position.x + 1.24f;
        }
        CombatTurns.s_Instance.ActiveCharacter.transform.DOMoveX(position, tweenTime).SetEase(Ease.InQuint).OnComplete(() => DealTrampleDamage());
    }

    private void DealTrampleDamage()
    {
        DealDamage(999, "Trample", CombatCalculations.s_Instance.CalculateDamage(1f), false);

        if(CombatCalculations.s_Instance.CalculateIfHit(66))
        {
            WaitToAddNotification("And applied a stun!", 1.5f, "Trample");
            Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 1, DebuffNames.Stun, "Stun");
        }
    }
}
