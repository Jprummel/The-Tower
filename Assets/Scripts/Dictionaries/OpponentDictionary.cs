using System.Collections.Generic;
using UnityEngine;

public class OpponentDictionary : MonoBehaviour
{
    //new Opponent(Color.grey,ColorConfig.GREY,WeaponID,ShieldID,ArmorID,"Name",Level,MaxHealth,MaxMana,Strength,Stamina,Agility,Intellect,Defense,XP,Gold, MaxFloor)
    //Color, ColorCode, Name, Level, MaxHealth, MaxMana, Strength, Stamina, Agility, Intellect, Defense, XPValue, GoldValue, AdvanceToMaxFloor(Floor amount).
    public static Dictionary<int, List<Opponent>> s_Opponents = new Dictionary<int, List<Opponent>>
    {//                                             Max HP, Max MP, Str, Sta, Agi, Int, Def
        //Floor 1
        {1, new List<Opponent>
        {   //20 Points              
            new Opponent(Color.red,     ColorConfig.RED,    0,0,0,  "Peasant",          1,  50,25,    5,5,5,5,      0,200,50,   1,                  "None", "None", "None"),
            new Opponent(Color.black,   ColorConfig.BLACK,  1,0,0,  "Thug",             1,  50,25,    5,5,5,5,      0,200,50,   1,                  "None", "None", "None"),
            new Opponent(Color.green,   ColorConfig.GREEN,  0,0,0,  "Farmer",           1,  50,25,    5,5,5,5,      0,200,50,   1,                  "None", "None", "None")
        } },
        {2, new List<Opponent>
        {   //24 Points
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 2,1,0,  "Goblin",           2,  70,25,    7,7,5,5,      0,275,75,   1,                  "None", "None", "None"),
            new Opponent(Color.black,   ColorConfig.BLACK,  1,0,0,  "Giant Spider",     2,  90,25,    5,9,5,5,      0,275,75,   1,                  "None", "None", "None"),
            new Opponent(Color.green,   ColorConfig.GREEN,  0,0,0,  "Man Eating Plant", 2,  70,25,    8,7,4,5,      0,275,75,   1,                  "None", "None", "None")
        } },
        {3, new List<Opponent>
        {   //30 Points
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Hobgoblin",        3,  100,35,   9,10,5,5,     0,375,125,  1,                  EnemyRaces.ORC, "None", "None"),
            new Opponent(Color.white,   ColorConfig.WHITE,  2,2,0,  "Guard",            3,  110,35,   8,11,5,5,     5,375,125,  1,                  EnemyRaces.HUMANOID, "None", "None"),
            new Opponent(Color.grey,    ColorConfig.GREY,   1,0,0,  "Wolf",             3,  100,10,   8,10,8,2,     2,375,125,  1,                  EnemyRaces.BEAST, "None", "None")
        } },
        {4, new List<Opponent>
        {   //34 Points
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Robot",            4,  140,20,   9,14,5,4,     2,500,200,  1,                  EnemyRaces.ROBOT, "None", "None"),
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 1,0,0,  "Giant Centipede",  4,  120,35,   12,12,5,5,    0,500,200,  1,                  EnemyRaces.INSECT, "None", "None")
        } },
        {5, new List<Opponent>
        {   //37 Points
            new Opponent(Color.black,   ColorConfig.BLACK,  0,0,0,  "Gargoyle",         5,  220,0,    11,22,0,4,    10,800,500, 2,                  "None", "None", EnemySpecials.GARGOYLE)
        } },

        //Floor 2
        {6, new List<Opponent>
        {   //48 Points
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Troll",            6,  300,35,     15,30,1,0,        2,1000,600, 2,              EnemyRaces.ORC, "None", "None"),
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,2,  "Pirate",           6,  250,35,     18,25,5,0,        0,1000,600, 2,              EnemyRaces.HUMANOID, "None", EnemySpecials.PIRATE)
        } },
        {7, new List<Opponent>
        {   //54 Points
            new Opponent(Color.blue,    ColorConfig.BLUE,   0,0,0,  "Water Elemental",  7,  300,130,    5,30,1,18,0,      1200,700,   2,              EnemyRaces.ELEMENTAL, "None", EnemySpecials.WATER_ELEMENTAL),
            new Opponent(Color.red,     ColorConfig.RED,    0,0,0,  "Fire Elemental",   7,  250,130,    5,25,2,22,0,      1200,700,   2,              EnemyRaces.ELEMENTAL, "None", EnemySpecials.FIRE_ELEMENTAL),
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Earth Elemental",  7,  350,130,    0,35,2,0,19,      1200,700,   2,              EnemyRaces.ELEMENTAL, "None", EnemySpecials.EARTH_ELEMENTAL)
        } },
        {8, new List<Opponent>
        {   //62 Points
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Raptor",           8,  300,50,     22,30,10,0,0,     1500,800,   2,              EnemyRaces.DINOSAUR, "None", "None"),
            new Opponent(Color.red,     ColorConfig.RED,    0,0,0,  "Kobold",           8,  400,50,     5,40,1,16,0,      1500,800,   2,              EnemyRaces.ORC, EnemyClasses.MAGE, EnemySpecials.KOBOLD)
        } },
        {9, new List<Opponent>
        {   //68 Points
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,4,  "Animated Armor",   9,  450,50,     13,45,0,0,20,     1750,900,   2,              "None", "None", EnemySpecials.ANIMATED_ARMOR),
            new Opponent(Color.black,   ColorConfig.BLACK,  0,0,0,  "Assassin",         9,  300,35,     21,30,15,2,0,     1750,900,   2,              EnemyRaces.HUMANOID, EnemyClasses.NINJA, "None")
        } },
        {10, new List<Opponent>
        {   //100 Points
            new Opponent(Color.green,   ColorConfig.GREEN,  0,0,0,  "Slime",            10, 550,50,     10,55,0,25,10,    2000,1000,  3,              "None", "None", EnemySpecials.SLIME)
        } },

        //Floor 3
        {11, new List<Opponent>
        {   //110 Points
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Undead Horse",     11, 500,35,     30,50,20,0,10,    2250,1100,   3,               EnemyRaces.UNDEAD, "None", "None"),
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Undead Bear",      11, 600,35,     35,60,5,0,10,     2250,1100,   3,               EnemyRaces.UNDEAD, EnemyClasses.TANK, "None")
        } },
        {12, new List<Opponent>
        {   //120 Points
            new Opponent(Color.green,   ColorConfig.GREEN,  0,0,0,  "Centaur",          12, 600,35,     40,65,10,0,5,     2500,1200,   3,               "None", "None", EnemySpecials.CENTAUR),
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Chain Devil",      12, 500,35,     25,50,5,5,35,     2500,1200,   3,               EnemyRaces.HUMANOID, EnemyClasses.HELLISH, "None")
        } },
        {13, new List<Opponent>
        {   //130 Points
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Metal Golem",      13,750,30,      30,75,5,0,20,     3000,1500,   3,               EnemyRaces.GOLEM, EnemyClasses.TANK, "None"),
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Clay Golem",       13,650,35,      40,65,20,0,5,     2750,1500,   3,               EnemyRaces.GOLEM, EnemyClasses.TANK, "None"),
            new Opponent(Color.magenta, ColorConfig.MAGENTA,0,0,0,  "Arcane Golem",     13,550,100,     15,55,5,50,5,     2750,1500,   3,               EnemyRaces.GOLEM, EnemyClasses.MAGE, "None")
        } },
        {14, new List<Opponent>
        {   //140 Points
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Cockatrice",       14,700,35,      50,70,20,0,0,     3250,1750,   3,               EnemyRaces.BEAST, "None", EnemySpecials.FLYERS),
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Eagle",            14,700,35,      50,70,20,0,0,     3250,1750,   3,               EnemyRaces.BEAST, "None", EnemySpecials.FLYERS)
        } },
        {15, new List<Opponent>
        {   //180 Points
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Sphinx",           15,750,400,      50,75,15,40,0,    4000,2000,   4,               "None", "None", EnemySpecials.SPHINX)
        } },
        {16, new List<Opponent>
        {
            new Opponent(Color.magenta, ColorConfig.MAGENTA,0,0,0,  "Harpy",16,800,100,75,85,20,30,5,4250,2250, 4,                    EnemyRaces.HUMANOID, "None", "None"),
            new Opponent(Color.red,     ColorConfig.RED,    0,0,0,  "Hell Hound",16,850,35,75,95,30,5,5,4250,2250, 4,                 EnemyRaces.BEAST, EnemyClasses.HELLISH, "None")
        } },
        {17, new List<Opponent>
        {
            new Opponent(Color.blue,    ColorConfig.BLUE,   0,0,0,  "Killer Whale",17,1000,35,65,120,5,5,5,4500,2500, 4,              EnemyRaces.FISH, "None", "None"),
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Hunter Shark",17,900,35,75,95,20,5,5,4500,2500, 4,               EnemyRaces.FISH, "None", "None")
        } },
        {18, new List<Opponent>
        {
            new Opponent(Color.green,   ColorConfig.GREEN,  0,0,0,  "Toxic Lizard",18,1000,35,80,95,40,5,5,5000,2750, 4,              EnemyRaces.REPTILE, "None", "None"),
            new Opponent(Color.green,   ColorConfig.GREEN,  0,0,0,  "Giant Mantis",18,1000,35,80,95,40,5,5,5000,2750, 4,              EnemyRaces.INSECT, "None", "None")
        } },
        {19, new List<Opponent>
        {
            new Opponent(Color.white,   ColorConfig.WHITE,  0,0,0,  "Mummy",19,1100,35,85,120,5,5,5,5250,3000, 4,                     EnemyRaces.UNDEAD, "None", "None"),
            new Opponent(Color.black,   ColorConfig.BLACK,  0,0,0,  "Ghoul",19,1150,35,80,125,5,5,5,5250,3000, 4,                     EnemyRaces.UNDEAD, "None", "None")
        } },
        {20, new List<Opponent>
        {
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Kraken",20,1250,100,100,145,5,50,5,6000,4000, 5,                 EnemyRaces.BEAST, "None", EnemySpecials.KRAKEN)
        } },
        {21, new List<Opponent>
        {
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Iron Rabbit",21,1500,35,5,145,5,5,0,8000,0, 5,                   "None", "None", EnemySpecials.LOOTRABBIT)
        } },
        {22, new List<Opponent>
        {
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Copper Rabbit",22,1750,35,5,170,5,5,0,9000,0, 5,                 "None", "None", EnemySpecials.LOOTRABBIT)
        } },
        {23, new List<Opponent>
        {
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Bronze Rabbit",23,2000,35,5,195,5,5,0,10000,0, 5,                "None", "None", EnemySpecials.LOOTRABBIT)
        } },
        {24, new List<Opponent>
        {
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Silver Rabbit",24,2250,35,5,220,5,5,0,11000,0, 5,                "None", "None", EnemySpecials.LOOTRABBIT)
        } },
        {25, new List<Opponent>
        {
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Golden Rabbit",25,2500,35,5,245,5,5,0,12000,0, 6,                "None", "None", EnemySpecials.LOOTRABBIT)
        } },
        {26, new List<Opponent>
        {
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Lich",26,1000,100,105,125,5,50,5,8000,4100, 5,                   EnemyRaces.UNDEAD, "None", "None")
        } },
        {27, new List<Opponent>
        {
            new Opponent(Color.red,     ColorConfig.RED,    0,0,0,  "Fiend",27,1400,35,110,135,5,5,5,10000,4200, 5,                   "None", EnemyClasses.HELLISH, "None")
        } },
        {28, new List<Opponent>
        {
            new Opponent(Color.green,   ColorConfig.GREEN,  0,0,0,  "Undead Giant Cobra",28,1450,35,115,145,5,5,5,12000,4300, 5,      EnemyRaces.UNDEAD, "None", "None")
        } },
        {29, new List<Opponent>
        {
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Unfriendly Stegodon",29,1750,35,60,170,5,5,40,14000,4400, 5,     EnemyRaces.DINOSAUR, "None", "None")
        } },
        {30, new List<Opponent>
        {
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Djinnie",30,1650,150,75,160,5,100,5,20000,4500, 6,               "None", "None", EnemySpecials.DJINNIE)
        } },
        {31, new List<Opponent>
        {
           new Opponent(Color.blue,     ColorConfig.BLUE,   0,0,0,  "Murloc Tinyfin",31,1700,35,80,165,20,5,0,22000,4600, 6,          EnemyRaces.MURLOC, "None", "None")
        } },
        {32, new List<Opponent>
        {
            new Opponent(Color.grey,    ColorConfig.GREY,   0,0,0,  "Murloc Oracle",32,1750,200,60,170,30,125,0,24000,4700, 6,        EnemyRaces.MURLOC, EnemyClasses.MAGE, "None")
        } },
        {33, new List<Opponent>
        {
            new Opponent(Color.yellow,  ColorConfig.YELLOW, 0,0,0,  "Murloc Knight",33,1850,35,130,180,25,5,20,26000,4800, 6,         EnemyRaces.MURLOC, EnemyClasses.TANK, "None")
        } },
        {34, new List<Opponent>
        {
            new Opponent(Color.magenta, ColorConfig.MAGENTA,0,0,0,  "Murloc Warleader",34,1900,100,100,185,25,100,10,28000,4900, 6,   EnemyRaces.MURLOC, "None", "None")
        } },
        {35, new List<Opponent>
        {
            new Opponent(Color.black,   ColorConfig.BLACK,  0,0,0,  "Old Murk-Eye",35,2000,250,115,195,35,115,0,30000,5000, 7,        EnemyRaces.MURLOC, "None", EnemySpecials.OLDMURKEYE)
        } },
    };
}