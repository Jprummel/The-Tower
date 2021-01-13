using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Talent : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private GameEvent m_TalentEvents;
    private Vector2 m_TalentPositonWOffset;

    private void Awake()
    {
        RectTransform rt = GetComponent<RectTransform>();
        m_TalentPositonWOffset = new Vector2(rt.position.x, rt.position.y + Camera.main.pixelHeight / 10 * 2);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //PlayerData.s_Instance.AvailableTalentPoints++;
        if (m_TalentEvents != null)
            m_TalentEvents.TalentClicked();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TalentPanelManager.s_Instance.ToggleInfo(true, m_TalentPositonWOffset);
        if(m_TalentEvents != null)
            m_TalentEvents.TalentHovered();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TalentPanelManager.s_Instance.ToggleInfo(false, new Vector2(0,0));
    }
}
