using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityDescriptionHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private RectTransform m_RectTransform;

    private TalentData m_Talent;

    [SerializeField] private string m_AbilityDescriptionString;
    [SerializeField] private string m_AbilityName;
    [SerializeField] private string m_AbilityCost;

    public string AbilityDescriptionString
    {
        get { return m_AbilityDescriptionString; }
        set { m_AbilityDescriptionString = value; }
    }

    public TalentData Talent
    {
        get { return m_Talent; }
        set { m_Talent = value; }
    }


    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (GetComponent<Button>().interactable)
        {
            AbilityDescription.s_Instance.SetText(m_Talent, m_AbilityDescriptionString, m_AbilityName, m_AbilityCost, m_RectTransform);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        AbilityDescription.s_Instance.DisableText();
    }
}
