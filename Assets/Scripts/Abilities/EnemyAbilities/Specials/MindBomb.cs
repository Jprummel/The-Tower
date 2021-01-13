using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindBomb : Ability
{
    public MindBomb()
    {
        AbilityName = AbilityNames.MIND_BOMB;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 40;
        Cooldown = 2;
    }

    public override void AbilityEffect()
    {
        float damage = CombatTurns.s_Instance.ActiveCharacter.Intellect * 2;

        if (CombatCalculations.s_Instance.CalculateIfHit(95))
        {
            DealDamage(999, "Mind Bomb", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));

            if (CombatCalculations.s_Instance.CalculateIfHit(40))
            {
                WaitToAddNotification("And applied a stun!", 1.5f, "Mind Bomb");
                Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 1, DebuffNames.Stun, "Mind Bomb");
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Mind Bomb, but <color=grey>missed</color>!", 1.5f, "Mind Bomb");
        }
        BattleUI.s_UpdateEnemyInfo();
    }
}
