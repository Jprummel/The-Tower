using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AchievementInfoPanel : MonoBehaviour
{
    public static AchievementInfoPanel s_Instance;
    private Achievement m_Achievement;
    private AchievementContainer m_AchievementContainer;
    [SerializeField] private Text m_AchievementName;
    [SerializeField] private Text m_Description;
    [SerializeField] private Text m_Progress;
    [SerializeField] private Text m_Reward;
    [SerializeField] private Text m_CompletionStatus;
    [SerializeField] private Button m_ClaimButton;
   

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    public void SetSelectedAchievementContainer(AchievementContainer achievementContainer)
    {
        m_AchievementContainer = achievementContainer;
    }

    public void SetAchievementInfo(Achievement achievement)
    {
        Color textColor;
        m_Achievement = achievement;
        m_AchievementName.text = achievement.AchievementName;
        m_Description.text = achievement.Description;
        m_Progress.text = achievement.CurrentAmount + " / " + achievement.GoalAmount;
        m_Reward.text = achievement.RewardAmount + " " + achievement.RewardType;
        if (!achievement.IsComplete)
        {
            m_CompletionStatus.text = "Not Completed";
            m_CompletionStatus.color = ColorConfig.ConvertHexColor(ColorConfig.TEXT_GREY);
            m_Reward.color = ColorConfig.ConvertHexColor(ColorConfig.TEXT_GREY);
            m_ClaimButton.gameObject.SetActive(false);
        }
        else if(achievement.IsComplete && !achievement.IsClaimed)
        {
            m_CompletionStatus.text = "Completed";
            m_CompletionStatus.color = ColorConfig.ConvertHexColor(ColorConfig.TEXT_GREY);
            m_Reward.color = ColorConfig.ConvertHexColor(ColorConfig.TEXT_GREY);
            m_ClaimButton.gameObject.SetActive(true);
        }
        else if(achievement.IsComplete && achievement.IsClaimed)
        {
            m_CompletionStatus.text = "Claimed";
            m_CompletionStatus.color = Color.green;
            m_Reward.color = Color.green;
            m_ClaimButton.gameObject.SetActive(false);

        }
    }

    public void ClaimAchievement()
    {
        m_Achievement.ClaimAchievement();
        Vector3 defaultPos = m_AchievementContainer.transform.position;
        Sequence claimSequence = DOTween.Sequence();
        //Sequence 1
        claimSequence.Append(m_AchievementContainer.transform.DOScale(1.5f, 1.0f));
        claimSequence.Append(m_Reward.transform.DOScale(1.5f, 0.3f));
        claimSequence.Join(m_Reward.DOColor(Color.green, 0.3f));
        claimSequence.AppendInterval(0.2f);
        claimSequence.Append(m_Reward.transform.DOScale(1, 0.3f));
        claimSequence.Append(m_CompletionStatus.transform.DOScale(1.5f, 0.3f));
        claimSequence.Append(m_CompletionStatus.DOText("Claimed",0.3f));
        claimSequence.Join(m_CompletionStatus.DOColor(Color.green, 0.3f));
        claimSequence.AppendInterval(0.2f);
        claimSequence.Append(m_CompletionStatus.transform.DOScale(1, 0.3f));
        claimSequence.Append(m_AchievementContainer.transform.DOScale(1.2f, 0.5f));
        claimSequence.AppendCallback(() =>m_AchievementContainer.m_AchievementIcon.color = ColorConfig.ConvertHexColor(ColorConfig.IMAGINE_GREYOUT));
    }
}