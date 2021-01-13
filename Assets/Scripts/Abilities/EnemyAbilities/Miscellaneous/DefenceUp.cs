using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceUp : Ability
{
    public DefenceUp()
    {
        AbilityName = AbilityNames.DEFENCE_UP;
        AbilityType = AbilityTypes.Buff;
        Range = 50f;
        ManaCost = 0;
        Cooldown = 99;
    }

    public override void AbilityEffect()
    {
        int armorValue = 30;

        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Defence Up!", 1f, "Defence Up");
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.ActiveCharacter,99, DebuffNames.DefenseBuff, "Defence Up", value: armorValue);
    }
}
