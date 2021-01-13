using UnityEngine;
using UnityEngine.UI;

public class TalentPointDisplay : MonoBehaviour
{
    public static TalentPointDisplay s_Instance;
    [SerializeField] private Text m_AvailableTalentPoints;

    void Awake()
    {
        if(s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        ShowAvailableTalentPoints();
    }

    public void ShowAvailableTalentPoints()
    {
        if(PlayerData.s_Instance.AvailableTalentPoints <= 0)
        {
            m_AvailableTalentPoints.text = "";
        }
        else if(PlayerData.s_Instance.AvailableStatPoints >=1)
        {
            m_AvailableTalentPoints.text = "Talent Points Available : " + PlayerData.s_Instance.AvailableTalentPoints;
        }
    }
}