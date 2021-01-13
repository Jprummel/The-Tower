using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

    [SerializeField] private Text m_PressKeyToContinueText;
    [SerializeField] private GameObject m_ButtonContainer;
     
	void Update () {
        if (Input.anyKey)
        {
            m_PressKeyToContinueText.gameObject.SetActive(false);
            m_ButtonContainer.SetActive(true);
            GameDistribution.Instance.ShowAd();
        }
	}
}