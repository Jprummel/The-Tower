using UnityEngine;
using UnityEngine.UI;

public class LoadEquipmentInfo : MonoBehaviour
{
    public delegate void OnLoadEquipment(Equipment tempEquipment);
    public static OnLoadEquipment s_OnLoadEquipment;

    [SerializeField] private Text m_EquipmentName;
    [SerializeField] private Text m_CostValue;
    [SerializeField] private Text m_MaxHealthBonusValue;
    [SerializeField] private Text m_DefenseBonusValue;
    [SerializeField] private Text m_StrengthBonusValue;
    [SerializeField] private Text m_AgilityBonusValue;
    [SerializeField] private Text m_IntellectBonusValue;
    [SerializeField] private Text m_RequiredFloorClearedValue;
    //Only for weapons
    [SerializeField] private Text m_WeaponTypeValue;

    private void OnEnable()
    {
        ClearEquipmentInfo();
    }

    private void Awake()
    {
        s_OnLoadEquipment += SetEquipmentInfo;
    }

    void SetEquipmentInfo(Equipment tempEquipment)
    {
        m_EquipmentName.text = tempEquipment.Name;
        m_CostValue.text = tempEquipment.Cost.ToString();
        switch (tempEquipment.EquipmentType)
        {
            case EquipmentTypes.Weapon:
                CompareWeaponStats(tempEquipment);
                break;
            case EquipmentTypes.Shield:
                CompareShieldStats(tempEquipment);
                break;
            case EquipmentTypes.Armor:
                CompareArmorStats(tempEquipment);
                break;
        }
        m_RequiredFloorClearedValue.text = tempEquipment.RequiredFloorCleared.ToString();

        if(tempEquipment.EquipmentType == EquipmentTypes.Weapon && m_WeaponTypeValue != null)
        {
            m_WeaponTypeValue.text = tempEquipment.WeaponType + "," + tempEquipment.WeaponRangeType;
        }
        if (PlayerData.s_Instance.Gold < tempEquipment.Cost)
        {
            m_CostValue.color = Color.red;
        }
        else
        {
            m_CostValue.color = Color.green;
        }

        //Changes required floor cleared text color depending on players max floor reached
        if (PlayerData.s_Instance.MaxFloor < tempEquipment.RequiredFloorCleared)
        {
            m_RequiredFloorClearedValue.color = Color.red;
        }
        else
        {
            m_RequiredFloorClearedValue.color = Color.green;
        }
    }

    void ClearEquipmentInfo()
    {
        m_EquipmentName.text = "";
        m_CostValue.text = "";
        m_MaxHealthBonusValue.text = "";
        m_DefenseBonusValue.text = "";
        m_StrengthBonusValue.text = "";
        m_AgilityBonusValue.text = "";
        m_IntellectBonusValue.text = "";
        m_RequiredFloorClearedValue.text = "";
        if(m_WeaponTypeValue != null)
        {
            m_WeaponTypeValue.text = "";
        }
    }

    void CompareWeaponStats(Equipment tempEquipment)
    {
        CompareStats(PlayerData.s_Instance.Weapon.StrengthBonus, tempEquipment.StrengthBonus,m_StrengthBonusValue);
        CompareStats(PlayerData.s_Instance.Weapon.AgilityBonus, tempEquipment.AgilityBonus, m_AgilityBonusValue);
        CompareStats(PlayerData.s_Instance.Weapon.IntellectBonus, tempEquipment.IntellectBonus, m_IntellectBonusValue);
        CompareStats(PlayerData.s_Instance.Weapon.MaxHealthBonus, tempEquipment.MaxHealthBonus, m_MaxHealthBonusValue);
        CompareStats(PlayerData.s_Instance.Weapon.DefenseBonus, tempEquipment.DefenseBonus, m_DefenseBonusValue);
    }

    void CompareShieldStats(Equipment tempEquipment)
    {
        CompareStats(PlayerData.s_Instance.Shield.StrengthBonus, tempEquipment.StrengthBonus, m_StrengthBonusValue);
        CompareStats(PlayerData.s_Instance.Shield.AgilityBonus, tempEquipment.AgilityBonus, m_AgilityBonusValue);
        CompareStats(PlayerData.s_Instance.Shield.IntellectBonus, tempEquipment.IntellectBonus, m_IntellectBonusValue);
        CompareStats(PlayerData.s_Instance.Shield.MaxHealthBonus, tempEquipment.MaxHealthBonus, m_MaxHealthBonusValue);
        CompareStats(PlayerData.s_Instance.Shield.DefenseBonus, tempEquipment.DefenseBonus, m_DefenseBonusValue);
    }

    void CompareArmorStats(Equipment tempEquipment)
    {
        CompareStats(PlayerData.s_Instance.Armor.StrengthBonus, tempEquipment.StrengthBonus, m_StrengthBonusValue);
        CompareStats(PlayerData.s_Instance.Armor.AgilityBonus, tempEquipment.AgilityBonus, m_AgilityBonusValue);
        CompareStats(PlayerData.s_Instance.Armor.IntellectBonus, tempEquipment.IntellectBonus, m_IntellectBonusValue);
        CompareStats(PlayerData.s_Instance.Armor.MaxHealthBonus, tempEquipment.MaxHealthBonus, m_MaxHealthBonusValue);
        CompareStats(PlayerData.s_Instance.Armor.DefenseBonus, tempEquipment.DefenseBonus, m_DefenseBonusValue);
    }

    private Text CompareStats(int currentValue,int newValue, Text valueText)
    {
        if(currentValue < newValue)
        {
            valueText.text = currentValue + " >> " + "<color=#00ff00ff>" + newValue + "</color>"; //Turn new value green to indicate improvement
        }
        else if (currentValue > newValue)
        {
            valueText.text = currentValue + " >> " + "<color=#ff0000ff>" + newValue + "</color>"; //Turn new value red to indicate downgrade
        }
        else if(currentValue == newValue)
        {
            valueText.text = currentValue + " >> " + "<color=#000000ff>" + newValue + "</color>"; //Keep new value black to show it's the same
        }

        return valueText;
    }

    private void OnDestroy()
    {
        s_OnLoadEquipment -= SetEquipmentInfo;
    }
}