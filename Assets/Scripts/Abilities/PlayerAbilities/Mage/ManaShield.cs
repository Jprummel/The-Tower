using UnityEngine;

public class ManaShield : Ability
{
    public ManaShield()
    {
        AbilityName = AbilityNames.MANA_SHIELD;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 0;
        Cooldown = 5;
    }

    public override void AbilityEffect()
    {
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Mana Shield!", 1f, "Mana Shield");
        int shieldValue = (int)CombatTurns.s_Instance.ActiveCharacter.MaxMana + CombatTurns.s_Instance.ActiveCharacter.MaxManaBonus;
        Mathf.Clamp(CombatTurns.s_Instance.ActiveCharacter.CurrentMana -= shieldValue / 2, 0, int.MaxValue);
        CombatTurns.s_Instance.ActiveCharacter.ShieldValue = shieldValue;
        BattleUI.s_UpdateBothInfo();
    }
}