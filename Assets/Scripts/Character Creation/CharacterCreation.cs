using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterCreation : MonoBehaviour {

    public static CharacterCreation s_Instance;

    [SerializeField] private SpriteRenderer m_CharacterSprite;
    [SerializeField] private InputField m_NameField;
    [SerializeField] private Button m_StartButton;
    [SerializeField] private Text m_ClassText;

    //Data to be saved as CharacterData
    private string m_CharacterName;

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        if(GameDistribution.Instance != null)
        {
            GameDistribution.Instance.ShowAd();
        }
    }

    void Start () {
        PlayerData.s_Instance.CharacterColorCode = ColorConfig.RED;
        ChooseColor(ColorConfig.ConvertHexColor(ColorConfig.RED));
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        PlayerData.s_Instance.SetStatsToDefault(false);
        StatPanel.s_Instance.DisplayStatPoints();
    }

    public void ChooseColor(Color color)
    {
        m_CharacterSprite.DOColor(color, 0.3f); //Preview of color on character
        PlayerData.s_Instance.CharacterColor = color;
    }

    public void NameCharacter()
    {
        PlayerData.s_Instance.Name = m_NameField.text;
        if(m_NameField.text != "")
        {
            m_StartButton.interactable = true;
        }
        if(m_NameField.text == "Admin")
        {
            PlayerData.s_Instance.Strength = 999;
            PlayerData.s_Instance.Stamina = 999;
            PlayerData.s_Instance.Intellect = 999;
            PlayerData.s_Instance.AvailableTalentPoints = 100;
        }
    }

    public void SaveNewCharacter(int Tutorial)
    {
        SaveLoadEquipment.s_Instance.SaveEquipedShield();
        SaveLoadEquipment.s_Instance.SaveEquipedWeapon();
        SaveLoadPlayerData.s_Instance.SavePlayer();

        if (Tutorial == 1)
            PlayerPrefs.SetInt("Tutorial", 1);
        else
            PlayerPrefs.SetInt("Tutorial", 0);

    }

    public void ChooseClass(string Class)
    {
        switch (Class)
        {
            case "Magician":
                PlayerData.s_Instance.Class = Classes.Magician.ToString();
                m_ClassText.text = "Your class: " + Classes.Magician.ToString();
                break;
            case "Warrior":
                PlayerData.s_Instance.Class = Classes.Warrior.ToString();
                m_ClassText.text = "Your class: " + Classes.Warrior.ToString();
                break;
            case "Ninja":
                PlayerData.s_Instance.Class = Classes.Ninja.ToString();
                m_ClassText.text = "Your class: " + Classes.Ninja.ToString();
                break;
        }
    }
}