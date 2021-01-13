using UnityEngine;
using UnityEngine.UI;

public class AchievementCompletionPanel : MonoBehaviour
{
    [SerializeField] private Image m_AchievementIcon;
    [SerializeField] private Text m_AchievementCompletedText;
    [SerializeField] private Text m_AchievementDescription;

    public void GetCompletedAchievementInfo(Achievement completedAchievement)
    {
        m_AchievementIcon.sprite = Resources.Load<Sprite>("AchievementIcons/" + completedAchievement.AchievementType + "/" + completedAchievement.TargetName);
        m_AchievementCompletedText.text = completedAchievement.AchievementName + " completed!";
        m_AchievementDescription.text = completedAchievement.Description;
    }
}