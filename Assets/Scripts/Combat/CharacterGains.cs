using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGains : MonoBehaviour {

    [SerializeField] private Text m_CharacterName;
    [SerializeField] private Text m_CharacterLevel;
    [SerializeField] private Text m_CharacterGold;
    [SerializeField] private Image m_CharacterXPBar;
    [SerializeField] private Text m_CharacterXPValue;

    void DisplayInfo()
    {
        m_CharacterName.text = PlayerData.s_Instance.Name;
        m_CharacterLevel.text = "Lv. " + PlayerData.s_Instance.Level;
        m_CharacterGold.text = "Gold: <color=#FFD700>" + PlayerData.s_Instance.Gold + "</color>";
        m_CharacterXPBar.fillAmount = PlayerData.s_Instance.CurrentXP / PlayerData.s_Instance.RequiredXP;
        m_CharacterXPValue.text = PlayerData.s_Instance.CurrentXP + " / " + PlayerData.s_Instance.RequiredXP;
    }

    private void OnEnable()
    {
        DisplayInfo();
    }

    private void Start()
    {
        StartCoroutine(WaitForLoading());
    }

    IEnumerator WaitForLoading()
    {
        yield return new WaitForSeconds(0.2f);
        CharacterProgression.s_Instance.AddExperience(BattleUI.s_Opponent.XPToGive);
        CharacterProgression.s_Instance.AddGold(BattleUI.s_Opponent.GoldToGive);
        Debug.Log("Gold gained " + BattleUI.s_Opponent.GoldToGive);
    }
}
