using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadPlayerData : MonoBehaviour {

    public static SaveLoadPlayerData s_Instance;

    private void Awake()
    {
        Init();        
    }

    private void Start()
    {
        if (PlayerData.s_Instance != null)
        {
            if (SceneManager.GetActiveScene().name != "Character Creation")
            {
                LoadPlayerData();
            }
        }
    }

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void SavePlayer()
    {
        JsonManager.s_Instance.WriteJson(FileNameConfig.PLAYERDATA, PlayerData.s_Instance);
    }

    public void LoadPlayerData()
    {
        LitJson.JsonData PlayerJsonData = JsonManager.s_Instance.GetJsonData(FileNameConfig.PLAYERDATA);
        PlayerData.s_Instance.Class = (string)PlayerJsonData["Class"];
        PlayerData.s_Instance.Name = (string)PlayerJsonData["Name"];
        string colorCode = (string)PlayerJsonData["CharacterColorCode"];
        ColorUtility.TryParseHtmlString(colorCode, out PlayerData.s_Instance.CharacterColor);
        PlayerData.s_Instance.CharacterColorCode = (string)PlayerJsonData["CharacterColorCode"];
        PlayerData.s_Instance.Level = (int)PlayerJsonData["Level"];
        PlayerData.s_Instance.Gold = (float)(double)PlayerJsonData["Gold"];
        PlayerData.s_Instance.MaxHealth = (float)(double)PlayerJsonData["MaxHealth"];
        PlayerData.s_Instance.MaxHealthBonus = (int)PlayerJsonData["MaxHealthBonus"];
        PlayerData.s_Instance.CurrentHealth = (float)(double)PlayerJsonData["CurrentHealth"];
        PlayerData.s_Instance.MaxMana = (float)(double)PlayerJsonData["MaxMana"];
        PlayerData.s_Instance.MaxManaBonus = (int)PlayerJsonData["MaxManaBonus"];
        PlayerData.s_Instance.CurrentMana = (float)(double)PlayerJsonData["CurrentMana"];
        PlayerData.s_Instance.Strength = (int)PlayerJsonData["Strength"];
        PlayerData.s_Instance.Stamina = (int)PlayerJsonData["Stamina"];
        PlayerData.s_Instance.Agility = (int)PlayerJsonData["Agility"];
        PlayerData.s_Instance.Intellect = (int)PlayerJsonData["Intellect"];
        PlayerData.s_Instance.Defense = (int)PlayerJsonData["Defense"];
        PlayerData.s_Instance.CurrentXP = (float)(double)PlayerJsonData["CurrentXP"];
        PlayerData.s_Instance.RequiredXP = (float)(double)PlayerJsonData["RequiredXP"];
        PlayerData.s_Instance.WeaponID = (int)PlayerJsonData["WeaponID"];
        PlayerData.s_Instance.ShieldID = (int)PlayerJsonData["ShieldID"];
        PlayerData.s_Instance.ArmorID = (int)PlayerJsonData["ArmorID"];
        PlayerData.s_Instance.AvailableStatPoints = (int)PlayerJsonData["AvailableStatPoints"];
        PlayerData.s_Instance.TotalEarnedStatPoints = (int)PlayerJsonData["TotalEarnedStatPoints"];
        PlayerData.s_Instance.AvailableTalentPoints = (int)PlayerJsonData["AvailableTalentPoints"];
        PlayerData.s_Instance.TotalEarnedTalentPoints = (int)PlayerJsonData["TotalEarnedTalentPoints"];
        PlayerData.s_Instance.Wins = (int)PlayerJsonData["Wins"];
        PlayerData.s_Instance.Losses = (int)PlayerJsonData["Losses"];
        PlayerData.s_Instance.CurrentFloor = (int)PlayerJsonData["CurrentFloor"];
        PlayerData.s_Instance.MaxFloor = (int)PlayerJsonData["MaxFloor"];
        PlayerData.s_Instance.Weapon = EquipmentDictionaries.s_Weapons[PlayerData.s_Instance.WeaponID];
        PlayerData.s_Instance.Armor = EquipmentDictionaries.s_Armors[PlayerData.s_Instance.ArmorID];
        PlayerData.s_Instance.Shield = EquipmentDictionaries.s_Shields[PlayerData.s_Instance.ShieldID];

        if (StatPanel.s_Instance != null)
        {
            StatPanel.s_Instance.DisplayCurrentStats();
        }
    }
}