using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hijack : Ability
{
    private string m_Ability;

    public Hijack()
    {
        AbilityName = AbilityNames.HIJACK;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 0;
        Cooldown = 1;
        CastTime = 2.5f;
    }

    public override void AbilityEffect()
    {
        int randomNumber = Random.Range(0, PlayerAbilityManager.s_ActivePlayerAbilities.Count -1);
        m_Ability = PlayerAbilityManager.s_ActivePlayerAbilities[randomNumber].TalentName;

        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Hijack, and as a result...", 1f, "Hijack");

        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1f).OnComplete(Ability);
    }

    void Ability()
    {
        AbilityDictionary.s_UseAbilityByName(m_Ability, false, false);
    }
}
