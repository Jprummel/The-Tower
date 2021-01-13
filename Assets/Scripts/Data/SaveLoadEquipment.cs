using UnityEngine;

public class SaveLoadEquipment : MonoBehaviour {

    public static SaveLoadEquipment s_Instance;

    private void Awake()
    {
        if(s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SaveEquipedWeapon()
    {
        PlayerData.s_Instance.WeaponID = PlayerData.s_Instance.Weapon.ID;
    }

    public void SaveEquipedShield()
    {
        PlayerData.s_Instance.ShieldID = PlayerData.s_Instance.Shield.ID;
    }

    public void SaveEquipedArmor()
    {
        PlayerData.s_Instance.ArmorID = PlayerData.s_Instance.Armor.ID;
    }

    public void LoadEquippedWeapon()
    {
        PlayerData.s_Instance.Weapon = EquipmentDictionaries.s_Weapons[PlayerData.s_Instance.WeaponID];
    }

    public void LoadEquippedShield()
    {
        PlayerData.s_Instance.Shield = EquipmentDictionaries.s_Shields[PlayerData.s_Instance.ShieldID];
    }

    public void LoadEquippedArmor()
    {
        PlayerData.s_Instance.Armor = EquipmentDictionaries.s_Armors[PlayerData.s_Instance.ArmorID];
    }
}