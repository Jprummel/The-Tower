using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadOpponents : MonoBehaviour {

    public static SaveLoadOpponents s_Instance;

	void Awake ()
    {
        Init();
	}

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void LoadRandomOpponentByLevel(Opponent opponent, int level = 1)
    {
        Opponent opponentToLoadTo = opponent;
        LitJson.JsonData OpponentJsonData = JsonManager.s_Instance.GetJsonData(FileNameConfig.OPPONENTLIBRARY);

        int randomOpponent = Random.Range(0, OpponentJsonData["Level" + level].Count);

        opponentToLoadTo.Name = (string)OpponentJsonData["Level" + level][randomOpponent]["Name"];
        string colorCode = (string)OpponentJsonData["Level" + level][randomOpponent]["CharacterColorCode"];
        ColorUtility.TryParseHtmlString(colorCode, out opponentToLoadTo.CharacterColor);
        opponentToLoadTo.CharacterColorCode = (string)OpponentJsonData["Level" + level][randomOpponent]["CharacterColorCode"];
        opponentToLoadTo.Level = (int)OpponentJsonData["Level" + level][randomOpponent]["Level"];
        opponentToLoadTo.MaxHealth = (float)(double)OpponentJsonData["Level" + level][randomOpponent]["MaxHealth"];
        opponentToLoadTo.CurrentHealth = (float)(double)OpponentJsonData["Level" + level][randomOpponent]["CurrentHealth"];
        opponentToLoadTo.MaxMana = (float)(double)OpponentJsonData["Level" + level][randomOpponent]["MaxMana"];
        opponentToLoadTo.CurrentMana = (float)(double)OpponentJsonData["Level" + level][randomOpponent]["CurrentMana"];
        opponentToLoadTo.Strength = (int)OpponentJsonData["Level" + level][randomOpponent]["Strength"];
        opponentToLoadTo.Stamina = (int)OpponentJsonData["Level" + level][randomOpponent]["Stamina"];
        opponentToLoadTo.Agility = (int)OpponentJsonData["Level" + level][randomOpponent]["Agility"];
        opponentToLoadTo.Intellect = (int)OpponentJsonData["Level" + level][randomOpponent]["Intellect"];
        opponentToLoadTo.Defense = (int)OpponentJsonData["Level" + level][randomOpponent]["Defense"];
        opponentToLoadTo.XPToGive = (int)OpponentJsonData["Level" + level][randomOpponent]["XPToGive"];
        opponentToLoadTo.GoldToGive = (int)OpponentJsonData["Level" + level][randomOpponent]["GoldToGive"];
        opponentToLoadTo.AdvanceToMaxFloor = (int)OpponentJsonData["Level" + level][randomOpponent]["AdvanceToNextFloor"];
    }

    public void LoadOpponentByID(Opponent opponent, int opponentID)
    {

        Opponent opponentToLoadTo = opponent;
        LitJson.JsonData OpponentJsonData = JsonManager.s_Instance.GetJsonData(FileNameConfig.OPPONENTLIBRARY);

        for (int i = 0; i < OpponentJsonData.Count; i++)
        {
            for (int j = 0; j < OpponentJsonData[i].Count; j++)
            {
                if (opponentID == (int)OpponentJsonData[i][j]["ID"])
                {
                    opponentToLoadTo.Name = (string)OpponentJsonData[i][j]["Name"];
                    string colorCode = (string)OpponentJsonData[i][j]["CharacterColorCode"];
                    ColorUtility.TryParseHtmlString(colorCode, out opponentToLoadTo.CharacterColor);
                    opponentToLoadTo.CharacterColorCode = (string)OpponentJsonData[i][j]["CharacterColorCode"];
                    opponentToLoadTo.Level = (int)OpponentJsonData[i][j]["Level"];
                    opponentToLoadTo.MaxHealth = (float)(double)OpponentJsonData[i][j]["MaxHealth"];
                    opponentToLoadTo.CurrentHealth = (float)(double)OpponentJsonData[i][j]["CurrentHealth"];
                    opponentToLoadTo.MaxMana = (float)(double)OpponentJsonData[i][j]["MaxMana"];
                    opponentToLoadTo.CurrentMana = (float)(double)OpponentJsonData[i][j]["CurrentMana"];
                    opponentToLoadTo.Strength = (int)OpponentJsonData[i][j]["Strength"];
                    opponentToLoadTo.Stamina = (int)OpponentJsonData[i][j]["Stamina"];
                    opponentToLoadTo.Agility = (int)OpponentJsonData[i][j]["Agility"];
                    opponentToLoadTo.Intellect = (int)OpponentJsonData[i][j]["Intellect"];
                    opponentToLoadTo.Defense = (int)OpponentJsonData[i][j]["Defense"];
                    opponentToLoadTo.XPToGive = (int)OpponentJsonData[i][j]["XPToGive"];
                    opponentToLoadTo.GoldToGive = (int)OpponentJsonData[i][j]["GoldToGive"];
                }
            }
        }
    }
}
