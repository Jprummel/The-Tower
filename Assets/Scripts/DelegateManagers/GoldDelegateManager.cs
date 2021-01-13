using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDelegateManager : MonoBehaviour {

    

    public delegate void GoldManagement(int ChangeInGold);
    public delegate void GoldUI();
    public static GoldManagement s_ChangeGoldAmount;
    public static GoldUI s_UpdateGoldUI;

    private void Awake()
    {
        s_ChangeGoldAmount += ChangeGoldAmount;
    }

    void ChangeGoldAmount(int ChangeInGold)
    {
        PlayerData.s_Instance.Gold += ChangeInGold;
        if (s_UpdateGoldUI != null)
        {
            s_UpdateGoldUI();
        }
    }
}