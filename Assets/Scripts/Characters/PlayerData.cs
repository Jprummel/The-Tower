using UnityEngine;

[System.Serializable]
public class PlayerData : Character {

    public static PlayerData s_Instance;

    public float CurrentXP = 0;
    public float RequiredXP = 200;
    public float Gold;

    public int Wins;
    public int Losses;

    public int CurrentFloor;
    public int MaxFloor;
    public bool AdvanceFloor;

    public int AvailableStatPoints = 3;
    public int TotalEarnedStatPoints = 3;

    public int AvailableTalentPoints = 0;
    public int TotalEarnedTalentPoints = 0;

    private PlayerData m_Player;

	void Awake ()
    {
        //Create instance
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        CharacterColor = ColorConfig.ConvertHexColor(ColorConfig.RED);  
	}

    /// <summary>
    /// Set to false if you are creating a new character, true if it's a respec
    /// </summary>
    /// <param name="IsRespec"></param>
    public void SetStatsToDefault(bool IsRespec)
    {        
        Strength = 5;
        Stamina = 5;
        Agility = 5;
        Intellect = 5;

        CalculateStats.s_Instance.CalculateMaxHealth(PlayerData.s_Instance);
        CalculateStats.s_Instance.CalculateMaxMana(PlayerData.s_Instance);
        CurrentHealth = MaxHealth + MaxHealthBonus;
        CurrentMana = MaxMana + MaxManaBonus;
        if (IsRespec)
        { //Used to respec
            AvailableStatPoints = TotalEarnedStatPoints;
        }
        else
        { //Used to create new character
            Name = string.Empty;
            Level = 1;
            CurrentXP = 0;
            RequiredXP = 200;
            Gold = 0;
            AvailableStatPoints = 3;
            TotalEarnedStatPoints = AvailableStatPoints;
            AvailableTalentPoints = 0;
            TotalEarnedTalentPoints = AvailableTalentPoints;
            Weapon = EquipmentDictionaries.s_Weapons[0];
            Shield = EquipmentDictionaries.s_Shields[0];
            Armor = EquipmentDictionaries.s_Armors[0];
            AchievementDictionary.ResetAchievements();
            MaxHealthBonus = 0;
            MaxManaBonus = 0;
            PlayerPrefs.DeleteAll();
            Defense = 0;
            Wins = 0;
            Losses = 0;
            CurrentFloor = 1;
            MaxFloor = CurrentFloor;
        }
        if(StatPanel.s_Instance != null)
        {
            StatPanel.s_Instance.DisplayCurrentStats();
        }
    }

    public void AddStatPoints(int pointsToAdd)
    {
        AvailableStatPoints += pointsToAdd;
        TotalEarnedStatPoints += pointsToAdd;
    }

    public void AddTalentPoints(int pointsToAdd)
    {
        AvailableTalentPoints += pointsToAdd;
        TotalEarnedTalentPoints += pointsToAdd;
    }
}