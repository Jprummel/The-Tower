using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageStatusEffectUI : MonoBehaviour
{
    public static ManageStatusEffectUI s_Instance;

    [SerializeField] private List<Image> m_PlayerStatusEffects = new List<Image>();
    [SerializeField] private List<Image> m_OpponentStatusEffects = new List<Image>();

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);

        SetPlayerPassives();
    }

    private void SetPlayerPassives()
    {
        for (int i = 0; i < PlayerAbilityManager.s_PlayerPassives.Count; i++)
        {
            m_PlayerStatusEffects[i].sprite = PlayerAbilityManager.s_PlayerPassives[i].TalentIcon;
            m_PlayerStatusEffects[i].gameObject.SetActive(true);
            Text duration = m_PlayerStatusEffects[i].GetComponentInChildren<Text>();
            duration.text = "∞";
            duration.fontSize = 35;
        }
    }

    public void AddPlayerStatusEffect(Sprite Icon, int Duration, bool Buff, string DebuffName)
    {
        for (int i = 0; i < m_PlayerStatusEffects.Count; i++)
        {
            if (!m_PlayerStatusEffects[i].gameObject.activeSelf)
            {
                m_PlayerStatusEffects[i].sprite = Icon;
                Text duration = m_PlayerStatusEffects[i].GetComponentInChildren<Text>();
                duration.text = Duration.ToString();
                m_PlayerStatusEffects[i].name = DebuffName;
                if (Buff)
                    duration.color = Color.green;
                else
                    duration.color = Color.red;

                m_PlayerStatusEffects[i].gameObject.SetActive(true);
                
                return;
            }
        }
    }

    public void AddOpponentStatusEffect(Sprite Icon, int Duration, bool Buff, string DebuffName)
    {
        for (int i = 0; i < m_PlayerStatusEffects.Count; i++)
        {
            if (!m_OpponentStatusEffects[i].gameObject.activeSelf)
            {
                m_OpponentStatusEffects[i].sprite = Icon;
                Text duration = m_OpponentStatusEffects[i].GetComponentInChildren<Text>();
                duration.text = Duration.ToString();
                m_OpponentStatusEffects[i].name = DebuffName;
                if (Buff)
                    duration.color = Color.green;
                else
                    duration.color = Color.red;

                m_OpponentStatusEffects[i].gameObject.SetActive(true);

                return;
            }
        }
    }

    public void RefreshPlayerStatusEffect(int Duration, string DebuffName, bool player)
    {
        if (player)
        {
            for (int i = 0; i < m_PlayerStatusEffects.Count; i++)
            {
                if (m_PlayerStatusEffects[i].gameObject.activeSelf && m_PlayerStatusEffects[i].name == DebuffName)
                {
                    Text duration = m_PlayerStatusEffects[i].GetComponentInChildren<Text>();
                    duration.text = Duration.ToString();
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < m_OpponentStatusEffects.Count; i++)
            {
                if (m_OpponentStatusEffects[i].gameObject.activeSelf && m_OpponentStatusEffects[i].name == DebuffName)
                {
                    Text duration = m_OpponentStatusEffects[i].GetComponentInChildren<Text>();
                    duration.text = Duration.ToString();
                    return;
                }
            }
        }
        
    }

    public void ReduceStatusEffectDurations(string StatusEffect, bool player)
    {
        if (player)
        {
            for (int i = 0; i < m_PlayerStatusEffects.Count; i++)
            {
                if (m_PlayerStatusEffects[i].gameObject.activeSelf && m_PlayerStatusEffects[i].name == StatusEffect)
                {
                    Text duration = m_PlayerStatusEffects[i].GetComponentInChildren<Text>();
                    int durationInt = int.Parse(duration.text);
                    int newDuration = durationInt - 1;
                    duration.text = newDuration.ToString();
                }
            }
        }
        else
        {
            for (int i = 0; i < m_OpponentStatusEffects.Count; i++)
            {
                if (m_OpponentStatusEffects[i].gameObject.activeSelf && m_OpponentStatusEffects[i].name == StatusEffect)
                {
                    Text duration = m_OpponentStatusEffects[i].GetComponentInChildren<Text>();
                    int durationInt = int.Parse(duration.text);
                    int newDuration = durationInt - 1;
                    duration.text = newDuration.ToString();
                }
            }
        }
        
    }

    public void RemoveStatusEffect(string StatusEffect, bool player)
    {
        if (player)
        {
            for (int i = 0; i < m_PlayerStatusEffects.Count; i++)
            {
                if (m_PlayerStatusEffects[i].gameObject.activeSelf && m_PlayerStatusEffects[i].name == StatusEffect)
                {
                    m_PlayerStatusEffects[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < m_OpponentStatusEffects.Count; i++)
            {
                if (m_OpponentStatusEffects[i].gameObject.activeSelf && m_OpponentStatusEffects[i].name == StatusEffect)
                {
                    m_OpponentStatusEffects[i].gameObject.SetActive(false);
                }
            }
        }
        
    }
}
