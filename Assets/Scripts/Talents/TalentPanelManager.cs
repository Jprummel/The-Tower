using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentPanelManager : MonoBehaviour
{
    public static TalentPanelManager s_Instance;

    [SerializeField] private GameObject m_TalentInfo;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void ToggleInfo(bool active, Vector3 position)
    {

        m_TalentInfo.GetComponent<RectTransform>().position = position;
        m_TalentInfo.SetActive(active);
    }
}
