using UnityEngine;
using UnityEngine.UI;

public class EndOfCombatPopups : MonoBehaviour {

    public static EndOfCombatPopups s_Instance;

    [SerializeField] private Text m_VictoryTextXP;
    [SerializeField] private Text m_VictoryTextGold;
    [SerializeField] private Text m_DefeatTextGold;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetVictoryText(float xp, float gold)
    {
        m_VictoryTextXP.text = "You've gained <color=#3539CCFF>" + xp + " </color> experience points,";
        m_VictoryTextGold.text = "and <color=#FFD700>" + gold + "</color> gold pieces.";
    }

    public void SetDefeatText(float gold)
    {
        m_DefeatTextGold.text = "You've lost <color=#FA2020>" + gold + "</color> gold";
    }
}