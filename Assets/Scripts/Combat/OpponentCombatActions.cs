using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCombatActions : CombatActions {

    public override void MoveForward()
    {
        base.MoveForward();
    }

    public override void MoveBackwards()
    {
        base.MoveForward();
    }

    public override void Grapple()
    {
        base.Grapple();
    }

    public override void LightAttack()
    {
        base.LightAttack();
        BattleUI.s_UpdatePlayerInfo();
    }

    public override void NormalAttack()
    {
        base.NormalAttack();
        BattleUI.s_UpdatePlayerInfo();
    }

    public override void HeavyAttack()
    {
        base.HeavyAttack();
        BattleUI.s_UpdatePlayerInfo();
    }
}
