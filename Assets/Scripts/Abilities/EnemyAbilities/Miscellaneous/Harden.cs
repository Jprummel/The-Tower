using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harden : Ability
{
    public Harden()
    {
        AbilityName = AbilityNames.STONE_SKIN;
        AbilityType = AbilityTypes.Buff;
        Range = 1.25f;
        ManaCost = 15;
        Cooldown = 3;
        TurnsActive = 3;
    }

    public override void AbilityEffect()
    {
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Harden!", 1f, "Warrior");
        Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.ActiveCharacter, TurnsActive, DebuffNames.DamageReduction, "Warrior");
    }
}
