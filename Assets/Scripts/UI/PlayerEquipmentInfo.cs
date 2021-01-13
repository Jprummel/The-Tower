using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentInfo : MonoBehaviour {

    //Weapon Info
    [SerializeField] private Image m_WeaponIcon;
    [SerializeField] private Text m_WeaponName;
    [SerializeField] private Text m_WeaponType;
    [SerializeField] private Text m_WeaponRangeValue;
    [SerializeField] private Text m_WeaponStrengthValue;
    [SerializeField] private Text m_WeaponAgilityValue;
    [SerializeField] private Text m_WeaponIntellectValue;

    //Shield Info
    [SerializeField] private Image m_ShieldIcon;
    [SerializeField] private Text m_ShieldName;
    [SerializeField] private Text m_ShieldMaxHealthValue;
    [SerializeField] private Text m_ShieldDefenseValue;
    [SerializeField] private Text m_ShieldStrengthValue;
    [SerializeField] private Text m_ShieldAgilityValue;
    [SerializeField] private Text m_ShieldIntellectValue;


    //Armor Info
    [SerializeField] private Image m_ArmorIcon;
    [SerializeField] private Text m_ArmorName;
    [SerializeField] private Text m_ArmorMaxHealthValue;
    [SerializeField] private Text m_ArmorDefenseValue;
    [SerializeField] private Text m_ArmorStrengthValue;
    [SerializeField] private Text m_ArmorAgilityValue;
    [SerializeField] private Text m_ArmorIntellectValue;

    void OnEnable () {
        ShowShieldInfo();
        ShowWeaponInfo();
        ShowArmorInfo();
	}
	
    void ShowWeaponInfo()
    {
        m_WeaponIcon.sprite = Resources.Load<Sprite>("EquipmentIcons/Weapon/" + PlayerData.s_Instance.Weapon.ImageName);
        m_WeaponName.text = PlayerData.s_Instance.Weapon.Name;
        m_WeaponType.text = PlayerData.s_Instance.Weapon.WeaponType + ", " + PlayerData.s_Instance.Weapon.WeaponRangeType;
        m_WeaponRangeValue.text = PlayerData.s_Instance.Weapon.Range.ToString();
        m_WeaponStrengthValue.text = PlayerData.s_Instance.Weapon.StrengthBonus.ToString();
        m_WeaponAgilityValue.text = PlayerData.s_Instance.Weapon.AgilityBonus.ToString();
        m_WeaponIntellectValue.text = PlayerData.s_Instance.Weapon.IntellectBonus.ToString();
    }

    void ShowShieldInfo()
    {
        m_ShieldIcon.sprite = Resources.Load<Sprite>("EquipmentIcons/Shield/" + PlayerData.s_Instance.Shield.ImageName);
        m_ShieldName.text = PlayerData.s_Instance.Shield.Name;
        m_ShieldMaxHealthValue.text = PlayerData.s_Instance.Shield.MaxHealthBonus.ToString();
        m_ShieldDefenseValue.text = PlayerData.s_Instance.Shield.DefenseBonus.ToString();
        m_ShieldStrengthValue.text = PlayerData.s_Instance.Shield.StrengthBonus.ToString();
        m_ShieldAgilityValue.text = PlayerData.s_Instance.Shield.AgilityBonus.ToString();
        m_ShieldIntellectValue.text = PlayerData.s_Instance.Shield.IntellectBonus.ToString();
    }

    void ShowArmorInfo()
    {
        m_ArmorIcon.sprite = Resources.Load<Sprite>("EquipmentIcons/Armor/" + PlayerData.s_Instance.Armor.ImageName);
        m_ArmorName.text = PlayerData.s_Instance.Armor.Name;
        m_ArmorMaxHealthValue.text = PlayerData.s_Instance.Armor.MaxHealthBonus.ToString();
        m_ArmorDefenseValue.text = PlayerData.s_Instance.Armor.DefenseBonus.ToString();
        m_ArmorStrengthValue.text = PlayerData.s_Instance.Armor.StrengthBonus.ToString();
        m_ArmorAgilityValue.text = PlayerData.s_Instance.Armor.AgilityBonus.ToString();
        m_ArmorIntellectValue.text = PlayerData.s_Instance.Armor.IntellectBonus.ToString();
    }
}