using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenEffects : MonoBehaviour {

    public static ScreenEffects s_Instance;

    public delegate void OnFadeCompleted();
    public static OnFadeCompleted s_OnFadeCompleted;

    private Image m_FadeImage;
    private Sequence m_FadeSequence;

    private void Awake()
    {
        Init();

        m_FadeSequence = DOTween.Sequence();
        CreateImageObject();
    }

    private void OnEnable()
    {
        s_OnFadeCompleted = null;
    }

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void FadeIn(float time)
    {
        Color tempColor = m_FadeImage.color;
        tempColor.a = 0;

        m_FadeImage.color = tempColor;

        m_FadeImage.DOFade(1, time).OnComplete(() => s_OnFadeCompleted());
    }

    public void Fade(float time, float fade)
    {
        Color tempColor = m_FadeImage.color;
        tempColor.a = 0;

        m_FadeImage.color = tempColor;

        m_FadeImage.DOFade(fade, time);
    }

    public void FadeOut(float time)
    {
        Color tempColor = m_FadeImage.color;
        tempColor.a = 1;

        m_FadeImage.color = tempColor;
        
        m_FadeImage.DOFade(0, time);
    }

    public void FadeInOut(float time)
    {
        Color tempColor = m_FadeImage.color;
        tempColor.a = 0;

        m_FadeImage.color = tempColor;

        m_FadeSequence.Append(m_FadeImage.DOFade(1, time).SetId(1).OnComplete(()=>m_FadeImage.DOFade(0, time)));
    }

    private void CreateImageObject()
    {
        GameObject imageObject = new GameObject();
        imageObject.transform.SetParent(GameObject.Find("Canvas").transform);
        m_FadeImage = imageObject.AddComponent<Image>();
        m_FadeImage.raycastTarget = false;
        m_FadeImage.rectTransform.anchoredPosition = Vector2.zero;
        m_FadeImage.rectTransform.sizeDelta = new Vector2(1920, 1080);
        Color color = new Color(0, 0, 0, 0);
        m_FadeImage.color = color;
    }
}