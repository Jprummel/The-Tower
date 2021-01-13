using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPointAllocation : MonoBehaviour {

    public static StatPointAllocation s_Instance;
    [SerializeField] private List<GameObject> m_AddStatButtons = new List<GameObject>();

    public void Awake()
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

    private void Start()
    {
        StartCoroutine(LateStart());
    }

    public void ToggleButtons()
    {
        if (PlayerData.s_Instance.AvailableStatPoints > 0)
        {
            for (int i = 0; i < m_AddStatButtons.Count; i++)
            {
                m_AddStatButtons[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < m_AddStatButtons.Count; i++)
            {
                m_AddStatButtons[i].SetActive(false);
            }
        }
    }

    public void ShowButtons()
    {
        if(PlayerData.s_Instance.AvailableStatPoints > 0)
        {
            for (int i = 0; i < m_AddStatButtons.Count; i++)
            {
                m_AddStatButtons[i].SetActive(true);
            }
        }
    }

    public void HideButtons()
    {
        for (int i = 0; i < m_AddStatButtons.Count; i++)
        {
            m_AddStatButtons[i].SetActive(false);
        }
    }

    //Adds a point to the chosen stat
    public void AddPointToStat(int StatIndex)
    {
        if(PlayerData.s_Instance.AvailableStatPoints > 0) //Failsafe, if buttons don't disappear for whatever reason players can't keep adding stats
        {
            switch (StatIndex)
            {
                case 0:
                    PlayerData.s_Instance.Strength++;
                    break;
                case 1:
                    PlayerData.s_Instance.Stamina++;
                    CalculateStats.s_Instance.CalculateMaxHealth(PlayerData.s_Instance);
                    PlayerData.s_Instance.CurrentHealth += 10;
                    break;
                case 2:
                    PlayerData.s_Instance.Agility++;
                    break;
                case 3:
                    PlayerData.s_Instance.Intellect++;
                    CalculateStats.s_Instance.CalculateMaxMana(PlayerData.s_Instance);
                    PlayerData.s_Instance.CurrentMana += 5;
                    break;
            }
            PlayerData.s_Instance.AvailableStatPoints--;
            SaveLoadPlayerData.s_Instance.SavePlayer();
            StatPanel.s_Instance.UpdateStatPanel(false);
            if(PlayerData.s_Instance.AvailableStatPoints <= 0)
            {
                HideButtons();
            }
        }
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        ToggleButtons();
    }
}