using UnityEngine;

public class CombatCalculations : MonoBehaviour {

    public static CombatCalculations s_Instance;
    
	void Awake () {
		if(s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    public bool CalculateIfHit(int BasicHitChance)
    {
        int MaxHitChance = BasicHitChance - CombatTurns.s_Instance.IdleCharacter.Agility;
        if (CombatTurns.s_Instance.IdleCharacter.Agility > 75)
        {
            MaxHitChance = 25;
        }
        int HitChance = Random.Range(0, 100);
        if (HitChance < MaxHitChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int CalculateMagicDamage(int damage)
    {
        int Damage = (int)Mathf.Clamp(damage - CombatTurns.s_Instance.IdleCharacter.Intellect * 1.5f, 0, int.MaxValue);
        return Damage;
    }

    public int CalculateDamage(float DamageMultiplier)
    {
        int Damage;

        if(CombatTurns.s_Instance.ActiveCharacter == PlayerData.s_Instance && !PlayerData.s_Instance.Weapon.IntScaling)
            Damage = Mathf.RoundToInt((CombatTurns.s_Instance.ActiveCharacter.Strength * 5) - (CombatTurns.s_Instance.IdleCharacter.Defense * 2));
        else if(CombatTurns.s_Instance.ActiveCharacter == PlayerData.s_Instance && PlayerData.s_Instance.Weapon.IntScaling)
            Damage = Mathf.RoundToInt((CombatTurns.s_Instance.ActiveCharacter.Intellect * 2) - (CombatTurns.s_Instance.IdleCharacter.Defense * 2));
        else
            Damage = Mathf.RoundToInt((CombatTurns.s_Instance.ActiveCharacter.Strength * 5) - (CombatTurns.s_Instance.IdleCharacter.Defense * 2));

        Damage = Mathf.RoundToInt(Damage * DamageMultiplier);
        if (Damage < 0) //Makes sure damage can't be negative (AKA Heal the enemy)
        {
            Damage = 0;
        }
        return Damage;
    }

    public int GetHitChance(int basicHitChance)
    {
        return basicHitChance - CombatTurns.s_Instance.IdleCharacter.Agility;
    }

    public float CurrentRange()
    {
        float Range = Vector2.Distance(CombatTurns.s_Instance.ActiveCharacter.transform.position, CombatTurns.s_Instance.IdleCharacter.transform.position);
        return Range;
    }

    public bool CalculateIfInRange(float range)
    {

        /*if (CombatTurns.s_Instance.ActiveCharacter == PlayerData.s_Instance)
            range = PlayerData.s_Instance.Weapon.Range;
        else
            range = 1.25f;
            */
        bool IsInRange;
        if(CurrentRange() <= range)
        {
            IsInRange = true;
        }
        else
        {
            IsInRange = false;
        }
        return IsInRange;
    }
}