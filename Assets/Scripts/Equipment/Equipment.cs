using UnityEngine;

public class Equipment : MonoBehaviour
{
    public EquipmentTypes EquipmentType;
    public int ID;
    public string Name;
    public int Cost;
    public string ImageName;
    public float Range;
    public int StrengthBonus;
    public int AgilityBonus;
    public int IntellectBonus;
    public int MaxHealthBonus;
    public int DefenseBonus;
    public int RequiredFloorCleared;

    //Weapons only
    public string WeaponType;
    public string WeaponRangeType;
    public bool IntScaling;
}
