using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOpponent : MonoBehaviour
{
    public static LoadOpponent s_Instance;

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

    public void LoadRandomOpponentByLevel(Opponent opponentToLoad,int level)
    {
        //Opponent opponentToLoadTo = opponentToLoad;
        int randomEnemy = Random.Range(0, OpponentDictionary.s_Opponents[level].Count);
        Opponent opponent = OpponentDictionary.s_Opponents[level][randomEnemy];

        opponentToLoad.Name = opponent.Name;
        string colorCode = opponent.CharacterColorCode;
        ColorUtility.TryParseHtmlString(colorCode, out opponentToLoad.CharacterColor);
        opponentToLoad.CharacterColorCode = opponent.CharacterColorCode;
        opponentToLoad.Level = opponent.Level;
        opponentToLoad.MaxHealth = opponent.MaxHealth;
        opponentToLoad.CurrentHealth = opponent.CurrentHealth;
        opponentToLoad.MaxMana = opponent.MaxHealth;
        opponentToLoad.CurrentMana = opponent.CurrentHealth;
        opponentToLoad.Strength = opponent.Strength;
        opponentToLoad.Stamina = opponent.Stamina;
        opponentToLoad.Agility = opponent.Agility;
        opponentToLoad.Intellect = opponent.Intellect;
        opponentToLoad.Defense = opponent.Defense;
        opponentToLoad.XPToGive = opponent.XPToGive;
        opponentToLoad.GoldToGive = opponent.GoldToGive;
        opponentToLoad.AdvanceToMaxFloor = opponent.AdvanceToMaxFloor;
        opponentToLoad.EnemyRace = opponent.EnemyRace;
        opponentToLoad.EnemyClass = opponent.EnemyClass;
        opponentToLoad.EnemySpecials = opponent.EnemySpecials;
        opponentToLoad.WeaponID = opponent.WeaponID;
        opponentToLoad.Weapon = EquipmentDictionaries.s_Weapons[opponent.WeaponID];
    }
}
