using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private Text m_WeaponShopKeeperDialogue;
    [SerializeField] private EquipmentContainer m_WeaponContainer;
    [SerializeField] private GameObject m_ShopContainer;
    [SerializeField] private GameObject m_WarningPanel;
    private Weapon m_SelectedWeapon;

    private void OnEnable()
    {
        m_WeaponShopKeeperDialogue.text = ShopDialogues.WEAPON_WELCOME;
    }

    private void Awake()
    {
        LoadWeapons();
    }

    public void SelectWeapon(int WeaponID)
    {
        m_SelectedWeapon = EquipmentDictionaries.s_Weapons[WeaponID];
    }

    public void CheckIfWeaponAndShieldCanCombine()
    {
        if (m_SelectedWeapon.WeaponType == "Two-Handed")
        {
            if (PlayerData.s_Instance.Shield.ID != EquipmentDictionaries.s_Shields[0].ID)
            {
                m_WarningPanel.SetActive(true);
            }
            else
            {
                BuyWeapon();
            }
        }
        else
        {
            BuyWeapon();
        }
    }

    public void BuyWeapon()
    {
        Weapon TempWeapon = m_SelectedWeapon;

        if (TempWeapon.WeaponType == "Two-Handed")
        {
            EquipGear.s_Instance.EquipShield(EquipmentDictionaries.s_Shields[0], true);
        }
            
        //Check for failing requirements first else dialogue will mess up
        if (TempWeapon.Cost > PlayerData.s_Instance.Gold)
        {
            m_WeaponShopKeeperDialogue.text = ShopDialogues.WEAPON_PURCHASE_UNSUCCESFUL_GOLD;
        }
        if(TempWeapon.RequiredFloorCleared > PlayerData.s_Instance.MaxFloor)
        {
            m_WeaponShopKeeperDialogue.text = ShopDialogues.WEAPON_PURCHASE_UNSUCCESFUL_FLOOR_REQUIREMENT;
        }
        if(TempWeapon.RequiredFloorCleared > PlayerData.s_Instance.MaxFloor && TempWeapon.Cost > PlayerData.s_Instance.Gold)
        {
            m_WeaponShopKeeperDialogue.text = ShopDialogues.WEAPON_PURCHASE_UNSUCCESFUL_NO_REQUIREMENTS_MET;
        }

        if (TempWeapon.Cost <= PlayerData.s_Instance.Gold && TempWeapon.RequiredFloorCleared <= PlayerData.s_Instance.MaxFloor)
        {
            EquipGear.s_Instance.EquipWeapon(TempWeapon, true);
            m_WeaponShopKeeperDialogue.text = ShopDialogues.WEAPON_PURCHASE_SUCCESFUL;
            PlayerData.s_Instance.Gold -= TempWeapon.Cost;
            if (GoldDelegateManager.s_UpdateGoldUI != null)
            {
                GoldDelegateManager.s_UpdateGoldUI();
            }
        }
    }

    void LoadWeapons()
    {
        for (int i = 0; i < EquipmentDictionaries.s_Weapons.Count; i++)
        {
            if(i != 0) // Skips default weapon "Fists"
            {
                Weapon TempWeapon = EquipmentDictionaries.s_Weapons[i];
                EquipmentContainer TempContainer = Instantiate(m_WeaponContainer);
                TempContainer.transform.SetParent(m_ShopContainer.transform);
                TempContainer.transform.localScale = Vector3.one;
                TempContainer.LoadEquipment(TempWeapon);
                TempContainer.SelectButton.onClick.AddListener(() => SelectWeapon(TempWeapon.ID));
            }
        }
    }
}