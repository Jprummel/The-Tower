using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggedSkillIcon : MonoBehaviour
{
    public static DraggedSkillIcon s_Instance;

    [SerializeField] private Image m_SkillIcon;
    [SerializeField] private GameObject m_DraggedSkillIcon;
    private RectTransform m_rectTransform;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);

        m_rectTransform = m_DraggedSkillIcon.GetComponent<RectTransform>();
    }

    public void Update()
    {
        if (m_DraggedSkillIcon.activeSelf)
        {
            Vector2 mousePos = new Vector2(Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2);

            m_rectTransform.anchoredPosition = mousePos;

        }
    }

    public void DragSkill(string skillName)
    {
        m_SkillIcon.sprite = TalentManager.s_Instance.GetTalentByName(skillName).TalentIcon;
        m_DraggedSkillIcon.SetActive(true);
    }

    public void ReleaseSkill()
    {
        m_DraggedSkillIcon.SetActive(false);
    }
}
