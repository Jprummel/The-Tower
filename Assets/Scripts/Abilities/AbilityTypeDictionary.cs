using System.Collections.Generic;
using UnityEngine;

public class AbilityTypeDictionary : MonoBehaviour
{
    public static Dictionary<string, List<Ability>> s_AbilityTypes = new Dictionary<string, List<Ability>>()
    {
        //No abilities
        {"None",  new List<Ability>
        { } },

        //[RACES]___________________________________________________________________________________________[RACES]

        //Human
        {EnemyRaces.HUMANOID,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.STAB],
        } },

        //Beast
        {EnemyRaces.BEAST,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.BITE],
        } },

        //Dinosaur
        {EnemyRaces.DINOSAUR,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.ROAR],
        } },

        //Elementals
        {EnemyRaces.ELEMENTAL,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.REFRESH],
        } },

        {EnemySpecials.WATER_ELEMENTAL,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.BLIZZARD],
        } },

        {EnemySpecials.FIRE_ELEMENTAL,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.FLAMESTRIKE],
        } },

        {EnemySpecials.EARTH_ELEMENTAL,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.ROCK_BLAST],
        } },

        //Insect
        {EnemyRaces.INSECT,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.STING],
        } },

        //Orc
        {EnemyRaces.ORC,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.SMASH],
        } },

        //Undead
        {EnemyRaces.UNDEAD,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.DEATH_AND_DECAY],
        } },

        //Golem
        {EnemyRaces.GOLEM,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.EARTHQUAKE],
        } },

        //Fish
        {EnemyRaces.FISH,  new List<Ability>
        {

        } },

        //Reptile
        {EnemyRaces.REPTILE,  new List<Ability>
        {

        } },

        //Plant
        {EnemyRaces.PLANT,  new List<Ability>
        {

        } },

        //Robot
        {EnemyRaces.ROBOT,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.GRAB],
        } },

        //Murloc
        {EnemyRaces.MURLOC,  new List<Ability>
        {

        } },

              
        
        //[CLASSES]___________________________________________________________________________________________[CLASSES]

        //Tank
        {EnemyClasses.TANK,   new List<Ability>
        {
          AbilityDictionary.s_Abilities[AbilityNames.ARMOR_UP],
          AbilityDictionary.s_Abilities[AbilityNames.SLAM] }
        },
        
        //Ninja
        {EnemyClasses.NINJA,  new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.INSTANT_TRANSMISSION],
            AbilityDictionary.s_Abilities[AbilityNames.PHANTOM_STRIKE]}
        },

        //Mage
        {EnemyClasses.MAGE,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.ENERGY_BOLT] }
        },

        //Hellish
        {EnemyClasses.HELLISH,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.HELLFIRE] }
        },


        //[SPECIALS]___________________________________________________________________________________________[SPECIALS]
        
        //Gargoyle
        {EnemySpecials.GARGOYLE,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.HARDEN],
            AbilityDictionary.s_Abilities[AbilityNames.DOUBLE_SWIPE],
        } },

        //Slime
        {EnemySpecials.SLIME,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.MIND_BOMB],
            AbilityDictionary.s_Abilities[AbilityNames.HIJACK],
        } },

        //Sphinx
        {EnemySpecials.SPHINX,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.REFRESH],
            AbilityDictionary.s_Abilities[AbilityNames.AERIAL_CUT],
            AbilityDictionary.s_Abilities[AbilityNames.ROAR],
            AbilityDictionary.s_Abilities[AbilityNames.BITE],
            AbilityDictionary.s_Abilities[AbilityNames.DOUBLE_SWIPE],
        } },

        //Kraken
        {EnemySpecials.KRAKEN,   new List<Ability>
        {

        } },

        //LootRabbit
        {EnemySpecials.LOOTRABBIT,   new List<Ability>
        {

        } },

        //Djinnie
        {EnemySpecials.DJINNIE,   new List<Ability>
        {

        } },

        //Old Murk-Eye
        {EnemySpecials.OLDMURKEYE,   new List<Ability>
        {

        } },

        //Pirate
        {EnemySpecials.PIRATE,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.PLUNDER],
        } },

        //Kobold
        {EnemySpecials.KOBOLD,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.SILENCE_BEAM],
        } },

        //Animated Armor
        {EnemySpecials.ANIMATED_ARMOR,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.DEFENCE_UP],
            AbilityDictionary.s_Abilities[AbilityNames.HARDEN],
        } },

        //Centaur
        {EnemySpecials.CENTAUR,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.TRAMPLE],
            AbilityDictionary.s_Abilities[AbilityNames.SHOOT],
        } },

        //Flyers
        {EnemySpecials.FLYERS,   new List<Ability>
        {
            AbilityDictionary.s_Abilities[AbilityNames.AERIAL_CUT],
        } },
    };
}
