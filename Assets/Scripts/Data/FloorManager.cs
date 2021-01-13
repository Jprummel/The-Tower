using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FloorManager : MonoBehaviour {

    public static FloorManager s_Instance;
    public static bool s_Advance;

    [SerializeField] private List<Opponent> m_AvailableOpponents = new List<Opponent>();
    [SerializeField] private Text m_FloorText;
    [SerializeField] private Image m_FloorLock;

    private int m_CurrentFloor;

    void Start()
    {
        Init();
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();

        m_CurrentFloor = PlayerData.s_Instance.CurrentFloor;
        if (m_CurrentFloor == 0)
            m_CurrentFloor = 1;

        m_FloorText.text = "Floor: " + m_CurrentFloor;
        LoadFloor(m_CurrentFloor);
    }

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void LoadFloor(int floor)
    {
        for (int i = 0; i < m_AvailableOpponents.Count; i++)
        {
            LoadOpponent.s_Instance.LoadRandomOpponentByLevel(m_AvailableOpponents[i], (m_CurrentFloor * 5) - 5 + (i + 1));
        }

        if (floor == PlayerData.s_Instance.MaxFloor)
            StartCoroutine(LockAnimation(true));
        else
            StartCoroutine(LockAnimation(false));

        if (s_Advance)
        {
            AdvanceAnimation.s_Instance.PlayAnimation();
            s_Advance = false;
        }
        else
        {
            if (floor == PlayerData.s_Instance.MaxFloor)
                StartCoroutine(LockAnimation(true));
            else
                StartCoroutine(LockAnimation(false));
        }

    }

    public void ChangeFloor(int amount)
    {
        if (!AdvanceAnimation.s_Instance.IsPlaying)
        {
            float animationDuration = 1f;

            int oldFloor = PlayerData.s_Instance.CurrentFloor;
            int newCurrentFloor = Mathf.Clamp(PlayerData.s_Instance.CurrentFloor += amount, 1, PlayerData.s_Instance.MaxFloor);

            if (oldFloor != newCurrentFloor)
            {
                ScreenEffects.s_Instance.FadeInOut(animationDuration);
                StartCoroutine(WaitToChangeUI(animationDuration / 2, newCurrentFloor));
            }

            PlayerData.s_Instance.CurrentFloor = newCurrentFloor;
            m_CurrentFloor = newCurrentFloor;

            LoadFloor(PlayerData.s_Instance.CurrentFloor);
            SaveLoadPlayerData.s_Instance.SavePlayer();
        }
    }

    IEnumerator WaitToChangeUI(float waitTime, int newFloor)
    {
        yield return new WaitForSeconds(waitTime);
        m_FloorText.text = "Floor: " + newFloor;
    }

    IEnumerator LockAnimation(bool locked)
    {
        yield return new WaitForSeconds(0.5f);
        if (locked)
            m_FloorLock.DOFade(0.75f, 0.5f);
        else
            m_FloorLock.DOFade(0, 0.5f);
    }
}