using System.Collections.Generic;

public class AbilityDictionary
{
    public static Dictionary<string, Ability> s_Abilities = new Dictionary<string, Ability>()
    {
        //Neutral abilities
        {AbilityNames.COSMIC_RITUAL,        new CosmicRitual() },
        {AbilityNames.INSTANT_TRANSMISSION, new InstantTransmission() },
        {AbilityNames.SLAM,                 new Slam() },

        //Warrior abilities
        {AbilityNames.ARMOR_UP,             new ArmorUp() },
        {AbilityNames.CHARGE,               new Charge() },
        {AbilityNames.CRUSH,                new Crush() },
        {AbilityNames.DIVINE_BLESSING,      new DivineBlessing() },
        {AbilityNames.STONE_SKIN,           new StoneSkin() },

        //Ninja abilities
        {AbilityNames.ASSASSINATE,          new Assassinate() },
        {AbilityNames.BLEED,                new Bleed() },
        {AbilityNames.DISABLING_STRIKE,     new DisablingStrike() },
        {AbilityNames.DIVINE_ARROW,         new DivineArrow() },
        {AbilityNames.FROST_ARROW,          new FrostArrow() },
        {AbilityNames.LEECHING_STRIKE,      new LeechingStrike() },
        {AbilityNames.LIFE_FORCE_ARROW,     new LifeForceArrow() },
        {AbilityNames.PHANTOM_STRIKE,       new PhantomStrike() },
        {AbilityNames.RAPID_FIRE,           new RapidFire() },
        {AbilityNames.STEADY_SHOT,          new SteadyShot() },
        {AbilityNames.WEAKENING_STRIKE,     new WeakeningStrike() },

        //Mage abilities
        {AbilityNames.ENTOMB,               new Entomb() },
        {AbilityNames.FIREBALL,             new Fireball() },
        {AbilityNames.FROZEN_ARMOR,         new FrozenArmor() },
        {AbilityNames.IGNITE,               new Ignite() },
        {AbilityNames.LIFEDRAIN,            new LifeDrain() },
        {AbilityNames.LIGHTNING_BOLT,       new LightningBolt() },
        {AbilityNames.MANA_BLAST,           new ManaBlast() },
        {AbilityNames.MANA_BURN,            new ManaBurn() },
        {AbilityNames.MANA_SHIELD,          new ManaShield() },
        {AbilityNames.SHADOWBEAM,           new ShadowBeam() },
        {AbilityNames.WEAKEN,               new Weaken() },

        //Miscellaneous
        {AbilityNames.HARDEN,               new Harden()},
        {AbilityNames.ENERGY_BOLT,          new EnergyBolt()},
        {AbilityNames.DEFENCE_UP,           new DefenceUp()},

        //Humanoid abilities
        {AbilityNames.STAB,                 new Stab()},

        //Beast Abilities
        {AbilityNames.BITE,                 new Bite()},

        //Orc Abilities
        {AbilityNames.SMASH,                new Smash()},

        //Robot Abilities
        {AbilityNames.GRAB,                 new Grab()},

        //Insect Abilities
        {AbilityNames.STING,                new Sting()},

        //Hellish
        {AbilityNames.HELLFIRE,             new Hellfire()},

        //Golem
        {AbilityNames.EARTHQUAKE,           new Earthquake()},

        //Specials Abilities
        {AbilityNames.DOUBLE_SWIPE,         new DoubleSwipe()},
        {AbilityNames.PLUNDER,              new Plunder()},
        {AbilityNames.SILENCE_BEAM,         new SilenceBeam()},
        {AbilityNames.MIND_BOMB,            new MindBomb()},
        {AbilityNames.HIJACK,               new Hijack()},
        {AbilityNames.TRAMPLE,              new Trample()},
        {AbilityNames.SHOOT,                new Shoot()},
        {AbilityNames.AERIAL_CUT,           new AerialCut()},

        //Elemental Abilities
        {AbilityNames.REFRESH,              new Refresh()},

        {AbilityNames.BLIZZARD,             new Blizzard()},
        {AbilityNames.FLAMESTRIKE,          new Flamestrike()},
        {AbilityNames.ROCK_BLAST,           new RockBlast()},

        //Dinosaur Abilities
        {AbilityNames.ROAR,                 new Roar()},

        //Undead Abilities
        {AbilityNames.DEATH_AND_DECAY,      new DeathAndDecay()}, 
    };

    public static void s_UseAbilityByName(string abilityName, bool player = true, bool PassTurn = true)
    {
        s_Abilities[abilityName].UseAbility(PassTurn);
    }
}