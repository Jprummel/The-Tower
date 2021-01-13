using UnityEngine;
using UnityEngine.UI;

public class TownHealing : MonoBehaviour
{
    [SerializeField] private Text m_HealthGoldCostText;
    [SerializeField] private Text m_ManaGoldCostText;
    [SerializeField] private Text m_HealerDialogue;
    private int m_HealthGoldCost;
    private int m_ManaGoldCost;
    private int m_TotalCost;
    private int m_LostHealth;
    private int m_LostMana;

    private void OnEnable()
    {
        CalculateLostHPAndCost();
        m_HealerDialogue.text = ShopDialogues.HEALER_WELCOME;
    }

    public void HealPlayer()
    {
        if (PlayerData.s_Instance.CurrentHealth < PlayerData.s_Instance.MaxHealth)
        {
            if (PlayerData.s_Instance.Gold >= m_HealthGoldCost)
            {
                PlayerData.s_Instance.CurrentHealth = PlayerData.s_Instance.MaxHealth;
                PlayerData.s_Instance.Gold -= m_HealthGoldCost;
                m_HealerDialogue.text = ShopDialogues.HEALER_SUCCESFUL;
            }
            else
            {
                for (int i = 10; i < PlayerData.s_Instance.Gold; i++)
                {
                    PlayerData.s_Instance.CurrentHealth += 1;
                    PlayerData.s_Instance.Gold -= 10;
                    m_HealerDialogue.text = ShopDialogues.HEALER_UNSUCCESFUL_GOLD;
                }
            }
        }
        else
        {
            m_HealerDialogue.text = ShopDialogues.HEALER_UNSUCCESFUL_FULL_HEALTH;
        }
    }

    public void RestoreMana()
    {
        if(PlayerData.s_Instance.CurrentMana < PlayerData.s_Instance.MaxMana)
        {
            if(PlayerData.s_Instance.Gold >= m_ManaGoldCost)
            {
                PlayerData.s_Instance.CurrentMana = PlayerData.s_Instance.MaxMana;
                PlayerData.s_Instance.Gold -= m_ManaGoldCost;
                m_HealerDialogue.text = ShopDialogues.HEALER_SUCCESFUL;
            }
            else
            {
                for (int i = 5; i < PlayerData.s_Instance.Gold; i++)
                {
                    PlayerData.s_Instance.CurrentMana += 1;
                    PlayerData.s_Instance.Gold -= 5;
                    m_HealerDialogue.text = ShopDialogues.HEALER_UNSUCCESFUL_GOLD;
                }
            }
        }
        else
        {
            m_HealerDialogue.text = ShopDialogues.HEALER_UNSUCCESFUL_FULL_MANA;
        }
    }

    public void FullRestore()
    {
        if(PlayerData.s_Instance.CurrentMana < PlayerData.s_Instance.MaxMana || PlayerData.s_Instance.CurrentHealth < PlayerData.s_Instance.MaxHealth)
        {
            if(PlayerData.s_Instance.Gold >= m_TotalCost)
            {
                PlayerData.s_Instance.CurrentHealth = PlayerData.s_Instance.MaxHealth;
                PlayerData.s_Instance.CurrentMana = PlayerData.s_Instance.MaxMana;
                PlayerData.s_Instance.Gold -= m_TotalCost;
                m_HealerDialogue.text = ShopDialogues.HEALER_SUCCESFUL;
            }
            else
            {
                m_HealerDialogue.text = ShopDialogues.HEALER_UNSUCCESFUL_PICK_ONE;
            }
        }
        else
        {
            m_HealerDialogue.text = ShopDialogues.HEALER_UNSUCCESFUL_BOTH_FULL;
        }
    }

    void CalculateLostHPAndCost()
    {
        m_LostHealth = Mathf.RoundToInt((PlayerData.s_Instance.MaxHealth + PlayerData.s_Instance.MaxHealthBonus)- PlayerData.s_Instance.CurrentHealth);
        m_LostMana = Mathf.RoundToInt((PlayerData.s_Instance.MaxMana + PlayerData.s_Instance.MaxManaBonus) - PlayerData.s_Instance.CurrentMana);
        m_HealthGoldCost = m_LostHealth * 10;
        m_ManaGoldCost = m_LostMana * 5;
        m_TotalCost = m_HealthGoldCost + m_ManaGoldCost;
        m_ManaGoldCostText.text = "Fully restoring your mana will cost you " + m_ManaGoldCost + " gold";
        m_HealthGoldCostText.text = "Fully healing you will cost you " + m_HealthGoldCost + " gold.";
    }
}