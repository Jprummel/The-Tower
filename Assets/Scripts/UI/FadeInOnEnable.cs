using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeInOnEnable : MonoBehaviour {

    private Text m_ButtonText;

	void OnEnable () {
        m_ButtonText = GetComponent<Text>();
        m_ButtonText.DOFade(1, 0.5f);
	}
	
}
