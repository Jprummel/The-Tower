using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextFadeYoyo : MonoBehaviour {

    [Range(0,1)]
    [SerializeField] private float m_MinAlpha;
    [SerializeField] private float m_FadeTime;
    private Text m_Text;

	void Awake () {
        m_Text = GetComponent<Text>();
        FadeYoyo();
	}
	
    void FadeYoyo()
    {
        m_Text.InfiniteFadeYoYo(m_MinAlpha, m_FadeTime);
        //m_Text.DOFade(m_MinAlpha, m_FadeTime).SetLoops(-1,LoopType.Yoyo);
    }
}