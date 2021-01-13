using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup s_Instance;

    [SerializeField]private List<Text> m_DamageTexts = new List<Text>();
    private Color m_TextColor;
    private static int m_DamageTextInt = 0;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);       
    }


    public void PopupAnimation(Vector2 position,int damage, bool right)
    {
        Text damageText = m_DamageTexts[m_DamageTextInt];
        m_DamageTextInt++;

        damageText.text = damage.ToString();
        damageText.color = Color.red;

        Sequence damagePopupSequence = DOTween.Sequence();

        damageText.rectTransform.position = Camera.main.WorldToScreenPoint(position);
        damageText.enabled = true;

        int xDirectionValue;


        if (right)
            xDirectionValue = -30;
        else
            xDirectionValue = 30;

        damagePopupSequence.Append(damageText.DOFade(0, 1f).OnComplete(()=>m_DamageTextInt--));
        damagePopupSequence.Join(damageText.rectTransform.DOMoveY(damageText.rectTransform.position.y + 30, 0.2f).OnComplete(()=>damagePopupSequence.Join(damageText.rectTransform.DOMoveY(damageText.rectTransform.position.y - 25, 0.2f))));
        damagePopupSequence.Join(damageText.rectTransform.DOMoveX(damageText.rectTransform.position.x + xDirectionValue, 0.4f).OnComplete(()=>ResetText(damageText)));
    }

    public void PopupAnimation(Vector2 position, int damage, bool right, Color textColor)
    {
        Text damageText = m_DamageTexts[m_DamageTextInt];

        damageText.text = damage.ToString();
        damageText.color = textColor;

        Sequence damagePopupSequence = DOTween.Sequence();

        damageText.rectTransform.position = Camera.main.WorldToScreenPoint(position);
        damageText.enabled = true;

        int xDirectionValue;


        if (right)
            xDirectionValue = -30;
        else
            xDirectionValue = 30;

        damagePopupSequence.Append(damageText.DOFade(0, 1f));
        damagePopupSequence.Join(damageText.rectTransform.DOMoveY(damageText.rectTransform.position.y + 30, 0.2f).OnComplete(() => damagePopupSequence.Join(damageText.rectTransform.DOMoveY(damageText.rectTransform.position.y - 25, 0.2f))));
        damagePopupSequence.Join(damageText.rectTransform.DOMoveX(damageText.rectTransform.position.x + xDirectionValue, 0.4f).OnComplete(() => ResetText(damageText)));
    }

    void ResetText(Text textToReset)
    {
        textToReset.enabled = false;
    }
}
