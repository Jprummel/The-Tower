using UnityEngine;
using UnityEngine.UI;

public class ShieldShop : MonoBehaviour
{
    [SerializeField] private Text m_ShieldShopKeeperDialogue;
    [SerializeField] private EquipmentContainer m_ShieldContainer;
    [SerializeField] private GameObject m_ShopContainer;
    [SerializeField] private GameObject m_WarningPanel;
    private Shield m_SelectedShield;

    private void OnEnable()
    {
        m_ShieldShopKeeperDialogue.text = ShopDialogues.SHIELD_WELCOME;
    }

    private void Awake()
    {
        LoadShields();
    }

    public void SelectShield(int ShieldID)
    {
        m_SelectedShield = EquipmentDictionaries.s_Shields[ShieldID];
    }

    public void CheckEquipedWeaponType()
    {
        if (PlayerData.s_Instance.Weapon.WeaponType == "Two-Handed" && PlayerData.s_Instance.Weapon != EquipmentDictionaries.s_Weapons[0])
        {
            m_WarningPanel.SetActive(true);
        }
        else
        {
            BuyShield();
        }
    }

    public void BuyShield()
    {
        Shield TempShield = m_SelectedShield;

        if(PlayerData.s_Instance.Weapon.WeaponType == "Two-Handed" && PlayerData.s_Instance.Weapon != EquipmentDictionaries.s_Weapons[0])
        {
            EquipGear.s_Instance.EquipWeapon(EquipmentDictionaries.s_Weapons[0], true);
        }
        //First check for fails (Else the dialogue will get mixed up)
        if (TempShield.Cost > PlayerData.s_Instance.Gold)
        {
            m_ShieldShopKeeperDialogue.text = ShopDialogues.SHIELD_PURCHASE_UNSUCCESFUL_GOLD;
        }
        if (TempShield.RequiredFloorCleared > PlayerData.s_Instance.MaxFloor)
        {
            m_ShieldShopKeeperDialogue.text = ShopDialogues.SHIELD_PURCHASE_UNSUCCESFUL_FLOOR_REQUIREMENT;
        }
        if (TempShield.RequiredFloorCleared > PlayerData.s_Instance.MaxFloor && TempShield.Cost > PlayerData.s_Instance.Gold)
        {
            m_ShieldShopKeeperDialogue.text = ShopDialogues.SHIELD_PURCHASE_UNSUCCESFUL_NO_REQUIREMENTS_MET;
        }

        if (TempShield.Cost <= PlayerData.s_Instance.Gold && TempShield.RequiredFloorCleared <= PlayerData.s_Instance.MaxFloor)
        {
            EquipGear.s_Instance.EquipShield(TempShield, true);
            PlayerData.s_Instance.CurrentHealth += TempShield.MaxHealthBonus;
            PlayerData.s_Instance.CurrentMana += (TempShield.IntellectBonus * 5);
            m_ShieldShopKeeperDialogue.text = ShopDialogues.SHIELD_PURCHASE_SUCCESFUL;
            PlayerData.s_Instance.Gold -= TempShield.Cost;
            if (GoldDelegateManager.s_UpdateGoldUI != null)
            {
                GoldDelegateManager.s_UpdateGoldUI();
            }
        }
    }

    void LoadShields()
    {
        for (int i = 0; i < EquipmentDictionaries.s_Shields.Count; i++)
        {
            if (i != 0) // Skips default shield "None"
            {
                Shield TempShield = EquipmentDictionaries.s_Shields[i];
                EquipmentContainer TempContainer = Instantiate(m_ShieldContainer);
                TempContainer.transform.SetParent(m_ShopContainer.transform);
                TempContainer.transform.localScale = Vector3.one;
                TempContainer.LoadEquipment(TempShield);
                TempContainer.SelectButton.onClick.AddListener(() => SelectShield(TempShield.ID));
            }
        }
    }
}