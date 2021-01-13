using UnityEngine;
using UnityEngine.EventSystems;

public class TowerEnter : MonoBehaviour {

    private bool m_Clickable = true;

    private void OnMouseUp()
    {
        if (m_Clickable)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                SaveLoadPlayerData.s_Instance.SavePlayer();
                SceneLoader.s_Instance.LoadSceneWithFade("Tower");
                ScreenEffects.s_Instance.FadeIn(0.5f);
                m_Clickable = false;
            }
        }
    }
}