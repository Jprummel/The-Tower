using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterProgression : MonoBehaviour {

    public static CharacterProgression s_Instance;
    [SerializeField] private Text m_Level;
    [SerializeField] private Image m_XPBar;
    [SerializeField] private Text m_XPValue;
    [SerializeField] private Text m_GoldValue;
    [SerializeField] private GameObject m_StatPointGain;
    [SerializeField] private GameObject m_TalentPointGain;
    [SerializeField] private Animation m_LevelUpAnimation;

	void Awake ()
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

    /// <summary>
    /// Method to tween the xp number.
    /// </summary>
    /// <param name="xp">tweening number.</param>
    public void SetXPText(float xp)
    {
        m_XPValue.text = Mathf.RoundToInt(xp) + " / " + PlayerData.s_Instance.RequiredXP;
    }

    /// <summary>
    /// Method to tween the xp number.
    /// </summary>
    /// <param name="xp">tweening number.</param>
    public void SetGoldText(float gold)
    {
        m_GoldValue.text = "Gold: <color=#FFD700>" + Mathf.RoundToInt(gold) + "</color>";
    }


    public void AddExperience(float XPToAdd)
    {
        //Tween xp number from the xp before added xp
        float oldXPValue = PlayerData.s_Instance.CurrentXP;
        PlayerData.s_Instance.CurrentXP += XPToAdd;
        Mathf.RoundToInt(PlayerData.s_Instance.CurrentXP);

        if (PlayerData.s_Instance.CurrentXP >= PlayerData.s_Instance.RequiredXP)
        {
            LevelUp(oldXPValue); //Levels up
        }
        else
        {
            DOTween.To(SetXPText, oldXPValue, PlayerData.s_Instance.CurrentXP, 0.5f);
            m_XPBar.DOFillAmount(PlayerData.s_Instance.CurrentXP / PlayerData.s_Instance.RequiredXP, 0.5f).SetEase(Ease.InOutQuart);
            SaveLoadPlayerData.s_Instance.SavePlayer();
        }

        if(StatPanel.s_Instance!=null)
            StatPanel.s_Instance.ShowPlayerInfo();
       
    }

    void LevelUp(float oldXPValue)
    {
        if(PlayerData.s_Instance.CurrentXP >= PlayerData.s_Instance.RequiredXP)
        {
            float ExcessXP = PlayerData.s_Instance.CurrentXP - PlayerData.s_Instance.RequiredXP;
            PlayerData.s_Instance.Level++;

            PlayerData.s_Instance.Stamina += 1;
            CalculateStats.s_Instance.CalculateMaxHealth(PlayerData.s_Instance);
            PlayerData.s_Instance.CurrentHealth = PlayerData.s_Instance.MaxHealth + PlayerData.s_Instance.MaxHealthBonus;
            PlayerData.s_Instance.CurrentMana = PlayerData.s_Instance.MaxMana + PlayerData.s_Instance.MaxManaBonus;

            m_Level.text = "Lv. " + PlayerData.s_Instance.Level;
            DOTween.To(SetXPText, oldXPValue, PlayerData.s_Instance.RequiredXP, 0.5f);
            float TweenTime = Mathf.Clamp(1 - m_XPBar.fillAmount, 0.5f, 1f);
            m_XPBar.DOFillAmount(1, TweenTime).OnComplete(() => OnLevelUpBarComplete());
            StartCoroutine(ContinueFilling(ExcessXP, TweenTime));

            m_StatPointGain.SetActive(true);
            if(PlayerData.s_Instance.Level % 3 == 0)
            {
                m_TalentPointGain.SetActive(true);
                PlayerData.s_Instance.AddTalentPoints(1);
            }

            PlayerData.s_Instance.AddStatPoints(3);
            PlayerData.s_Instance.CurrentXP = 0;
            for (int i = 0; i < AchievementDictionary.s_Achievements.Count; i++)
            {
                if (AchievementDictionary.s_Achievements[i].AchievementType == Achievement.AchievementTypes.Level)
                {
                    if (!AchievementDictionary.s_Achievements[i].IsComplete)
                    {
                        AchievementDictionary.s_Achievements[i].AddToCurrentAmount(1);
                    }
                }
            }
            if (StatPanel.s_Instance != null)
            {
                StatPanel.s_Instance.DisplayStatPoints();
                StatPointAllocation.s_Instance.ToggleButtons();
            }
        }

        SaveLoadPlayerData.s_Instance.SavePlayer();
    }

    public void AddGold(float gold)
    {
        float oldGoldValue = PlayerData.s_Instance.Gold;

        PlayerData.s_Instance.Gold += gold;

        DOTween.To(SetGoldText, oldGoldValue, PlayerData.s_Instance.Gold, 0.5f);

        for (int i = 0; i < AchievementDictionary.s_Achievements.Count; i++)
        {
            if (AchievementDictionary.s_Achievements[i].AchievementType == Achievement.AchievementTypes.Gold)
            {
                if (!AchievementDictionary.s_Achievements[i].IsComplete)
                {
                    AchievementDictionary.s_Achievements[i].AddToCurrentAmount((int)gold);
                }
            }
        }
        SaveLoadPlayerData.s_Instance.SavePlayer();
    }

    void OnLevelUpBarComplete()
    {
        m_LevelUpAnimation.Play();
        m_XPBar.DOFillAmount(0, 0.01f).SetEase(Ease.InOutQuart);
    }

    IEnumerator ContinueFilling(float excessXP, float waitTime)
    {
        yield return new WaitForSeconds(waitTime + 0.05f);
        PlayerData.s_Instance.RequiredXP = Mathf.RoundToInt(PlayerData.s_Instance.RequiredXP * 1.04f + (50 * PlayerData.s_Instance.Level));
        AddExperience(excessXP);
    }
}