using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentStats : MonoBehaviour
{
    [SerializeField] private Opponent m_Opponent;
    [SerializeField] private SpriteRenderer m_OpponentSprite;

    private void Awake()
    {
        SetAppearance();
    }

    void SetAppearance()
    {
        m_OpponentSprite.color = m_Opponent.CharacterColor;
    }
}
