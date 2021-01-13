using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSkill : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    private bool m_ActiveOrigin;
    private string m_SelectedSkill;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerEnter.tag == "ActionBar")
        {
            //Debug.Log("Grab " + eventData.pointerEnter.name + " from action bar");
            m_ActiveOrigin = true;
            DraggedSkillIcon.s_Instance.DragSkill(eventData.pointerEnter.name);
        }
        else
        {
            //Debug.Log("Start Dragging " + eventData.pointerEnter.name);
            m_ActiveOrigin = false;
            DraggedSkillIcon.s_Instance.DragSkill(eventData.pointerEnter.name);
        }

        m_SelectedSkill = eventData.pointerEnter.name;
    }

    public void  OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("Release at " + eventData.pointerEnter.tag);
        DraggedSkillIcon.s_Instance.ReleaseSkill();
        if (m_ActiveOrigin)
        {
            if (eventData.pointerEnter.tag != "ActionBar")
            {
                //Debug.Log("Remove " + m_SelectedSkill);
                PlayerAbilityManager.s_Instance.RemoveAbilityFromActions(m_SelectedSkill);
            }
        }
        else
        {
            if (eventData.pointerEnter.tag == "ActionBar")
            {
                if (eventData.pointerEnter.name == "EmptySkill")
                    PlayerAbilityManager.s_Instance.AddAbilityToActions(m_SelectedSkill);
                else
                    PlayerAbilityManager.s_Instance.ReplaceAbility(m_SelectedSkill, eventData.pointerEnter.name);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillDescription.s_Instance.ShowInfo(TalentManager.s_Instance.GetTalentByName(eventData.pointerEnter.name));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillDescription.s_Instance.HideInfo();
    }
}
