using UnityEngine;

public class AchievementPanel : MonoBehaviour
{
    [SerializeField] private AchievementContainer m_AchievementContainer;
    [SerializeField] private Transform m_AchievementsContainer;

    void Awake()
    {
        LoadAchievements();
    }

    void LoadAchievements()
    {
        for (int i = 0; i < AchievementDictionary.s_Achievements.Count; i++)
        {
            Achievement TempAchievement = AchievementDictionary.s_Achievements[i];
            AchievementContainer TempContainer = Instantiate(m_AchievementContainer);
            TempContainer.transform.SetParent(m_AchievementsContainer);
            TempContainer.LoadAchievement(TempAchievement);
            TempContainer.SelectButton.onClick.AddListener(() => AchievementInfoPanel.s_Instance.SetAchievementInfo(TempAchievement));
        }
    }
}