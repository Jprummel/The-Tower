using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUp : Ability
{
    public ArmorUp()
    {
        AbilityName = AbilityNames.ARMOR_UP;
        AbilityType = AbilityTypes.Buff;
        Range = 1.25f;
        ManaCost = 10;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        int armorPercentage;

        if (CombatTurns.s_Instance.ActiveCharacter == PlayerData.s_Instance)
            armorPercentage = (PlayerPrefs.GetInt("Armor Up! Talent Level") * 25);
        else
            armorPercentage = 30;

        int armorValue = (int)(CombatTurns.s_Instance.ActiveCharacter.MaxHealth + CombatTurns.s_Instance.ActiveCharacter.MaxHealthBonus) / 100 * armorPercentage;

        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Armor Up!!", 1f, "ArmorUp!");

        CombatTurns.s_Instance.ActiveCharacter.ShieldValue += armorValue;

        BattleUI.s_UpdateBothInfo();
    }
}
