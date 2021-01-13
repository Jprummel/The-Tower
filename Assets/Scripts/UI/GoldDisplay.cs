using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour {

    [SerializeField] private Text m_GoldValue;

	void Awake () {
        GoldDelegateManager.s_UpdateGoldUI += DisplayGold;
	}

    private void OnEnable()
    {
        DisplayGold();
    }

    public void DisplayGold()
    {
        if (m_GoldValue != null)
        {
            m_GoldValue.text = PlayerData.s_Instance.Gold.ToString();
        }
    }

    private void OnDestroy()
    {
        GoldDelegateManager.s_UpdateGoldUI += DisplayGold;
    }
}
