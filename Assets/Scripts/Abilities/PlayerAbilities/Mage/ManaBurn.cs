using UnityEngine;

public class ManaBurn : Ability
{
    public ManaBurn()
    {
        AbilityName = AbilityNames.MANA_BURN;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 100;
        Cooldown = 5;
    }

    public override void AbilityEffect()
    {
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Mana Burn!", 1f, "Mana Burn");
        CombatTurns.s_Instance.IdleCharacter.CurrentMana = Mathf.Clamp(CombatTurns.s_Instance.IdleCharacter.CurrentMana - ((CombatTurns.s_Instance.IdleCharacter.MaxMana + CombatTurns.s_Instance.IdleCharacter.MaxManaBonus) / 100 * 40), 0, int.MaxValue);
        BattleUI.s_UpdateBothInfo();
    }
}