using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentEffects : MonoBehaviour
{
    private void LearnTalent(TalentData talent)
    {
            PlayerData.s_Instance.AvailableTalentPoints--;
            TalentPointDisplay.s_Instance.ShowAvailableTalentPoints();
            SaveLoadPlayerData.s_Instance.SavePlayer();
            TalentManager.s_Instance.LearnTalent(talent);
            TalentManager.s_Instance.SetTalentOutline(talent);
            TalentInfo.s_OnUpdateTalentUI(talent);
    }

    //Neutral
    public void Brute(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.Strength += 5;
            LearnTalent(talent);
        }
    }

    public void AnimalInstinct(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.Agility += 5;
            LearnTalent(talent);
        }
    }

    public void Arcanist(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.Intellect += 5;
            CalculateStats.s_Instance.CalculateMaxMana(PlayerData.s_Instance);
            LearnTalent(talent);
        }
    }

    public void Juggernaut(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.Stamina += 5;
            CalculateStats.s_Instance.CalculateMaxHealth(PlayerData.s_Instance);
            LearnTalent(talent);
        }
    }

    public void CosmicRitual(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void InstantTransmission(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Slam(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Magician(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.Intellect += 10;
            LearnTalent(talent);
            TalentManager.s_Instance.MagicianTreeButton.interactable = true;
        }
    }

    public void Ninja(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.Agility += 10;
            LearnTalent(talent);
            TalentManager.s_Instance.NinjaTreeButton.interactable = true;
        }
    }

    public void Warrior(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.Strength += 5;
            PlayerData.s_Instance.Stamina += 5;
            CalculateStats.s_Instance.CalculateMaxHealth(PlayerData.s_Instance);

            LearnTalent(talent);
            TalentManager.s_Instance.WarriorTreeButton.interactable = true;
        }
    }

    //Magician
    public void LightningBolt(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Entomb(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Weaken(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void FrozenArmor(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void ManaBurn(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void ManaBlast(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void ManaShield(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Fireball(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void ManaFlow(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.MaxManaBonus += 75;
            LearnTalent(talent);
        }
    }

    public void Ignite(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void UpgradeFireball(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void UpgradeLightningbolt(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void LifeDrain(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void ShadowBeam(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    //Ninja
    public void PhantomStrike(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void SteadyShot(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void FrostArrow(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void LifeForceArrow(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void RapidFire(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void DivineArrow(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Bleed(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void DisablingStrike(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Mercy(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Assassinate(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void LeechingStrike(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void WeakeningStrike(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    //Warrior
    public void ArmorUp(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Rage(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Berserk(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void StoneSkin(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void Crush(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void FighterSpirit(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            PlayerData.s_Instance.MaxHealthBonus += 75;
            LearnTalent(talent);
        }
    }

    public void Charge(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }

    public void DivineBlessing(TalentData talent)
    {
        if (PlayerData.s_Instance.AvailableTalentPoints > 0 && PlayerPrefs.GetInt(talent.TalentName + " Talent Level") < talent.MaxTalentLevel && TalentManager.s_Instance.Eligible(talent))
        {
            LearnTalent(talent);
        }
    }
}
