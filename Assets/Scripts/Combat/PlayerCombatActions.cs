public class PlayerCombatActions : CombatActions {

    public override void MoveForward()
    {
        base.MoveForward();
        ActionSelected();
    }

    public override void MoveBackwards()
    {
        base.MoveBackwards();
        ActionSelected();
    }

    public override void Grapple()
    {
        base.Grapple();
        ActionSelected();
    }

    public override void LightAttack()
    {
        base.LightAttack();
        ActionSelected();
    }

    public override void NormalAttack()
    {
        base.NormalAttack();
        ActionSelected();
    }

    public override void HeavyAttack()
    {
        base.HeavyAttack();
        ActionSelected();
    }

    public override void Attack(int hitChance, float damageModifier, string attackName, float bonusDamage = 0f)
    {
        base.Attack(hitChance, damageModifier, attackName);
        BattleUI.s_UpdateEnemyInfo();
        ActionSelected();
    }
}