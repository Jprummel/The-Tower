using UnityEngine;
using UnityEngine.EventSystems;

public class ShopClick : MonoBehaviour {

    private void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (gameObject.tag == "Weaponsmith")
            {
                PanelManager.s_Instance.TogglePanel("WeaponShopPanel");
            }
            else if (gameObject.tag == "ShieldVendor")
            {
                PanelManager.s_Instance.TogglePanel("ShieldShopPanel");
            }
            else if(gameObject.tag == "Armorsmith")
            {
                PanelManager.s_Instance.TogglePanel("ArmorShopPanel");
            }else if(gameObject.tag == "Church")
            {
                PanelManager.s_Instance.TogglePanel("ChurchPanel");
            }
        }
    }
}