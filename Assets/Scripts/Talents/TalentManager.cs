using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TalentManager : MonoBehaviour
{
    public static TalentManager s_Instance;

    [Header("Talent tree buttons")]
    public Button MagicianTreeButton;
    public Button NinjaTreeButton;
    public Button WarriorTreeButton;

    [Header("Talent tree outline parents")]
    //[SerializeField] private GameObject m_NeutralTalentOutlineParent;
    [SerializeField] private GameObject m_MagicianTalentOutlineParent;
    [SerializeField] private GameObject m_NinjaTalentOutlineParent;
    [SerializeField] private GameObject m_WarriorTalentOutlineParent;

    [Header("Talent tree outlines")]
    //private List<Image> m_NeutralTalentOutlines = new List<Image>();
    private List<Image> m_MagicianTalentOutlines = new List<Image>();
    private List<Image> m_NinjaTalentOutlines = new List<Image>();
    private List<Image> m_WarriorTalentOutlines = new List<Image>();

    private GameObject m_CurrentActiveOutlineParent;
    private string m_CurrentActiveTree = "None";
    [SerializeField] private List<TalentData> m_AllTalents = new List<TalentData>();
    private List<TalentData> m_PlayerTalents = new List<TalentData>();
    public static List<TalentData> s_AllAbilities = new List<TalentData>();
    public static List<TalentData> s_AllPassives = new List<TalentData>();

    public List<TalentData> PlayerTalents
    {
        get { return m_PlayerTalents; }
    }

    public string CurrentActiveTree
    {
        get { return m_CurrentActiveTree; }
        set { m_CurrentActiveTree = value; }
    }

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);

        GetAllAbilities();
        GetAllPlayerTalents();
        GetAllPassives();
        SetTreeButtons();
    }

    private void OnEnable()
    {
        switch (PlayerData.s_Instance.Class)
        {
            case "Magician":
                LearnTalent(GetTalentByID(8));
                MagicianTreeButton.interactable = true;
                MagicianTreeButton.onClick.Invoke();
                break;
            case "Warrior":
                LearnTalent(GetTalentByID(10));
                WarriorTreeButton.interactable = true;
                WarriorTreeButton.onClick.Invoke();
                break;
            case "Ninja":
                LearnTalent(GetTalentByID(9));
                NinjaTreeButton.interactable = true;
                NinjaTreeButton.onClick.Invoke();
                break;
        }
    }

    public void LearnTalent(TalentData talent)
    {
        if (Eligible(talent))
        {
            PlayerPrefs.SetString(talent.TalentName, talent.TalentName);
            AddTalent(talent);
        }
        else
            EligibilityPopup.s_Instance.PopupText();
    }

    public void SetAllPlayerTalents()
    {
        for (int i = 0; i < m_AllTalents.Count; i++)
        {
            string talent = PlayerPrefs.GetString(m_AllTalents[i].TalentName);
            if (talent != string.Empty)
            {
                AddTalent(m_AllTalents[i]);
            }
        }
    }

    public void AddTalentByID(int talentID)
    {
        TalentData talentToAdd = GetTalentByID(talentID);

        AddTalent(talentToAdd);
    }

    public void AddTalentByName(string talentName)
    {
        TalentData talentToAdd = GetTalentByName(talentName);

        AddTalent(talentToAdd);
    }

    public void AddTalent(TalentData talent)
    {
        string playerPrefPath = talent.TalentName + " Talent Level";

        if (!m_PlayerTalents.Contains(talent))
        {
            m_PlayerTalents.Add(talent);
            PlayerPrefs.SetInt(playerPrefPath, 1);
        }
        else
        {
            int currentLevel = PlayerPrefs.GetInt(playerPrefPath);
            int newLevel = Mathf.Clamp(currentLevel + 1, 1, talent.MaxTalentLevel);

            PlayerPrefs.SetInt(playerPrefPath, newLevel);
        }
    }

    public TalentData GetTalentByID(int talentID)
    {
        for (int i = 0; i < m_AllTalents.Count; i++)
        {
            if (m_AllTalents[i].TalentID == talentID)
                return m_AllTalents[i];
        }

        return null;
    }

    public TalentData GetTalentByName(string talentName)
    {
        for (int i = 0; i < m_AllTalents.Count; i++)
        {
            if (m_AllTalents[i].TalentName == talentName)
                return m_AllTalents[i];
        }

        return null;
    }

    private void GetAllPlayerTalents()
    {
        for (int i = 0; i < m_AllTalents.Count; i++)
        {
            string talent = PlayerPrefs.GetString(m_AllTalents[i].TalentName);

            if (talent != string.Empty && !m_PlayerTalents.Contains(m_AllTalents[i]))
            {
                m_PlayerTalents.Add(m_AllTalents[i]);
            }
        }
    }

    public bool Eligible(TalentData talent)
    {
        int requiredTalentID = talent.RequiredTalentID;

        if (requiredTalentID != 0)
        {
            for (int i = 0; i < m_PlayerTalents.Count; i++)
            {
                if (m_PlayerTalents[i].TalentID == requiredTalentID)
                    return true;
            }
        }
        else if (requiredTalentID == 0)
            return true;

        return false;
    }

    private void SetAllTalentOutlines(List<Image> outlines)
    {
        for (int i = 0; i < m_PlayerTalents.Count; i++)
        {
            int talentLevel = PlayerPrefs.GetInt(m_PlayerTalents[i].TalentName + " Talent Level");

            if(talentLevel > 0)
            {
                for (int j = 0; j < outlines.Count; j++)
                {
                    if(outlines[j].name == m_PlayerTalents[i].TalentName + "Outline")
                    {
                        float fill = (float)PlayerPrefs.GetInt(m_PlayerTalents[i].TalentName + " Talent Level") / m_PlayerTalents[i].MaxTalentLevel;
                        outlines[j].fillAmount = fill;
                    }
                }
            }
            else
            {
                for (int j = 0; j < outlines.Count; j++)
                {
                    if (outlines[j].name == m_PlayerTalents[i].TalentName + "Outline")
                    {
                        outlines[j].fillAmount = 0;
                    }
                }
            }
        }
    }

    public void SetTalentOutline(TalentData talent)
    {
        List<Image> outlines = GetActiveTreeOutlines();

        for (int i = 0; i < m_PlayerTalents.Count; i++)
        {
            for (int j = 0; j < outlines.Count; j++)
            {
                if (outlines[j].name == m_PlayerTalents[i].TalentName + "Outline")
                {
                    float fill = (float)PlayerPrefs.GetInt(m_PlayerTalents[i].TalentName + " Talent Level") / m_PlayerTalents[i].MaxTalentLevel;
                    outlines[j].DOFillAmount(fill, 0.25f);
                }
            }
        }
    }

    private List<Image> GetActiveTreeOutlines()
    {
        switch (m_CurrentActiveTree)
        {
            /*case "Neutral":
                m_CurrentActiveOutlineParent = m_NeutralTalentOutlineParent;
                return m_NeutralTalentOutlines;*/
            case "Magician":
                m_CurrentActiveOutlineParent = m_MagicianTalentOutlineParent;
                return m_MagicianTalentOutlines;
            case "Ninja":
                m_CurrentActiveOutlineParent = m_NinjaTalentOutlineParent;
                return m_NinjaTalentOutlines;
            case "Warrior":
                m_CurrentActiveOutlineParent = m_WarriorTalentOutlineParent;
                return m_WarriorTalentOutlines;
        }
        return null;
    }

    private void SetTreeButtons()
    {
        for (int i = 0; i < m_PlayerTalents.Count; i++)
        {
            if (m_PlayerTalents[i].TalentName == "Magician")
                MagicianTreeButton.interactable = true;

            if (m_PlayerTalents[i].TalentName == "Ninja")
                NinjaTreeButton.interactable = true;

            if (m_PlayerTalents[i].TalentName == "Warrior")
                WarriorTreeButton.interactable = true;
        }
    }

    public void SwitchTree(string tree)
    {
        m_CurrentActiveTree = tree;

        List<Image> outlines = GetActiveTreeOutlines();

        foreach (Transform transform in m_CurrentActiveOutlineParent.transform)
        {
            outlines.Add(transform.GetComponent<Image>());
        }

        SetAllTalentOutlines(outlines);
    }

    public bool HasAbility(string abilityName)
    {
        for (int i = 0; i < m_PlayerTalents.Count; i++)
        {
            if (m_PlayerTalents[i].TalentName == abilityName)
                return true;
        }

        return false;
    }

    private void GetAllAbilities()
    {
        for (int i = 0; i < m_AllTalents.Count; i++)
        {
            if (m_AllTalents[i].IsActivatable)
                s_AllAbilities.Add(m_AllTalents[i]);
        }
    }

    private void GetAllPassives()
    {
        for (int i = 0; i < m_PlayerTalents.Count; i++)
        {
            if (m_PlayerTalents[i].IsPassive)
                s_AllPassives.Add(m_PlayerTalents[i]);
        }
    }
}
