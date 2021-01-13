using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityManager : MonoBehaviour
{
    public static Dictionary<string, int> s_PlayerCooldowns = new Dictionary<string, int>();

    public static PlayerAbilityManager s_Instance;

    [SerializeField] private List<GameObject> m_AbilityBoxes = new List<GameObject>();
    [SerializeField] private List<Image> m_ActiveAbilities = new List<Image>();
    private List<TalentData> m_PlayerAbilities = new List<TalentData>();
    public static List<TalentData> s_ActivePlayerAbilities = new List<TalentData>();
    public static List<TalentData> s_PlayerPassives = new List<TalentData>();
    private bool m_AddOrRemove;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
        
        SetPlayerAbilities();
        SetPassiveAbilities();
        FilterAbilities(1);
    }

    private void OnEnable()
    {
        GetAllPlayerAbilities();
    }

    private void GetAllPlayerAbilities()
    {
        List<TalentData> playerTalents = TalentManager.s_Instance.PlayerTalents;

        for (int i = 0; i < playerTalents.Count; i++)
        {
            if (playerTalents[i].IsActivatable)
                AddAbility(playerTalents[i]);
        }
    }

    private void DisableAllAbilityBoxes()
    {
        for (int i = 0; i < m_AbilityBoxes.Count; i++)
        {
            m_AbilityBoxes[i].SetActive(false);
        }
    }

    private void SetAllAbilityBoxes()
    {
        GetAllPlayerAbilities();

        for (int i = 0; i < m_PlayerAbilities.Count; i++)
        {
            GameObject currentBox = m_AbilityBoxes[i];
            currentBox.gameObject.name = m_PlayerAbilities[i].TalentName;
            Image abilityIcon = currentBox.GetComponentInChildren<Image>();
            abilityIcon.sprite = m_PlayerAbilities[i].TalentIcon;
            abilityIcon.name = m_PlayerAbilities[i].TalentName;

            currentBox.SetActive(true);
        }
    }

    private void SetAbilityBox(TalentData ability, int boxNumber)
    {
        GameObject currentBox = m_AbilityBoxes[boxNumber];
        currentBox.gameObject.name = ability.TalentName;
        Image abilityIcon = currentBox.GetComponentInChildren<Image>();
        abilityIcon.sprite = ability.TalentIcon;
        abilityIcon.name = ability.TalentName;

        currentBox.SetActive(true);
    }

    public void FilterAbilities(int value)
    {
        DisableAllAbilityBoxes();
        SetAllAbilities();
    }

    private void SetAbilityBoxesByClass(TalentClasses talentClass)
    {
        GetAllPlayerAbilities();

        for (int i = 0; i < m_PlayerAbilities.Count; i++)
        {
            if (m_PlayerAbilities[i].TalentClass == talentClass)
            {
                SetAbilityBox(m_PlayerAbilities[i], i);
            }
        }
    }

    private void SetAllAbilities()
    {
        GetAllPlayerAbilities();

        for (int i = 0; i < m_PlayerAbilities.Count; i++)
        {
            SetAbilityBox(m_PlayerAbilities[i], i);
        }
    }

    private void AddAbility(TalentData abilityToAdd)
    {
        if (!m_PlayerAbilities.Contains(abilityToAdd))
            m_PlayerAbilities.Add(abilityToAdd);
    }

    public void ReducePlayerCooldowns()
    {
        Dictionary<string, int> newCooldowns = new Dictionary<string, int>();

        foreach (var entry in s_PlayerCooldowns)
        {
            int cd = entry.Value - 1;
            newCooldowns.Add(entry.Key, cd);

            if (newCooldowns[entry.Key] == 0)
            {
                newCooldowns.Remove(entry.Key);
                ActionBar.s_Instance.RemoveUnavailableAction(entry.Key);
            }
        }
        s_PlayerCooldowns = newCooldowns;
    }

    public void SetPlayerAbilities()
    {
        GetAllPlayerAbilities();

        TalentData[] SortedSkills = new TalentData[7];

        for (int i = 0; i < m_PlayerAbilities.Count; i++)
        {
            if (PlayerPrefs.GetString(m_PlayerAbilities[i].TalentName + "Ability") == "True" && !s_ActivePlayerAbilities.Contains(m_PlayerAbilities[i]))
            {
                SortedSkills[PlayerPrefs.GetInt(m_PlayerAbilities[i].TalentName + "Position")] = m_PlayerAbilities[i];
            }
        }

        for (int i = 1; i < SortedSkills.Length; i++)
        {
            if (SortedSkills[i] != null)
                s_ActivePlayerAbilities.Add(SortedSkills[i]);
        }
        
        SetActiveAbilities();
    }

    private void SetActiveAbilities()
    {
        for (int i = 0; i < s_ActivePlayerAbilities.Count; i++)
        {
            m_ActiveAbilities[i].sprite = s_ActivePlayerAbilities[i].TalentIcon;
            m_ActiveAbilities[i].name = s_ActivePlayerAbilities[i].TalentName;
        }
    }

    public void SetPassiveAbilities()
    {
        for (int i = 0; i < TalentManager.s_AllPassives.Count; i++)
        {
            s_PlayerPassives.Add(TalentManager.s_AllPassives[i]);
        }
    }

    public void AddAbilityToActions(string abilityName)
    {
        for (int i = 0; i < m_PlayerAbilities.Count; i++)
        {
            if(s_ActivePlayerAbilities.Count < 6)
            {
                if (m_PlayerAbilities[i].TalentName == abilityName && !s_ActivePlayerAbilities.Contains(m_PlayerAbilities[i]))
                {
                    s_ActivePlayerAbilities.Add(m_PlayerAbilities[i]);
                    PlayerPrefs.SetString(m_PlayerAbilities[i].TalentName + "Ability", "True");
                    PlayerPrefs.SetInt(m_PlayerAbilities[i].TalentName + "Position", s_ActivePlayerAbilities.Count);
                    RefreshActiveAbilities();
                }
            }
            
        }
    }

    public void ReplaceAbility(string newAbility, string oldAbility)
    {
        for (int i = 0; i < s_ActivePlayerAbilities.Count; i++)
        {
            if (s_ActivePlayerAbilities[i].TalentName == oldAbility)
            {
                s_ActivePlayerAbilities[i] = TalentManager.s_Instance.GetTalentByName(newAbility);
                PlayerPrefs.SetString(oldAbility + "Ability", "False");
                PlayerPrefs.SetString(newAbility + "Ability", "True");
                PlayerPrefs.SetInt(newAbility + "Position", i + 1);
                RefreshActiveAbilities();
            }
        }
    }

    public void RemoveAbilityFromActions(string abilityName)
    {
        for (int i = 0; i < m_PlayerAbilities.Count; i++)
        {
            if (m_PlayerAbilities[i].TalentName == abilityName && s_ActivePlayerAbilities.Contains(m_PlayerAbilities[i]))
            {
                s_ActivePlayerAbilities.Remove(m_PlayerAbilities[i]);
                PlayerPrefs.SetString(m_PlayerAbilities[i].TalentName + "Ability", "False");
                RefreshActiveAbilities();
            }
        }
    }

    private void RefreshActiveAbilities()
    {
        for (int i = 0; i < m_ActiveAbilities.Count; i++)
        {
            m_ActiveAbilities[i].sprite = null;
            m_ActiveAbilities[i].name = "EmptySkill";
        }

        SetPlayerAbilities();
    }

    public void SetBool(bool toggleValue)
    {
        m_AddOrRemove = toggleValue;
    }
}
