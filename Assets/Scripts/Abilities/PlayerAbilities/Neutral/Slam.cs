using UnityEngine;
using DG.Tweening;

public class Slam : Ability
{
    public Slam()
    {
        AbilityName = AbilityNames.SLAM;
        AbilityType = AbilityTypes.Melee;
        Range = 1.25f;
        ManaCost = 15;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            if (CombatCalculations.s_Instance.CalculateIfHit(80))
            {
                int talentLevel = PlayerPrefs.GetInt("Slam Talent Level");

                if (talentLevel == 1)
                    SpecialAttack(200, 1f, "Slam!");
                else if (talentLevel == 2)
                    SpecialAttack(200, 1.2f, "Slam!");
                else
                    SpecialAttack(200, 1f, "Slam!");

                if (!CombatTurns.s_Instance.ActiveCharacter.RightSide)
                    CombatTurns.s_Instance.IdleCharacter.transform.DOMoveX(CombatTurns.s_Instance.IdleCharacter.transform.position.x + 1, 0.5f);
                else
                    CombatTurns.s_Instance.IdleCharacter.transform.DOMoveX(CombatTurns.s_Instance.IdleCharacter.transform.position.x - 1, 0.5f);
            }
            else
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Slam!" + ", but <color=grey>missed</color>!", 1.5f, "Slam");
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + "Slam!" + ", but <color=grey>missed</color>!", 1.5f, "Slam");
        }
        base.AbilityEffect();
    }
}