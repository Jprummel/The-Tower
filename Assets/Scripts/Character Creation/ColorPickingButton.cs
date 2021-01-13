using UnityEngine;
using UnityEngine.UI;
public class ColorPickingButton : MonoBehaviour {

    private Image m_ColorButtonImage;

    private void Awake()
    {
        m_ColorButtonImage = GetComponent<Image>();
    }

    public void ChooseColor(string ColorCode)
    {
        CharacterCreation.s_Instance.ChooseColor(m_ColorButtonImage.color);
        PlayerData.s_Instance.CharacterColorCode = ColorCode;
    }
}
