using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentInfo : MonoBehaviour
{
    public delegate void UpdateTalentUI(TalentData talentData);
    public static UpdateTalentUI s_OnUpdateTalentUI;

    [SerializeField] private Text m_TalentName;
    [SerializeField] private Text m_TalentRequirement;
    [SerializeField] private Text m_TalentDescription;
    [SerializeField] private Text m_TalentLevel;
    [SerializeField] private Text m_WeaponRequirement;
    [SerializeField] private Text m_CooldownTimer;
    [SerializeField] private GameObject m_Stopwatch;

    private void OnEnable()
    {
        s_OnUpdateTalentUI += UpdateDisplayUI;
    }

    private void OnDisable()
    {
        s_OnUpdateTalentUI -= UpdateDisplayUI;
    }

    public void UpdateDisplayUI(TalentData talentData)
    {
        m_TalentName.text = talentData.TalentName;

        bool hasRequirement = TalentManager.s_Instance.Eligible(talentData);

        if(talentData.TalentID != 1)
        {
            if (hasRequirement)
                m_TalentRequirement.text = "Requirements: " + "<Color=#008000ff>" + TalentManager.s_Instance.GetTalentByID(talentData.RequiredTalentID).TalentName + "</Color>";
            else
                m_TalentRequirement.text = "Requirements: " + "<Color=#ff0000ff>" + TalentManager.s_Instance.GetTalentByID(talentData.RequiredTalentID).TalentName + "</Color>";
        }
        else
        {
            m_TalentRequirement.text = "Requirements: None";
        }

        if (talentData.IsActivatable)
            m_WeaponRequirement.text = talentData.RequiredWeaponType.ToString();
        else
            m_WeaponRequirement.text = string.Empty;

        m_TalentDescription.text = GetPositionInString(talentData);
        m_TalentLevel.text = PlayerPrefs.GetInt(talentData.name + " Talent Level") + "/" + talentData.MaxTalentLevel;

        if (talentData.Cooldown > 0)
        {
            m_CooldownTimer.text = talentData.Cooldown.ToString();
            m_Stopwatch.gameObject.SetActive(true);
        }
        else
            m_Stopwatch.gameObject.SetActive(false);
    }

    private string GetPositionInString(TalentData talentData)
    {
        string description = talentData.TalentDescription;

        string[] stringToEdit = description.Split('*');

        if (stringToEdit.Length > 1)
        {
            string beforeLevelValues = stringToEdit[0];
            string afterLevelValues = stringToEdit[1];

            string finalDescription = beforeLevelValues + "|";

            for (int i = 0; i < talentData.TalentLevelValues.Count; i++)
            {
                if (i > 0)
                    finalDescription += "/";

                finalDescription += talentData.TalentLevelValues[i];
            }

            finalDescription += "|" + afterLevelValues;

            return finalDescription;

        }
        else
            return talentData.TalentDescription;
    }
}
