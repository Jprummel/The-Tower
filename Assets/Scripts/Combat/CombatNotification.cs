using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public struct Notification
{
    public string Text;
    public float Duration;
    public string AbilityPath;

    public Notification(string text, float duration, string abilityPath)
    {
        this.Text = text;
        this.Duration = duration;
        this.AbilityPath = abilityPath;
    }
}

public class CombatNotification : MonoBehaviour {

    public static CombatNotification s_Instance;

    public delegate void DisplayNotification(string notification, string ability);
    public static DisplayNotification s_DisplayNotification;

    [SerializeField] private List<Text> m_NotificationTexts = new List<Text>();
    private List<Notification> m_NotificationQueue = new List<Notification>();
    private int m_CurrentNotification;

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    private void Awake()
    {
        Init();
    }

    public void AddNotification(string text, float duration, string imageName = "")
    {
        m_NotificationQueue.Add(new Notification(text, duration, imageName));

        StartQueue();
    }


    private void StartQueue()
    {
        TextAnimation(m_CurrentNotification);
        m_CurrentNotification++;
    }

    private void TextAnimation(int notificationNumber)
    {
        int textNumber = GetUsableNotificationText();

        Notification notification = m_NotificationQueue[notificationNumber];
        Text notificationText = m_NotificationTexts[textNumber];

        notificationText.text = notification.Text;
        notificationText.gameObject.SetActive(true);
        notificationText.rectTransform.DOAnchorPosY(45, notification.Duration);
        notificationText.DOFade(0, notification.Duration).OnComplete(()=>ResetNotificationText(notificationText));

        s_DisplayNotification(notification.Text, notification.AbilityPath);
    }

    private void ResetNotificationText(Text textToReset)
    {
        m_NotificationQueue.RemoveAt(0);
        m_CurrentNotification--;
        textToReset.DOFade(1, 0.01f);
        textToReset.rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        textToReset.gameObject.SetActive(false);
    }

    private int GetUsableNotificationText()
    {
        for (int i = 0; i < m_NotificationTexts.Count; i++)
        {
            if (m_NotificationTexts[i].IsActive())
                continue;
            else
                return i;
        }

        return 0;
    }

    private bool IsNotificationQueueEmpty()
    {
        if (m_NotificationQueue.Count == 0)
            return true;
        else
            return false;
    }
}
