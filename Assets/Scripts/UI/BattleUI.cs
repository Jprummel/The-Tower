using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {

    public delegate void UpdateInfo();
    public static UpdateInfo s_UpdatePlayerInfo;
    public static UpdateInfo s_UpdateEnemyInfo;
    public static UpdateInfo s_UpdateBothInfo;
    public static Opponent s_Opponent;

	[Header("PlayerUI")]
    [SerializeField] private Image m_PlayerIcon;
    [SerializeField] private Image m_PlayerHealthBar;
    [SerializeField] private Image m_PlayerShieldBar;
    [SerializeField] private Text m_PlayerHealthValue;
    [SerializeField] private Image m_PlayerManaBar;
    [SerializeField] private Text m_PlayerManaValue;

    [Header("OpponentUI")]
    [SerializeField] private Image m_OpponentIcon;
    [SerializeField] private Image m_OpponentHealthBar;
    [SerializeField] private Image m_OpponentShieldBar;
    [SerializeField] private Text m_OpponentHealthValue;
    [SerializeField] private Image m_OpponentManaBar;
    [SerializeField] private Text m_OpponentManaValue;

    private void OnEnable()
    {
        s_UpdateEnemyInfo += SetOpponentValues;
        s_UpdatePlayerInfo += SetPlayerValues;
        s_UpdateBothInfo += SetOpponentValues;
        s_UpdateBothInfo += SetPlayerValues;
    }

    private void Start()
    {
        SetPlayerValues();
        SetOpponentValues();
        SetIconColors();
    }

    void SetPlayerValues()
    {
        VitalsDisplay.s_Instance.DisplayShield(PlayerData.s_Instance, m_PlayerShieldBar);
        VitalsDisplay.s_Instance.DisplayHealth(PlayerData.s_Instance, m_PlayerHealthBar, m_PlayerHealthValue);
        VitalsDisplay.s_Instance.DisplayMana(PlayerData.s_Instance, m_PlayerManaBar, m_PlayerManaValue);
    }

    void SetOpponentValues()
    {
        VitalsDisplay.s_Instance.DisplayShield(s_Opponent, m_OpponentShieldBar);
        VitalsDisplay.s_Instance.DisplayHealth(s_Opponent, m_OpponentHealthBar, m_OpponentHealthValue);
        VitalsDisplay.s_Instance.DisplayMana(s_Opponent, m_OpponentManaBar, m_OpponentManaValue);
    }

    void SetIconColors()
    {
        m_PlayerIcon.color = PlayerData.s_Instance.CharacterColor;
        m_OpponentIcon.color = s_Opponent.CharacterColor;
    }

    private void OnDisable()
    {
        s_UpdateEnemyInfo -= SetOpponentValues;
        s_UpdatePlayerInfo -= SetPlayerValues;
        s_UpdateBothInfo -= SetOpponentValues;
        s_UpdateBothInfo -= SetPlayerValues;
    }
}