using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    private Text m_text;

    private void OnEnable()
    {
        m_text = GetComponent<Text>();
        
        Sequence sqn = DOTween.Sequence();
        sqn.Append(m_text.DOFade(0.33f, 1f));
        sqn.SetLoops(-1, LoopType.Yoyo);
    }
}
