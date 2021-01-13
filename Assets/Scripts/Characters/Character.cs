using UnityEngine;
using System.Collections.Generic;

public enum Classes
{
    Magician,
    Warrior,
    Ninja
}

public class Character : MonoBehaviour {

    //Character Basics
    public string Class;
    public Color CharacterColor;
    public string CharacterColorCode;
    public string Name;
    public int Level;
    public float MaxHealth;
    public float CurrentHealth;
    public float MaxMana;
    public float CurrentMana;
    public int Strength;
    public int Stamina;
    public int Agility;
    public int Intellect;
    public int Defense;

    public int MaxHealthBonus;
    public int MaxManaBonus;
    public int ShieldValue;

    public Shield Shield;
    public Weapon Weapon;
    public Armor Armor;
    public int WeaponID;
    public int ShieldID;
    public int ArmorID;

    public List<Debuff> ActiveDebuffs = new List<Debuff>();

    public bool Disabled = false;
    public bool CanMove = true;
    public bool CanAttack = true;
    public bool RightSide;
    public int ExtraDamage;
    public float DamageAmplifier = 1;
    public bool Immune = false;

    public void TakeDamage(int damage, bool canKill = true)
    {
        if (Immune)
            canKill = false;

        damage = Mathf.RoundToInt(damage * DamageAmplifier);

        float OGDamage = damage;

        if (ShieldValue > 0)
        {
            if (damage >= ShieldValue)
            {
                damage -= ShieldValue;
                ShieldValue = 0;
            }
            else
            {
                ShieldValue -= (int)damage;
                DamagePopup.s_Instance.PopupAnimation(transform.position, (int)OGDamage, !RightSide);
                return;
            }
            BattleUI.s_UpdateBothInfo();
        }

        if (!canKill)
        {
            if (CurrentHealth > damage)
                CurrentHealth = Mathf.Clamp(CurrentHealth -= damage, 1, int.MaxValue);
            else if (CurrentHealth > 1)
            {
                OGDamage = (int)CurrentHealth - 1;
                CurrentHealth = 1;
            }
            else
                OGDamage = 0;
        }
        else
            CurrentHealth -= damage;

        BattleUI.s_UpdateBothInfo();
        DamagePopup.s_Instance.PopupAnimation(transform.position, (int)OGDamage, !RightSide);
        TweenEffects.s_Instance.GetDamagedEffect(this);

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            CombatTurns.s_Instance.EndBattle();
        }
    }
}
