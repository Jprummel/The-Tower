using System.Collections.Generic;
using UnityEngine;

public class SetOpponentValues : MonoBehaviour
{
    private Opponent m_Opponent;
    
    void Start()
    {
        m_Opponent = GetComponent<Opponent>();
        SetOpponentScriptValues();
    }

    void SetOpponentScriptValues()
    {
        //Gear and name
        m_Opponent.Name     = BattleUI.s_Opponent.Name;
        m_Opponent.Weapon   = BattleUI.s_Opponent.Weapon;
        m_Opponent.Shield   = BattleUI.s_Opponent.Shield;
        m_Opponent.Armor    = BattleUI.s_Opponent.Armor;
        //Vitals
        m_Opponent.MaxHealth        = BattleUI.s_Opponent.MaxHealth;
        m_Opponent.CurrentHealth    = BattleUI.s_Opponent.CurrentHealth;
        m_Opponent.MaxMana          = BattleUI.s_Opponent.MaxMana;
        m_Opponent.CurrentMana      = BattleUI.s_Opponent.CurrentMana;
        //Stats
        m_Opponent.Strength     = BattleUI.s_Opponent.Strength;
        m_Opponent.Stamina      = BattleUI.s_Opponent.Stamina;
        m_Opponent.Agility      = BattleUI.s_Opponent.Agility;
        m_Opponent.Intellect    = BattleUI.s_Opponent.Intellect;
        m_Opponent.Defense      = BattleUI.s_Opponent.Defense;
        //Combat rewards / progression
        m_Opponent.XPToGive             = BattleUI.s_Opponent.XPToGive;
        m_Opponent.GoldToGive           = BattleUI.s_Opponent.GoldToGive;
        m_Opponent.AdvanceToMaxFloor    = BattleUI.s_Opponent.AdvanceToMaxFloor;

        //Misc
        m_Opponent.CharacterColor   = BattleUI.s_Opponent.CharacterColor;
        m_Opponent.ActiveDebuffs    = new List<Debuff>();
        m_Opponent.EnemyRace        = BattleUI.s_Opponent.EnemyRace;
        m_Opponent.EnemyClass       = BattleUI.s_Opponent.EnemyClass;
        m_Opponent.EnemySpecials    = BattleUI.s_Opponent.EnemySpecials;
        m_Opponent.RaceAbilities    = AbilityTypeDictionary.s_AbilityTypes[m_Opponent.EnemyRace];
        m_Opponent.ClassAbilities   = AbilityTypeDictionary.s_AbilityTypes[m_Opponent.EnemyClass];
        m_Opponent.SpecialAbilities = AbilityTypeDictionary.s_AbilityTypes[m_Opponent.EnemySpecials];
        //Debug.Log(m_Opponent.EnemySpecials);
        m_Opponent.DamageAmplifier  = 1;

        BattleUI.s_Opponent = m_Opponent;
        CombatTurns.s_Instance.Opponent = m_Opponent;
    }
}