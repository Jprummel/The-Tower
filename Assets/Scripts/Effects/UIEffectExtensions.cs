using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class UIEffectExtensions
{
    public static void InfiniteFadeYoYo(this Text text, float minAlpha,float fadeTime)
    {
        text.DOFade(minAlpha, fadeTime).SetLoops(-1, LoopType.Yoyo);
    }

    public static void FlashImageColor(this Image image, Color color,float flashDuration)
    {
        Color defaultColor = image.color;
        Sequence flashColorSequence = DOTween.Sequence();
        flashColorSequence.Append(image.DOColor(color, flashDuration / 2));
        flashColorSequence.Append(image.DOColor(defaultColor, flashDuration / 2));
    }
}