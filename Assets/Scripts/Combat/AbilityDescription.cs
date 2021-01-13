using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDescription : MonoBehaviour {

    public static AbilityDescription s_Instance;

    [SerializeField]private Text m_AbilityDescription;
    [SerializeField] private Text m_AbilityName;
    [SerializeField] private Text m_AbilityCost;
    [SerializeField] private RectTransform m_AbilityDescriptionRT;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetText(TalentData talent, string description,string name, string cost, RectTransform position)
    {
        m_AbilityDescriptionRT.anchoredPosition = new Vector2(Mathf.Clamp(position.anchoredPosition.x, 125, 1795), 200);

        if (description != string.Empty)
        {
            m_AbilityDescription.text = description;
            m_AbilityCost.text = cost + " Mana";
            m_AbilityName.text = name;
        }
        else
        {
            m_AbilityDescription.text = GetPositionInString(talent);
            m_AbilityName.text = talent.TalentName;
            m_AbilityCost.text = talent.ManaCost + " Mana";
        }

        m_AbilityDescriptionRT.gameObject.SetActive(true);
    }

    public void DisableText()
    {
        m_AbilityDescriptionRT.gameObject.SetActive(false);
    }

    private string GetPositionInString(TalentData talentData)
    {
        string description = talentData.TalentDescription;

        string[] stringToEdit = description.Split('*');

        if (stringToEdit.Length > 1)
        {
            string beforeLevelValues = stringToEdit[0];
            string afterLevelValues = stringToEdit[1];


            string talentLevelValue = talentData.TalentLevelValues[PlayerPrefs.GetInt(talentData.name + " Talent Level") -1];

            string finalDescription = beforeLevelValues + talentLevelValue + afterLevelValues;

            return finalDescription;

        }
        else
            return talentData.TalentDescription;
    }
}
