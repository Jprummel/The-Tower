using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypes
{
    Ranged,
    Melee,
    Any
}

public class EquipmentDictionaries : MonoBehaviour
{
    // ID, WeaponType,Name, Cost, ImageName, Range, StrengthBonus, AgilityBonus, IntellectBonus, FloorRequirement
    public static Dictionary<int, Weapon> s_Weapons = new Dictionary<int, Weapon>()
    {
        {0, new Weapon(0,       "Two-Handed", "Melee",  false, "Fists",            0,       "",                 1.25f,  0,   0,   0,   0) },
        {1, new Weapon(1,       "One-Handed", "Melee",  false, "Dagger",           250,     "Dagger",           1.35f,  1,   3,   1,   0) },
        {2, new Weapon(2,       "One-Handed", "Melee",  false, "Short Sword",      500,     "ShortSword",       1.45f,  3,   2,   1,   0) },
        {3, new Weapon(3,       "Two-Handed", "Melee",  false, "Bronze Axe",       750,     "BronzeAxe",        1.45f,  6,   0,   0,   0) },
        {4, new Weapon(4,       "One-Handed", "Melee",  false, "Scimitar",         1400,    "Scimitar",         1.5f,   12,  4,   3,   1) },
        {5, new Weapon(5,       "Two-Handed", "Melee",  true,  "Staff",            1800,    "Staff",            1.55f,  4,   4,   10,  1) },
        {6, new Weapon(6,       "Two-Handed", "Ranged", false, "Short Bow",        1500,    "ShortBow",         6f,     5,   10,  0,   1) },
        {7, new Weapon(7,       "Two-Handed", "Melee",  false, "Spear",            2100,    "Spear",            1.55f,  12,  7,   2,   2) },
        {8, new Weapon(8,       "Two-Handed", "Melee",  false, "Sai",              5000,    "Sai",              1.35f,  18,  10,  0,   3) },
        {9, new Weapon(9,       "One-Handed", "Melee",  false, "Kriss",            7500,    "Kriss",            1.4f,   24,  8,   0,   3) },
        {10, new Weapon(10,     "One-Handed", "Melee",  false, "Katana",           10000,   "Katana",           1.5f,   26,  6,   0,   3) },
        {11, new Weapon(11,     "One-Handed", "Melee",  true,  "Wand",             8000,    "Wand",             1.25f,  0,   6,   20,  3) },
        {12, new Weapon(12,     "Two-Handed", "Ranged", false, "Long Bow",         15000,   "LongBow",          8f,     20,  6,   0,   4) },
        {13, new Weapon(13,     "Two-Handed", "Melee",  false, "Trident",          15000,   "Trident",          1.8f,   35,  0,   0,   4) },
        {14, new Weapon(14,     "Two-Handed", "Melee",  false, "Claws",            15000,   "Claws",            1.3f,   25,  10,  0,   4) },
        {15, new Weapon(15,     "Two-Handed", "Ranged", false, "Kunai",            25000,   "Kunai",            5f,     40,  10,  0,   6) },
        {16, new Weapon(16,     "One-Handed", "Melee",  false, "Morning Star",     22500,   "MorningStar",      1.5f,   45,  3,   2,   6) },
        {17, new Weapon(17,     "Two-Handed", "Melee",  true,  "Sapphire Staff",   30000,   "SapphireStaff",    1.75f,  8,   2,   40,  6) },

        

    };

    ///ID, Name, ImageName, Bonus Health, Defense, Cost,Strength, Agility, Intellect, Required Floor
    public static Dictionary<int, Shield> s_Shields = new Dictionary<int, Shield>()
    {
        {0, new Shield(0,"None",                "none",             0,0,0,0,0,0,0)},
        {1, new Shield(1,"Wooden Shield",       "WoodenShield",     200,0,1,1,0,0,0) },
        {2, new Shield(2,"Buckler",             "Buckler",          400,0,3,0,1,0,0) },
        {3, new Shield(3,"Reinforced Shield",   "ReinforcedShield", 600,20,5,0,0,1,0) },
        {4, new Shield(4,"Lucky Shield",        "LuckyShield",      4000,100,8,0,0,0,2) },
        {5, new Shield(5,"Iron Buckler",        "IronBuckler",      12000,160,14,0,0,0,4) },
        {6, new Shield(6,"Metal Shield",        "MetalShield",      32000,260,22,0,0,0,6) },
        {7, new Shield(7,"Knight's Shield",     "KnightsShield",    50000,320,30,0,0,0,8) },
        {8, new Shield(8,"Beetle Shield",       "BeetleShield",     69000,480,38,0,0,0,10) },
        {9, new Shield(9,"Commander's Shield",  "CommandersShield", 85000,600,45,0,0,0,12) }
    };

    //ID, Name, ImageName, Max Health, Defense, Strength, Agility, Intellect, Required Floor cleared
    public static Dictionary<int, Armor> s_Armors = new Dictionary<int, Armor>()
    {
        {0,     new Armor(0,"None",                 "None",             0,0,0,0,0,0)},
        {1,     new Armor(1,"Apprentice Cloak",     "ApprenticeCloak",  0,1,0,0,0,3) },
        {2,     new Armor(2,"Leather Coat",         "LeatherCoat",      0,3,0,0,0,3) },
        {3,     new Armor(3,"Rogue Outfit",         "RogueOutfit",      20,5,0,0,0,3) },
        {4,     new Armor(4,"Guard Armor",          "GuardsArmor",      100,8,0,0,0,5) },
        {5,     new Armor(5,"Black Mage's Cloak",   "BlackMagesCloak",  160,14,0,0,0,7) },
        {6,     new Armor(6,"Mercenary Armor",      "MercenaryArmor",   260,22,0,0,0,9) },
        {7,     new Armor(7,"Berserker Armor",      "BerserkerArmor",   500,30,0,0,0,11) },
        {8,     new Armor(8,"Veteran Armor",        "VeteranArmor",     630,45,0,0,0,13) },
        {9,     new Armor(9,"Kings Guard Armor",    "KingsGuardArmor",  790,55,0,0,0,15) },
        {10,    new Armor(10,"Hero's Legacy",       "HerosLegacy",      1400,70,0,0,0,17) },
    };

    public static Dictionary<int, Weapon> s_OpponentWeapons = new Dictionary<int, Weapon>()
    {
        //Enemy weapons
        {0, new Weapon(0,   "Two-Handed", "Melee",  false,  "Fists",            0,      "",                 1.25f,0,0,0,0)},
        {1, new Weapon(1,   "Two-Handed", "Melee",  false,  "Beastly Claws",    0,      "",                 1.35f,0,0,0,0) },
        {2, new Weapon(2,   "Two-Handed", "Ranged", false,  "Bow",              0,      "",                 16f,0,0,0,0) },
        {3, new Weapon(3,   "Two-Handed", "Melee",  false,  "Fiend Tribe Sword",0,      "",                 1.55f,0,0,0,0) }
    };
}