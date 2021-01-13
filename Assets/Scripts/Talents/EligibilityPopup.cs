using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EligibilityPopup : MonoBehaviour
{
    public static EligibilityPopup s_Instance;

    [SerializeField] private Text m_RequirementsNotMetTxt;
    private bool m_CanPlay = true;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void PopupText()
    {
        if (m_CanPlay)
        {
            m_CanPlay = false;
            m_RequirementsNotMetTxt.gameObject.SetActive(true);
            RectTransform rt = m_RequirementsNotMetTxt.rectTransform;
            Vector2 oldPos = rt.position;
            rt.DOMoveY(rt.position.y + 20, 0.75f);
            m_RequirementsNotMetTxt.DOFade(0, 0.75f).OnComplete(()=>ResetText(oldPos));
        }
    }

    private void ResetText(Vector2 oldPos)
    {
        m_RequirementsNotMetTxt.gameObject.SetActive(false);
        m_RequirementsNotMetTxt.DOFade(1, 0.01f);
        m_RequirementsNotMetTxt.rectTransform.position = oldPos;
        m_CanPlay = true;
    }
}
