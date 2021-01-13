using UnityEngine;

public class SaveLoadAchievements : MonoBehaviour
{
    public static SaveLoadAchievements s_Instance;

    private void Awake()
    {
        if(s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        LoadAchievements();
    }

    public void SaveAchievements()
    {
        for (int i = 0; i < AchievementDictionary.s_Achievements.Count; i++)
        {
            PlayerPrefs.SetInt(AchievementDictionary.s_Achievements[i].TargetName, AchievementDictionary.s_Achievements[i].CurrentAmount);
        }
    }

    public void LoadAchievements()
    {
        for (int i = 0; i < AchievementDictionary.s_Achievements.Count; i++)
        {
            Achievement Achievement = AchievementDictionary.s_Achievements[i];
            Achievement.CurrentAmount = PlayerPrefs.GetInt(Achievement.TargetName);
            if(Achievement.CurrentAmount >= Achievement.GoalAmount)
            {
                Achievement.IsComplete = true;
                Achievement.CurrentAmount = Achievement.GoalAmount;
            }
        }
    }
}