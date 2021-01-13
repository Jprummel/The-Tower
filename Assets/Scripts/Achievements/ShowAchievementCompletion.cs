using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ShowAchievementCompletion : MonoBehaviour
{
    public static ShowAchievementCompletion s_Instance;
    [SerializeField] private AchievementCompletionPanel m_achievementCompletionPanel;
    private int m_simultaniousCompletedAchievements;
    void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            s_Instance = this;
        }

    }

    public void ShowCompletion(Achievement completedAchievement)
    {
        m_simultaniousCompletedAchievements++;
        Vector3 DefaultPos = transform.position;
        AchievementCompletionPanel TempPanel = Instantiate(m_achievementCompletionPanel);
        TempPanel.transform.SetParent(this.transform);
        TempPanel.transform.position = DefaultPos;
        TempPanel.GetCompletedAchievementInfo(completedAchievement);
        Sequence achievementSequence = DOTween.Sequence();
        achievementSequence.Append(TempPanel.transform.DOMove(new Vector3(DefaultPos.x, TempPanel.transform.position.y + (m_simultaniousCompletedAchievements * 100)), 1.0f));
        Debug.Log(m_simultaniousCompletedAchievements * 100 + " Y movement");
        achievementSequence.AppendInterval(1);
        achievementSequence.Append(TempPanel.transform.DOMove(DefaultPos, 1.0f));
        achievementSequence.AppendInterval(1);
        achievementSequence.AppendCallback(() => Destroy(TempPanel.gameObject));
        achievementSequence.AppendCallback(() => m_simultaniousCompletedAchievements--);

    }
}