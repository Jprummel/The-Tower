using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDescription : MonoBehaviour
{
    public static SkillDescription s_Instance;

    [SerializeField] private Text m_SkillName;
    [SerializeField] private Text m_SkillDescription;
    [SerializeField] private Text m_SkillCooldown;
    [SerializeField] private GameObject m_DescriptionPanel;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowInfo(TalentData skill)
    {
        if(skill != null)
        {
            m_SkillName.text = skill.TalentName;
            m_SkillDescription.text = skill.TalentDescription;
            m_SkillCooldown.text = skill.Cooldown.ToString();

            m_DescriptionPanel.SetActive(true);
        }
    }

    public void HideInfo()
    {
        m_DescriptionPanel.SetActive(false);
    }
}
