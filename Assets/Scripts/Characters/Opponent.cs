using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : Character {

    public int XPToGive;
    public int GoldToGive;
    public int AdvanceToMaxFloor = 1;
    public float Range = 1.25f;
    public string EnemyRace;
    public string EnemyClass;
    public string EnemySpecials;
    public List<Ability> RaceAbilities;
    public List<Ability> ClassAbilities;
    public List<Ability> SpecialAbilities;

    public Opponent(Color color, string colorCode , int weaponID, int shieldID, int armorID, string name, int level, float maxHealth, float maxMana,int strength, int stamina, int agility, int intellect,int defense, int xpToGive,int goldTogive, int advanceToMaxFloor, string enemyRace, string enemyClass, string enemySpecials)
    {
        WeaponID = weaponID;
        ShieldID = shieldID;
        ArmorID = armorID;

        Weapon = EquipmentDictionaries.s_OpponentWeapons[weaponID];
        Shield = EquipmentDictionaries.s_Shields[shieldID];
        Armor = EquipmentDictionaries.s_Armors[armorID];

        CharacterColor = color;
        CharacterColorCode = colorCode;
        Name = name;
        Level = level;
        MaxHealth = maxHealth + Weapon.MaxHealthBonus + Shield.MaxHealthBonus + Armor.MaxHealthBonus;
        CurrentHealth = MaxHealth;
        MaxMana = maxMana;
        CurrentMana = MaxMana;
        Strength = strength + Weapon.StrengthBonus + Shield.StrengthBonus + Armor.StrengthBonus;
        Stamina = stamina;
        Agility = agility + Weapon.AgilityBonus + Shield.AgilityBonus + Armor.AgilityBonus;
        Intellect = intellect + Weapon.IntellectBonus + Shield.IntellectBonus + Armor.IntellectBonus;
        Defense = defense + +Weapon.DefenseBonus + Shield.DefenseBonus + Armor.DefenseBonus;
        XPToGive = xpToGive;
        GoldToGive = goldTogive;
        AdvanceToMaxFloor = advanceToMaxFloor;
        EnemyRace = enemyRace;
        EnemyClass = enemyClass;
        EnemySpecials = enemySpecials;
        RaceAbilities = AbilityTypeDictionary.s_AbilityTypes[EnemyRace];
        ClassAbilities = AbilityTypeDictionary.s_AbilityTypes[EnemyClass];
        SpecialAbilities = AbilityTypeDictionary.s_AbilityTypes[EnemySpecials];
    }
}