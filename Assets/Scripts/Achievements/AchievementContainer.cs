using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AchievementContainer : MonoBehaviour,IPointerDownHandler
{
    public Image m_AchievementIcon;
    public Button SelectButton;
    private Achievement m_Achievement;

    public void LoadAchievement(Achievement achievementToLoad)
    {
        m_Achievement = achievementToLoad;
        m_AchievementIcon.sprite = Resources.Load<Sprite>("AchievementIcons/" + achievementToLoad.AchievementType + "/" + achievementToLoad.TargetName);
        if (m_Achievement.IsClaimed)
        {
            m_AchievementIcon.color = ColorConfig.ConvertHexColor(ColorConfig.IMAGINE_GREYOUT);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AchievementInfoPanel.s_Instance.SetAchievementInfo(m_Achievement);
        AchievementInfoPanel.s_Instance.SetSelectedAchievementContainer(this);
    }
}
