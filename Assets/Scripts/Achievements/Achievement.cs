using UnityEngine;

public class Achievement : MonoBehaviour
{
    public enum AchievementTypes
    {
        Kill,
        Gold,
        Level
    }
    public AchievementTypes AchievementType; 

    public enum RewardTypes
    {
        Gold,
        TalentPoints,
        StatPoints,
        Strength,
        Stamina,
        Agility,
        Intellect
    }

    public RewardTypes RewardType;
    public string AchievementName;
    public string Description;
    public string TargetName;
    public int CurrentAmount;
    public int GoalAmount;
    public bool IsComplete;
    public bool IsClaimed;
    public int RewardAmount;

    public Achievement(string achievementName, string description, AchievementTypes achievementType,RewardTypes rewardType, string targetName, int currentAmount,int goalAmount,bool isComplete,bool isClaimed, int rewardAmount)
    {
        AchievementName = achievementName;
        Description = description;
        AchievementType = achievementType;
        RewardType = rewardType;
        TargetName = targetName;
        CurrentAmount = currentAmount;
        GoalAmount = goalAmount;
        IsComplete = isComplete;
        IsClaimed = isClaimed;
        RewardAmount = rewardAmount;
    }

    public void AddToCurrentAmount(int value)
    {
        CurrentAmount += value;
        CheckForCompletion();
        SaveLoadAchievements.s_Instance.SaveAchievements();
    }

    void CheckForCompletion()
    {
        if (!IsComplete)
        {
            if (CurrentAmount >= GoalAmount)
            {
                CompleteAchievement();
                CurrentAmount = GoalAmount;
            }
        }
    }

    void CompleteAchievement()
    {
        IsComplete = true;
        ShowAchievementCompletion.s_Instance.ShowCompletion(this);
    }

    public void ClaimAchievement()
    {
        if (!IsClaimed)
        {
            switch (RewardType)
            {
                case RewardTypes.TalentPoints:
                    PlayerData.s_Instance.AddTalentPoints(RewardAmount);
                    break;
                case RewardTypes.StatPoints:
                    PlayerData.s_Instance.AddStatPoints(RewardAmount);
                    break;
                case RewardTypes.Gold:
                    PlayerData.s_Instance.Gold += RewardAmount;
                    break;
                case RewardTypes.Strength:
                    PlayerData.s_Instance.Strength += RewardAmount;
                    break;
                case RewardTypes.Stamina:
                    PlayerData.s_Instance.Stamina += RewardAmount;
                    break;
                case RewardTypes.Agility:
                    PlayerData.s_Instance.Agility += RewardAmount;
                    break;
                case RewardTypes.Intellect:
                    PlayerData.s_Instance.Intellect += RewardAmount;
                    break;
            }
            IsClaimed = true;
        }
    }
    
    public void ResetAchievement()
    {
        CurrentAmount = 0;
        IsComplete = false;
    }
}