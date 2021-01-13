using UnityEngine;

public class FrozenArmor : Ability
{
    public FrozenArmor()
    {
        AbilityName = AbilityNames.FROZEN_ARMOR;
        AbilityType = AbilityTypes.Buff;
        Range = 50f;
        ManaCost = 75;
        Cooldown = 5;
    }

    public override void AbilityEffect()
    {
        int armorValue;

        if (CombatTurns.s_Instance.ActiveCharacter == PlayerData.s_Instance)
        {
            armorValue = PlayerPrefs.GetInt("Frozen Armor Talent Level") * 15;
        }
        else
        {
            armorValue = 30;
        }
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Frozen Armor!", 1f, "Frozen Armor");
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.ActiveCharacter, 3, DebuffNames.DefenseBuff, "Frozen Armor", value: armorValue);
    }
}