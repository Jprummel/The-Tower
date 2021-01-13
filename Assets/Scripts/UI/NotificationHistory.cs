using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationHistory : MonoBehaviour
{
    private bool m_Expanded = false;

    [SerializeField] private DisableScrollRectMouse m_ScrollObject;
    [SerializeField] private Image m_Background;
    [SerializeField] private RectTransform m_ExpandButton;
    [SerializeField] private Mask m_Mask;

    [SerializeField] private Text m_LatestNotification;
    [SerializeField] private List<Text> m_Notifications = new List<Text>();

    private void Awake()
    {
        CombatNotification.s_DisplayNotification = null;
        CombatNotification.s_DisplayNotification += ShowLatestNotification;
        CombatNotification.s_DisplayNotification += AddNotificationToHistory;
    }

    private void Expand()
    {
        m_LatestNotification.gameObject.SetActive(false);

        ShowNotifications(true);

        m_Background.rectTransform.offsetMin = new Vector2(m_Background.rectTransform.offsetMin.x, -270);

        m_ExpandButton.offsetMax = new Vector2(m_ExpandButton.offsetMax.x, -275);
        m_ExpandButton.offsetMin = new Vector2(m_ExpandButton.offsetMin.x, -275);
        m_ExpandButton.eulerAngles = new Vector3(0,0,90);

        m_ScrollObject.scrollSensitivity = 5;

        m_Mask.enabled = false;

        m_Expanded = true;
    }

    private void Shrink()
    {
        ShowNotifications(false);

        m_LatestNotification.gameObject.SetActive(true);

        m_Background.rectTransform.offsetMin = new Vector2(m_Background.rectTransform.offsetMin.x, 0);

        m_ExpandButton.offsetMax = new Vector2(m_ExpandButton.offsetMax.x, 0);
        m_ExpandButton.offsetMin = new Vector2(m_ExpandButton.offsetMin.x, 0);
        m_ExpandButton.eulerAngles = new Vector3(0, 0, -90);

        m_ScrollObject.scrollSensitivity = 0;

        m_Mask.enabled = true;

        m_Expanded = false;
    }

    public void OpenCloseNotificationHistory()
    {
        if (!m_Expanded)
            Expand();
        else
            Shrink();
    }

    private void ShowLatestNotification(string notification, string ability)
    {
        m_LatestNotification.text = /*"• " +*/ notification;
        m_LatestNotification.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Abilities/" + ability);
    }

    private void AddNotificationToHistory(string notification, string ability)
    {
        for (int i = 0; i < m_Notifications.Count; i++)
        {
            if (m_Notifications[i].text == string.Empty)
            {
                m_Notifications[i].text = /*"• " + */notification;
                m_Notifications[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Abilities/" + ability);
                break;
            }
        }

        if (m_Expanded)
            ShowNotifications(true);
    }

    private void ShowNotifications(bool enabled)
    {
        for (int i = 0; i < m_Notifications.Count; i++)
        {
            if (m_Notifications[i].text != string.Empty)
                m_Notifications[i].gameObject.SetActive(enabled);
        }
    }
}
