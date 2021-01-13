using System.Collections.Generic;

[System.Serializable]
public class AchievementDictionary
{
    //AchievementName, Achievement Description, Achievement type, RewardType, current progress, goal, is complete, reward amount
    public static Dictionary<int, Achievement> s_Achievements = new Dictionary<int, Achievement>()
    {
        {0,new Achievement(AchievementNames.Start_Of_A_Capital, AchievementDescriptions.The_Start_Of_A_Capital, Achievement.AchievementTypes.Gold,  Achievement.RewardTypes.Intellect,"Gold01",0,1000,false,false,1) },
        {1,new Achievement(AchievementNames.A_Smart_Investment, AchievementDescriptions.A_Smart_Investment,     Achievement.AchievementTypes.Gold,  Achievement.RewardTypes.Intellect,"Gold02",0,5000,false,false,3) },
        {2,new Achievement(AchievementNames.Money_Maker,        AchievementDescriptions.Money_Maker,            Achievement.AchievementTypes.Gold,  Achievement.RewardTypes.Intellect,"Gold03",0,20000,false,false,5) },
        {3,new Achievement(AchievementNames.Lawbringer,         AchievementDescriptions.Lawbringer,             Achievement.AchievementTypes.Kill,  Achievement.RewardTypes.Strength,"Guard",0,5,false,false,1)},
        {4,new Achievement(AchievementNames.Goblin_Slayer,      AchievementDescriptions.Goblin_Slayer,          Achievement.AchievementTypes.Kill,  Achievement.RewardTypes.Agility,"Hobgoblin",0,5,false,false,1)},
        {5,new Achievement(AchievementNames.The_First_Of_Many,  AchievementDescriptions.The_First_Of_Many,      Achievement.AchievementTypes.Kill,  Achievement.RewardTypes.StatPoints,"Gargoyle",0,1,false,false,3)},
        {6,new Achievement(AchievementNames.Newcomer,           AchievementDescriptions.Newcomer,               Achievement.AchievementTypes.Level, Achievement.RewardTypes.Gold,"Level01",0,10,false,false,1000) },
        {7,new Achievement(AchievementNames.Brawler,            AchievementDescriptions.Brawler,                Achievement.AchievementTypes.Level, Achievement.RewardTypes.Gold,"Level02",0,20,false,false,5000) },
        {8,new Achievement(AchievementNames.Warrior,            AchievementDescriptions.Warrior,                Achievement.AchievementTypes.Level, Achievement.RewardTypes.Gold,"Level03",0,30,false,false,50000) }
    };

    public static void ResetAchievements()
    {
        for (int i = 0; i < s_Achievements.Count; i++)
        {
            s_Achievements[i].CurrentAmount = 0;
            s_Achievements[i].IsComplete = false;
            s_Achievements[i].IsClaimed = false;
        }
    }
}