using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenEffects : MonoBehaviour
{
    public static TweenEffects s_Instance;
    
    void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public void GetDamagedEffect(Character character)
    {
        SpriteRenderer sprite = character.GetComponent<SpriteRenderer>();
        Color DefaultColor = sprite.color;
        Color EffectColor = Color.red;

        Sequence EffectSequence = DOTween.Sequence();
        EffectSequence.Append(sprite.DOColor(EffectColor, 0.25f).SetLoops(2,LoopType.Yoyo));
    }

    
}
