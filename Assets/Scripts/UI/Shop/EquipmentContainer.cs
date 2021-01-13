using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentContainer : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image m_EquipmentIcon;
    public Button SelectButton;
    public Equipment Equipment;

    public void LoadEquipment(Equipment EquipmentToLoad)
    {
        Equipment = EquipmentToLoad;
        m_EquipmentIcon.sprite = Resources.Load<Sprite>("EquipmentIcons/"+ Equipment.EquipmentType + "/" + Equipment.ImageName);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LoadEquipmentInfo.s_OnLoadEquipment(Equipment);
    }
}