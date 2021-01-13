using UnityEngine;
using DG.Tweening;

public class Charge : Ability
{
    public Charge()
    {
        AbilityName = AbilityNames.CHARGE;
        AbilityType = AbilityTypes.Ranged;
        Range = 20f;
        ManaCost = 10;
        Cooldown = 5;
        CastTime = 1.6f;
    }

    public override void AbilityEffect()
    {
        float tweenTime = Mathf.Clamp(Vector2.Distance(CombatTurns.s_Instance.ActiveCharacter.transform.position, CombatTurns.s_Instance.IdleCharacter.transform.position) / 10, 0.25f, 1.25f);
        
        //StartAbility(false);
        AudioManager.s_Instance.PlaySoundEffect("Berserk");
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Charge!", 1f, "Charge");
        float position;

        if (!CombatTurns.s_Instance.ActiveCharacter.RightSide)
        {
            position = CombatTurns.s_Instance.IdleCharacter.transform.position.x - 1.24f;
        }
        else
        {
            position = CombatTurns.s_Instance.IdleCharacter.transform.position.x + 1.24f;
        }
        CombatTurns.s_Instance.ActiveCharacter.transform.DOMoveX(position, tweenTime).SetEase(Ease.InQuint).OnComplete(() => DealDamage(999, "Charge", CombatCalculations.s_Instance.CalculateDamage(0.8f), false));
    }
}