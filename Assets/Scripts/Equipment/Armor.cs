public class Armor : Equipment
{
    public Armor(int id, string name, string imageName, int maxHealthBonus, int defenseBonus, int strengthBonus, int agilityBonus, int intellectBonus, int requiredFloorCleared)
    {
        EquipmentType = EquipmentTypes.Armor;
        ID = id;
        Name = name;
        ImageName = imageName;
        MaxHealthBonus = maxHealthBonus;
        DefenseBonus = defenseBonus;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntellectBonus = intellectBonus;
        RequiredFloorCleared = requiredFloorCleared;
        Cost = (MaxHealthBonus * 150) + (DefenseBonus * 200);
    }
}