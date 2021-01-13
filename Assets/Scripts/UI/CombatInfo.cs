using UnityEngine;
using UnityEngine.UI;

public class CombatInfo : MonoBehaviour {

    public static CombatInfo s_Instance;

    public Opponent Opponent;

    [SerializeField]private GameObject m_CombatInfoPanel;

    //Player Info
    [Header("Player Info")]
    [SerializeField]private Text m_PlayerName;
    [SerializeField]private Image m_PlayerColor;
    [SerializeField] private Image m_PlayerXPBarFill;
    [SerializeField] private Image m_PlayerHPBarFill;
    [SerializeField] private Text m_PlayerHPValue;
    [SerializeField] private Text m_playerXPValues;
    [SerializeField] private Text m_PlayerLevel;

    [SerializeField]private Text m_PlayerStrength;
    [SerializeField]private Text m_PlayerStamina;
    [SerializeField]private Text m_PlayerAgility;
    [SerializeField]private Text m_PlayerIntellect;
    [SerializeField]private Text m_PlayerDefense;

    //Opponent Info
    [Header("Opponent Info")]
    [SerializeField] private Text m_OpponentName;
    [SerializeField] private Image m_OpponentColor;
    [SerializeField] private Text m_OpponentHPValue;
    [SerializeField] private Text m_OpponentXPValue;
    [SerializeField] private Text m_OpponentGoldValue;
    [SerializeField] private Text m_OpponentLevel;

    [SerializeField] private Text m_OpponentStrength;
    [SerializeField] private Text m_OpponentStamina;
    [SerializeField] private Text m_OpponentAgility;
    [SerializeField] private Text m_OpponentIntellect;
    [SerializeField] private Text m_OpponentDefense;

    private void Awake()
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

    public void ToggleInfo()
    {
        DisplayPlayerStats();
        DisplayOpponentStats();
        m_CombatInfoPanel.SetActive(!m_CombatInfoPanel.activeSelf);
    }

    public void DisplayPlayerStats()
    {
        m_PlayerName.text = PlayerData.s_Instance.Name;
        m_PlayerColor.color = PlayerData.s_Instance.CharacterColor;
        m_PlayerHPBarFill.fillAmount = (PlayerData.s_Instance.CurrentHealth / PlayerData.s_Instance.MaxHealth);
        m_PlayerHPValue.text = PlayerData.s_Instance.CurrentHealth + " / " + (PlayerData.s_Instance.MaxHealth + PlayerData.s_Instance.MaxHealthBonus);
        m_PlayerXPBarFill.fillAmount = (PlayerData.s_Instance.CurrentXP / PlayerData.s_Instance.RequiredXP);
        m_playerXPValues.text = PlayerData.s_Instance.CurrentXP + " / " + PlayerData.s_Instance.RequiredXP;
        m_PlayerLevel.text = "Lv " + PlayerData.s_Instance.Level;

        m_PlayerStrength.text = PlayerData.s_Instance.Strength.ToString();
        m_PlayerStamina.text = PlayerData.s_Instance.Stamina.ToString();
        m_PlayerAgility.text = PlayerData.s_Instance.Agility.ToString();
        m_PlayerIntellect.text = PlayerData.s_Instance.Intellect.ToString();
        m_PlayerDefense.text = PlayerData.s_Instance.Defense.ToString();
    }

    public void DisplayOpponentStats()
    {
        m_OpponentName.text = Opponent.Name;
        m_OpponentColor.color = Opponent.CharacterColor;
        m_OpponentHPValue.text = Opponent.CurrentHealth + " / " + (Opponent.MaxHealth + Opponent.MaxHealthBonus);
        m_OpponentXPValue.text = "XP Gain: " + Opponent.XPToGive;
        m_OpponentGoldValue.text = "Bounty: " + Opponent.GoldToGive + "G";
        m_OpponentLevel.text = "Lv " + Opponent.Level;
        m_OpponentStrength.text = Opponent.Strength.ToString();
        m_OpponentStamina.text = Opponent.Stamina.ToString();
        m_OpponentAgility.text = Opponent.Agility.ToString();
        m_OpponentIntellect.text = Opponent.Intellect.ToString();
        m_OpponentDefense.text = Opponent.Defense.ToString();
    }

    public void StartBattle()
    {
        BattleUI.s_Opponent = Opponent;
        SceneLoader.s_Instance.LoadSceneWithFade("Arena");
        ScreenEffects.s_Instance.FadeIn(0.5f);
    }
}