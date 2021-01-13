using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : Ability
{
    public Refresh()
    {
        AbilityName = AbilityNames.REFRESH;
        AbilityType = AbilityTypes.Ranged;
        Range = 99f;
        ManaCost = 20;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        Character ActiveCharacter = CombatTurns.s_Instance.ActiveCharacter;
        float HealthRestored = (ActiveCharacter.MaxHealth + ActiveCharacter.MaxHealthBonus) / 100 * 30;
        float hp = Mathf.Clamp(ActiveCharacter.CurrentHealth + HealthRestored, 0, ActiveCharacter.MaxHealth + ActiveCharacter.MaxHealthBonus);
        float healing = hp - ActiveCharacter.CurrentHealth;
        HealingPopup.s_Instance.PopupAnimation(ActiveCharacter.transform.position, (int)healing, !ActiveCharacter.RightSide);
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " Used Refresh, and restored <color=green>" + healing +"</color> health!", 1.5f, "Refresh");

        ActiveCharacter.CurrentHealth = hp;

        BattleUI.s_UpdateBothInfo();
    }
}
