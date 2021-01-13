[System.Serializable]
public class Weapon : Equipment {

    public Weapon(int id, string weaponType,string weaponRangeType,bool intScaling, string name, int cost, string imageName, float range, int strengthBonus, int agilityBonus, int intellectBonus,int requiredFloorCleared)
    {
        EquipmentType = EquipmentTypes.Weapon;
        ID = id;
        WeaponType = weaponType;
        WeaponRangeType = weaponRangeType;
        IntScaling = intScaling;
        Name = name;
        Cost = cost;
        ImageName = imageName;
        Range = range;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntellectBonus = intellectBonus;
        RequiredFloorCleared = requiredFloorCleared;
    }
}