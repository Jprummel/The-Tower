using UnityEngine;

public class CosmicRitual : Ability
{
    public CosmicRitual()
    {
        AbilityName = AbilityNames.COSMIC_RITUAL;
        AbilityType = AbilityTypes.Buff;
        Range = 50f;
        ManaCost = 15;
        Cooldown = 2;
    }

    public override void AbilityEffect()
    {
        int ExtraDamage;
        if (CombatTurns.s_Instance.ActiveCharacter == PlayerData.s_Instance)
        {
            ExtraDamage = (PlayerPrefs.GetInt("Cosmic Ritual Talent Level") * 25) + (CombatTurns.s_Instance.ActiveCharacter.Intellect * 2);
        }
        else
        {
            ExtraDamage = 40 + (CombatTurns.s_Instance.ActiveCharacter.Intellect * 2);
        }
        CombatTurns.s_Instance.ActiveCharacter.ExtraDamage = ExtraDamage;
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " enhanced their weapon with a magical force!", 1.5f, "Cosmic Ritual");
    }
}