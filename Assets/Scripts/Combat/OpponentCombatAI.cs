using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCombatAI : CombatActions {

    public delegate void ChooseOpponentAction();
    public static ChooseOpponentAction s_OnOpponentTurn;

    public delegate Transform GetOpponentTransform();
    public static GetOpponentTransform s_GetOpponentTransform;

    public delegate void ReduceCooldowns();
    public static ReduceCooldowns s_ReduceCooldowns;

    private Opponent m_Opponent;

    private int m_AbilityManaCost;
    private bool m_IsBuffed;
    private bool m_InBasicAttackRange;
    private WeaponTypes m_WeaponType;

    private List<Ability> m_AllOpponentAbilities = new List<Ability>();

    private List<Ability> m_Buffs = new List<Ability>();
    private List<Ability> m_RangedAttacks = new List<Ability>();
    private List<Ability> m_MeleeAttacks = new List<Ability>();

    private int m_TurnsBuffed;

    public static Dictionary<string, int> s_OpponentCooldowns = new Dictionary<string, int>();

    private void OnEnable()
    {
        s_OnOpponentTurn += CombatRoutine;
        s_GetOpponentTransform += GetTransform;
        s_ReduceCooldowns += ReduceOpponentCooldowns;
    }

    void Awake () {
        GetComponent<SpriteRenderer>().color = BattleUI.s_Opponent.CharacterColor;        
	}

    private void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        m_Opponent = CombatTurns.s_Instance.Opponent;
        SetWeaponType();
        AddAllAbilities();
        for (int i = 0; i < m_AllOpponentAbilities.Count; i++)
        {
            if (m_AllOpponentAbilities[i].AbilityType == Ability.AbilityTypes.Buff)
            {
                m_Buffs.Add(m_AllOpponentAbilities[i]);
            }
            if (m_AllOpponentAbilities[i].AbilityType == Ability.AbilityTypes.Ranged)
            {
                m_RangedAttacks.Add(m_AllOpponentAbilities[i]);
            }
            if (m_AllOpponentAbilities[i].AbilityType == Ability.AbilityTypes.Melee)
            {
                m_MeleeAttacks.Add(m_AllOpponentAbilities[i]);
            }
        }
    }

    void AddAllAbilities()
    {
        for (int i = 0; i < m_Opponent.RaceAbilities.Count; i++)
        {
            m_AllOpponentAbilities.Add(m_Opponent.RaceAbilities[i]);
        }

        for (int i = 0; i < m_Opponent.ClassAbilities.Count; i++)
        {
            m_AllOpponentAbilities.Add(m_Opponent.ClassAbilities[i]);
        }

        for (int i = 0; i < m_Opponent.SpecialAbilities.Count; i++)
        {
            m_AllOpponentAbilities.Add(m_Opponent.SpecialAbilities[i]);
        }
    }

    void SetWeaponType()
    {
        if (m_Opponent.Weapon.WeaponRangeType == WeaponTypes.Ranged.ToString())
            m_WeaponType = WeaponTypes.Ranged;
        else if (m_Opponent.Weapon.WeaponRangeType == WeaponTypes.Melee.ToString())
            m_WeaponType = WeaponTypes.Melee;
        else if (m_Opponent.Weapon.WeaponRangeType == WeaponTypes.Any.ToString())
            m_WeaponType = WeaponTypes.Any;
    }

    void CombatRoutine()
    {
        bool stunned = false;

        if (CombatCalculations.s_Instance.CalculateIfInRange(m_Opponent.Weapon.Range))
        {
            m_InBasicAttackRange = true;
        }
        else
            m_InBasicAttackRange = false;

        if (!m_Opponent.CanAttack && !m_Opponent.CanMove)
            stunned = true;

        if (!stunned)
        {
            //If the enemy has a buff ability, and is not already buffed, cast a buff;
            if (!m_IsBuffed && m_Buffs.Count > 0)
            {
                BuffUp();
                return;
            }
            //If the enemy has a ranged weapon, or if the enemy is not in attackrange(even melee weapons), the enemy will try to cast a ranged ability
            else if (m_WeaponType == WeaponTypes.Ranged || !m_InBasicAttackRange)
            {
                ChooseRandomRangedAbility();
                return;
            }
            //If the enemy has a melee weapon, and is in melee range, use a melee ability/attack
            else if (m_WeaponType == WeaponTypes.Melee && m_InBasicAttackRange)
            {
                ChooseRandomMeleeAbility();
                return;
            }
            else
            {
                MoveForward();
            }
        }
        else
        {
            CombatTurns.s_Instance.SwitchTurn();
        }
    }

    void BuffUp()
    {
        int RandomBuff = Random.Range(0, m_Buffs.Count);
        m_Buffs[RandomBuff].UseAbility();
        m_TurnsBuffed = m_Buffs[RandomBuff].TurnsActive + 1;
        m_IsBuffed = true;
    }

    void ChooseRandomBasicAttack()
    {
        switch (m_WeaponType)
        {
            case WeaponTypes.Ranged:
                Shoot();
                break;
            case WeaponTypes.Melee:
                RandomMeleeBasic();
                break;
            case WeaponTypes.Any:
                RandomAnyAttack();
                break;
        }
    }

    void RandomMeleeBasic()
    {
        //If Current Health:
        //25% or lower, Heavy attack.
        //40% or lower, Normal attack.
        //Else, Light attack.
        if (m_Opponent.CurrentHealth <= m_Opponent.MaxHealth / 100 * 25)
            HeavyAttack();
        else if (m_Opponent.CurrentHealth <= m_Opponent.MaxHealth / 100 * 40)
            NormalAttack();
        else
            LightAttack();
    }

    void RandomAnyAttack()
    {
        int RandomAttack = Random.Range(1, 2);

        switch (RandomAttack)
        {
            case 1:
                Shoot();
                break;
            case 2:
                RandomMeleeBasic();
                break;
        }
    }

    void ChooseRandomRangedAbility()
    {
        List<Ability> AvailableRangedAttacks = new List<Ability>();

        for (int i = 0; i < m_RangedAttacks.Count; i++)
        {
            if (!s_OpponentCooldowns.ContainsKey(m_RangedAttacks[i].AbilityName) && m_Opponent.CurrentMana >= m_RangedAttacks[i].ManaCost)
            {
                AvailableRangedAttacks.Add(m_RangedAttacks[i]);
            }
        }

        if (AvailableRangedAttacks.Count > 0)
        {
            int RandomRangedAbility = Random.Range(0, AvailableRangedAttacks.Count);

            AvailableRangedAttacks[RandomRangedAbility].UseAbility();
        }
        else if(m_InBasicAttackRange)
        {
            ChooseRandomBasicAttack();
        }
        else
        {
            if (m_Opponent.CanMove)
            {
                MoveForward();
            }
            else
            {
                CombatTurns.s_Instance.SwitchTurn();
            }
        }
    }

    void ChooseRandomMeleeAbility()
    {
        List<Ability> AvailableMeleeAttacks = new List<Ability>();

        for (int i = 0; i < m_MeleeAttacks.Count; i++)
        {
            if (!s_OpponentCooldowns.ContainsKey(m_MeleeAttacks[i].AbilityName) && m_Opponent.CurrentMana >= m_MeleeAttacks[i].ManaCost)
            {
                AvailableMeleeAttacks.Add(m_MeleeAttacks[i]);
            }
        }

        if (AvailableMeleeAttacks.Count > 0)
        {
            int RandomMeleeAbility = Random.Range(0, AvailableMeleeAttacks.Count);
            AvailableMeleeAttacks[RandomMeleeAbility].UseAbility();
        }
        else
        {
            ChooseRandomBasicAttack();
        }
    }

    public void ReduceOpponentCooldowns()
    {
        Dictionary<string, int> newCooldowns = new Dictionary<string, int>();

        foreach (var entry in s_OpponentCooldowns)
        {
            int cd = entry.Value - 1;
            newCooldowns.Add(entry.Key, cd);

            if (newCooldowns[entry.Key] == 0)
            {
                newCooldowns.Remove(entry.Key);
            }
        }
        s_OpponentCooldowns = newCooldowns;

        if (m_IsBuffed)
            m_TurnsBuffed--;
        if (m_TurnsBuffed <= 0)
            m_IsBuffed = false;

    }

    private Transform GetTransform()
    {
        return transform;
    }

    private void OnDisable()
    {
        s_OnOpponentTurn -= CombatRoutine;
    }
}