using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealingPopup : MonoBehaviour
{
    public static HealingPopup s_Instance;

    private Text m_HealingPopup;
    private Color m_TextColor;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);

        m_HealingPopup = GetComponent<Text>();
        m_TextColor = m_HealingPopup.color;
    }


    public void PopupAnimation(Vector2 position, int damage, bool right)
    {
        m_HealingPopup.text = damage.ToString();
        m_HealingPopup.color = m_TextColor;

        Sequence damagePopupSequence = DOTween.Sequence();

        m_HealingPopup.rectTransform.position = Camera.main.WorldToScreenPoint(position);
        m_HealingPopup.enabled = true;

        int xDirectionValue;


        if (right)
            xDirectionValue = -30;
        else
            xDirectionValue = 30;

        damagePopupSequence.Append(m_HealingPopup.DOFade(0, 1f));
        damagePopupSequence.Join(m_HealingPopup.rectTransform.DOMoveY(m_HealingPopup.rectTransform.position.y + 30, 0.2f).OnComplete(() => damagePopupSequence.Join(m_HealingPopup.rectTransform.DOMoveY(m_HealingPopup.rectTransform.position.y - 25, 0.2f))));
        damagePopupSequence.Join(m_HealingPopup.rectTransform.DOMoveX(m_HealingPopup.rectTransform.position.x + xDirectionValue, 0.4f).OnComplete(() => ResetText()));
    }

    public void PopupAnimation(Vector2 position, int damage, bool right, Color textColor)
    {
        m_HealingPopup.text = damage.ToString();
        m_HealingPopup.color = textColor;

        Sequence damagePopupSequence = DOTween.Sequence();

        m_HealingPopup.rectTransform.position = Camera.main.WorldToScreenPoint(position);
        m_HealingPopup.enabled = true;

        int xDirectionValue;


        if (right)
            xDirectionValue = -30;
        else
            xDirectionValue = 30;

        damagePopupSequence.Append(m_HealingPopup.DOFade(0, 1f));
        damagePopupSequence.Join(m_HealingPopup.rectTransform.DOMoveY(m_HealingPopup.rectTransform.position.y + 30, 0.2f).OnComplete(() => damagePopupSequence.Join(m_HealingPopup.rectTransform.DOMoveY(m_HealingPopup.rectTransform.position.y - 25, 0.2f))));
        damagePopupSequence.Join(m_HealingPopup.rectTransform.DOMoveX(m_HealingPopup.rectTransform.position.x + xDirectionValue, 0.4f).OnComplete(() => ResetText()));
    }

    void ResetText()
    {
        m_HealingPopup.enabled = false;
    }
}