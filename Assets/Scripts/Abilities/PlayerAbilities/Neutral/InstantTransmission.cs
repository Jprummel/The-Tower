using UnityEngine;
using DG.Tweening;

public class InstantTransmission : Ability
{
    public InstantTransmission()
    {
        AbilityName = AbilityNames.INSTANT_TRANSMISSION;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 10;
        Cooldown = 3;
        CastTime = 1.5f;
    }

    public override void AbilityEffect()
    {
        SpriteRenderer sr = CombatTurns.s_Instance.ActiveCharacter.GetComponent<SpriteRenderer>();
        Sequence tpSequence = DOTween.Sequence();
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Instant Transmission!", 1f, "Instant Transmission");
        float position;
        sr.enabled = false;

        if (!CombatTurns.s_Instance.ActiveCharacter.RightSide)
        {
            position = CombatTurns.s_Instance.IdleCharacter.transform.position.x - 1.24f;
        }
        else
        {
            position = CombatTurns.s_Instance.IdleCharacter.transform.position.x + 1.24f;
        }
        tpSequence.AppendInterval(1f).OnComplete(() => SpecialAttack(150, 1f, "normal attack"));
        CombatTurns.s_Instance.ActiveCharacter.transform.DOMoveX(position, 0.5f).OnComplete(() => sr.enabled = true);
    }
}