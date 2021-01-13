using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AdvanceAnimation : MonoBehaviour
{
    public static AdvanceAnimation s_Instance;

    public bool IsPlaying;

    [SerializeField] private Animation m_LockAnimation;
    [SerializeField] private Text m_CongratsText;

    [SerializeField] private Button m_ReturnButton;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayAnimation()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        IsPlaying = true;
        m_ReturnButton.interactable = false;

        Color textColor = m_CongratsText.color;

        ScreenEffects.s_Instance.Fade(0.5f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        m_LockAnimation.Play();
        m_CongratsText.DOText("Congratulations! You have unlocked a new floor.", 2f);
        yield return new WaitForSeconds(4f);
        m_CongratsText.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        m_CongratsText.text = string.Empty;
        m_CongratsText.color = textColor;
        ScreenEffects.s_Instance.Fade(0.5f, 0f);
        yield return new WaitForSeconds(0.5f);
        IsPlaying = false;
        m_ReturnButton.interactable = true;
    }
}
