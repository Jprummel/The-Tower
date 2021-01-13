using UnityEngine;
using UnityEngine.UI;

public class ArmorShop : MonoBehaviour
{
    [SerializeField] private Text m_ArmorShopKeeperDialogue;
    [SerializeField] private EquipmentContainer m_ArmorContainer;
    [SerializeField] private GameObject m_ShopContainer;
    private Armor m_SelectedArmor;

    private void OnEnable()
    {
        m_ArmorShopKeeperDialogue.text = ShopDialogues.ARMOR_WELCOME;
    }

    private void Awake()
    {
        LoadArmors();
    }

    void SelectArmor(int ArmorID)
    {
        m_SelectedArmor = EquipmentDictionaries.s_Armors[ArmorID];
    }

    public void BuyArmor()
    {
        Armor TempArmor = m_SelectedArmor;
        //First check for fails (Else the dialogue will get mixed up)
        if (TempArmor.Cost > PlayerData.s_Instance.Gold)
        {
            m_ArmorShopKeeperDialogue.text = ShopDialogues.ARMOR_PURCHASE_UNSUCCESFUL_GOLD;
        }
        if (TempArmor.RequiredFloorCleared > PlayerData.s_Instance.MaxFloor)
        {
            m_ArmorShopKeeperDialogue.text = ShopDialogues.ARMOR_PURCHASE_UNSUCCESFUL_FLOOR_REQUIREMENT;
        }
        if (TempArmor.RequiredFloorCleared > PlayerData.s_Instance.MaxFloor && TempArmor.Cost > PlayerData.s_Instance.Gold)
        {
            m_ArmorShopKeeperDialogue.text = ShopDialogues.ARMOR_PURCHASE_UNSUCCESFUL_NO_REQUIREMENTS_MET;
        }

        if (TempArmor.Cost <= PlayerData.s_Instance.Gold && TempArmor.RequiredFloorCleared <= PlayerData.s_Instance.MaxFloor)
        {
            EquipGear.s_Instance.EquipArmor(TempArmor, true);
            PlayerData.s_Instance.CurrentHealth += TempArmor.MaxHealthBonus;
            PlayerData.s_Instance.CurrentMana += (TempArmor.IntellectBonus * 5);
            m_ArmorShopKeeperDialogue.text = ShopDialogues.ARMOR_PURCHASE_SUCCESFUL;
            PlayerData.s_Instance.Gold -= TempArmor.Cost;
            if (GoldDelegateManager.s_UpdateGoldUI != null)
            {
                GoldDelegateManager.s_UpdateGoldUI();
            }
        }
    }

    void LoadArmors()
    {
        for (int i = 0; i < EquipmentDictionaries.s_Armors.Count; i++)
        {
            if (i != 0) // Skips default Armor "None"
            {
                Armor TempArmor = EquipmentDictionaries.s_Armors[i];
                EquipmentContainer TempContainer = Instantiate(m_ArmorContainer);
                TempContainer.transform.SetParent(m_ShopContainer.transform);
                TempContainer.transform.localScale = Vector3.one;
                TempContainer.LoadEquipment(TempArmor);
                TempContainer.SelectButton.onClick.AddListener(() => SelectArmor(TempArmor.ID));
            }
        }
    }
}