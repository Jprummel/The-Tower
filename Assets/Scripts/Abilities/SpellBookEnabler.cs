using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookEnabler : MonoBehaviour
{
    [SerializeField] private GameObject m_Talents;
    [SerializeField] private GameObject m_Abilities;
    [SerializeField] private Panel m_Parent;

    private void Awake()
    {
        m_Parent.Show();
        m_Abilities.SetActive(true);
        m_Abilities.SetActive(false);
        m_Parent.Hide();
    }
}
