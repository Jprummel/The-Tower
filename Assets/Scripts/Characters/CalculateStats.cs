using UnityEngine;

public class CalculateStats : MonoBehaviour {

    public static CalculateStats s_Instance;
    
    public bool IsInRange;

    private void Awake()
    {
        if(s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CalculateMaxHealth(Character character)
    {
        character.MaxHealth = 50 + (character.Stamina * 10) + character.MaxHealthBonus;
    }

    public void CalculateMaxMana(Character character)
    {
        character.MaxMana = 10 + (character.Intellect * 5) + character.MaxManaBonus;
    }
}