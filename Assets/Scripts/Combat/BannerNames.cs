using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BannerNames : MonoBehaviour
{
    [SerializeField] private Text m_PlayerBannerName;
    [SerializeField] private Text m_OpponentBannerName;

    void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        m_PlayerBannerName.text = CombatTurns.s_Instance.ActiveCharacter.Name;
        m_OpponentBannerName.text = BattleUI.s_Opponent.Name;
    }
}