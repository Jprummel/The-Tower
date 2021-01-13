using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    private SpriteRenderer m_Sprite;

	void Start ()
    {
        SaveLoadEquipment.s_Instance.LoadEquippedWeapon();
        SaveLoadEquipment.s_Instance.LoadEquippedShield();
        SaveLoadEquipment.s_Instance.LoadEquippedArmor();
        StartCoroutine(LateStart());
	}

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        m_Sprite = GetComponent<SpriteRenderer>();
        m_Sprite.color = PlayerData.s_Instance.CharacterColor;
    }
}