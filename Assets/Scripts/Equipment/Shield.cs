public class Shield : Equipment
{
    public Shield(int id, string name, string imageName, int cost, int maxHealthBonus, int defenseBonus, int strengthBonus, int agilityBonus, int intellectBonus, int requiredFloorCleared)
    {
        EquipmentType = EquipmentTypes.Shield;
        ID = id;
        Name = name;
        ImageName = imageName;
        Cost = cost;
        MaxHealthBonus = maxHealthBonus;
        DefenseBonus = defenseBonus;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntellectBonus = intellectBonus;
        RequiredFloorCleared = requiredFloorCleared;
    }
}