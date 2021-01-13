using UnityEngine;

public class EquipGear : MonoBehaviour {

    public static EquipGear s_Instance;
    
	void Awake () {
        
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

	}
	
	public void EquipShield(Shield NewShield, bool UnequipOldShield)
    {
        if(UnequipOldShield)
        {
            UnequipShield();
        }
        //Adds the stats of the new shield and sets the characters shield
        PlayerData.s_Instance.Shield.ID = NewShield.ID;
        PlayerData.s_Instance.Shield.Name = NewShield.Name;
        PlayerData.s_Instance.MaxHealthBonus += NewShield.MaxHealthBonus;
        PlayerData.s_Instance.Defense += NewShield.DefenseBonus;
        PlayerData.s_Instance.Strength += NewShield.StrengthBonus;
        PlayerData.s_Instance.Agility += NewShield.AgilityBonus;
        PlayerData.s_Instance.Intellect += NewShield.IntellectBonus;
        PlayerData.s_Instance.Shield = NewShield;
        SaveLoadEquipment.s_Instance.SaveEquipedShield();
    }

    public void EquipArmor(Armor NewArmor, bool UnequipOldArmor)
    {
        if (UnequipOldArmor)
        {
            UnequipArmor();
        }
        //Adds the stats of the new armor and sets the characters armor
        PlayerData.s_Instance.Armor.ID = NewArmor.ID;
        PlayerData.s_Instance.Armor.Name = NewArmor.Name;
        PlayerData.s_Instance.MaxHealthBonus += NewArmor.MaxHealthBonus;
        PlayerData.s_Instance.Defense += NewArmor.DefenseBonus;
        PlayerData.s_Instance.Strength += NewArmor.StrengthBonus;
        PlayerData.s_Instance.Agility += NewArmor.AgilityBonus;
        PlayerData.s_Instance.Intellect += NewArmor.IntellectBonus;
        PlayerData.s_Instance.Armor = NewArmor;
        SaveLoadEquipment.s_Instance.SaveEquipedArmor();
    }

    public void EquipWeapon(Weapon NewWeapon, bool UnequipOldWeapon)
    {
        if (UnequipOldWeapon)
        {
            UnequipWeapon();
        }        
        //Adds the stats of the new weapon and sets the characters weapon
        PlayerData.s_Instance.Strength += NewWeapon.StrengthBonus;
        PlayerData.s_Instance.Agility += NewWeapon.AgilityBonus;
        PlayerData.s_Instance.Intellect += NewWeapon.IntellectBonus;
        PlayerData.s_Instance.Defense += NewWeapon.DefenseBonus;
        PlayerData.s_Instance.MaxHealthBonus += NewWeapon.MaxHealthBonus;

        PlayerData.s_Instance.Weapon = NewWeapon;
        PlayerData.s_Instance.Weapon.ID = NewWeapon.ID;
        PlayerData.s_Instance.Weapon.Name = NewWeapon.Name;
        PlayerData.s_Instance.Weapon.WeaponType = NewWeapon.WeaponType;
        PlayerData.s_Instance.Weapon.WeaponRangeType = NewWeapon.WeaponRangeType;
        PlayerData.s_Instance.Weapon.Range = NewWeapon.Range;
        SaveLoadEquipment.s_Instance.SaveEquipedWeapon();
    }

    void UnequipWeapon()
    {
        //Remove weapon stats and unequips the weapon
        PlayerData.s_Instance.Strength -= PlayerData.s_Instance.Weapon.StrengthBonus;
        PlayerData.s_Instance.Agility -= PlayerData.s_Instance.Weapon.AgilityBonus;
        PlayerData.s_Instance.Intellect -= PlayerData.s_Instance.Weapon.IntellectBonus;
        PlayerData.s_Instance.Defense -= PlayerData.s_Instance.Weapon.DefenseBonus;
        PlayerData.s_Instance.MaxHealthBonus -= PlayerData.s_Instance.Weapon.MaxHealthBonus;
    }

    void UnequipShield()
    {
        //Removes shield stats and unequips the shield
        PlayerData.s_Instance.MaxHealthBonus -= PlayerData.s_Instance.Shield.MaxHealthBonus;
        PlayerData.s_Instance.Defense -= PlayerData.s_Instance.Shield.DefenseBonus;
        PlayerData.s_Instance.Strength -= PlayerData.s_Instance.Shield.StrengthBonus;
        PlayerData.s_Instance.Agility -= PlayerData.s_Instance.Shield.AgilityBonus;
        PlayerData.s_Instance.Intellect -= PlayerData.s_Instance.Shield.IntellectBonus;
    }

    void UnequipArmor()
    {
        //Removes shield stats and unequips the shield
        PlayerData.s_Instance.MaxHealthBonus -= PlayerData.s_Instance.Armor.MaxHealthBonus;
        PlayerData.s_Instance.Defense -= PlayerData.s_Instance.Armor.DefenseBonus;
        PlayerData.s_Instance.Strength -= PlayerData.s_Instance.Armor.StrengthBonus;
        PlayerData.s_Instance.Agility -= PlayerData.s_Instance.Armor.AgilityBonus;
        PlayerData.s_Instance.Intellect -= PlayerData.s_Instance.Armor.IntellectBonus;
    }
}