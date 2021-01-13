using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntranceDoor : MonoBehaviour
{
    [SerializeField] private GameObject m_DoorOpen;
    [SerializeField] private GameObject m_DoorClosed;
    private bool m_FinishedLoading;

    private void Awake()
    {
        StartCoroutine(WaitToLoad());
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(0.25f);
        m_FinishedLoading = true;
    }

    void OnMouseEnter()
    {
        if (!AdvanceAnimation.s_Instance.IsPlaying && m_FinishedLoading)
        {
            m_DoorOpen.SetActive(true);
            m_DoorClosed.SetActive(false);
        }
    }

    void OnMouseExit()
    {
        m_DoorOpen.SetActive(false);
        m_DoorClosed.SetActive(true);
    }

    private void OnMouseUp()
    {
        if (!AdvanceAnimation.s_Instance.IsPlaying && m_FinishedLoading)
        {
            //If the player did not click on a UI element in front of the opponent.
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                CombatInfo.s_Instance.Opponent = GetComponent<Opponent>();
                CombatInfo.s_Instance.ToggleInfo();
            }
        }
    }
}
