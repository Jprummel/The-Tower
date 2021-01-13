using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StatPanel : MonoBehaviour {

    public static StatPanel s_Instance;

    //Player Info
    [Header("Player Info")]
    [SerializeField] private Text m_CharacterName;
    [SerializeField] private Text m_LevelValue;
    [SerializeField] private Text m_XPValue;
    [SerializeField] private Image m_XPBarFill;
    [SerializeField] private Text m_WinsAndLosses;
    [SerializeField] private Text m_WinRatio;

    //Player Vitals
    [Header("Vitals")]
    [SerializeField] private Image m_HealtBarFill;
    [SerializeField] private Text m_HealthValue;
    [SerializeField] private Image m_ManaBarFill;
    [SerializeField] private Text m_ManaValue;

    //Stat Values
    [Header("Stats")]
    [SerializeField] private Text m_StrengthValue;
    [SerializeField] private Text m_StaminaValue;
    [SerializeField] private Text m_AgilityValue;
    [SerializeField] private Text m_IntellectValue;
    [SerializeField] private Text m_DefenseValue;

    [SerializeField] private Text m_AvailableTalentPoints;
    [SerializeField] private Text m_AvailableStatPoints;

	void Awake () {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateStatPanel(bool isCompletePanel)
    {
        DisplayCurrentStats();
        DisplayStatPoints();
        if (isCompletePanel)
        {
            ShowPlayerInfo();
            m_XPBarFill.fillAmount = PlayerData.s_Instance.CurrentXP / PlayerData.s_Instance.RequiredXP;
        }
        if (VitalsDisplay.s_Instance != null)
        {
            VitalsDisplay.s_Instance.DisplayHealth(PlayerData.s_Instance, m_HealtBarFill, m_HealthValue);
            VitalsDisplay.s_Instance.DisplayMana(PlayerData.s_Instance, m_ManaBarFill, m_ManaValue);
        }

    }

    public void DisplayCurrentStats()
    {
        m_StrengthValue.text = PlayerData.s_Instance.Strength.ToString();
        m_StaminaValue.text = PlayerData.s_Instance.Stamina.ToString();
        m_AgilityValue.text = PlayerData.s_Instance.Agility.ToString();
        m_IntellectValue.text = PlayerData.s_Instance.Intellect.ToString();
        m_DefenseValue.text = PlayerData.s_Instance.Defense.ToString();

        if(m_WinsAndLosses != null)
            m_WinsAndLosses.text = "Win/Lose (" + PlayerData.s_Instance.Wins + "/" + PlayerData.s_Instance.Losses + ")";

        if (PlayerData.s_Instance.Wins > 0)
        {
            float winrate = (float)PlayerData.s_Instance.Wins / ((float)PlayerData.s_Instance.Wins + (float)PlayerData.s_Instance.Losses) * 100;

            if(m_WinRatio != null)
                m_WinRatio.text = "(" + winrate.ToString("#.0") + "%)";
        }

        ShowXPBar();
    }

    

    public void DisplayStatPoints()
    {
        if (PlayerData.s_Instance.AvailableStatPoints > 0)
        {
            m_AvailableStatPoints.gameObject.SetActive(true);
            m_AvailableStatPoints.text = "Available stat Points : " + PlayerData.s_Instance.AvailableStatPoints;
        }
        else
        {
            m_AvailableStatPoints.gameObject.SetActive(false);
        }
    }

    public void ShowPlayerInfo()
    {
        m_CharacterName.text = PlayerData.s_Instance.Name;
        m_LevelValue.text = "Lv. " + PlayerData.s_Instance.Level;
        m_XPValue.text = PlayerData.s_Instance.CurrentXP + " / " + PlayerData.s_Instance.RequiredXP;
        
    }

    public void ShowXPBar()
    {
        m_XPBarFill.DOFillAmount(PlayerData.s_Instance.CurrentXP / PlayerData.s_Instance.RequiredXP, 0.3f);
    }

    public void ToggleStatPanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf == true)
        {
            UpdateStatPanel(true);
        }
    }
}