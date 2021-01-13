using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOpponent : MonoBehaviour {

    private void OnMouseUp()
    {
        //If the player did not click on a UI element in front of the opponent.
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            CombatInfo.s_Instance.Opponent = GetComponent<Opponent>();
            CombatInfo.s_Instance.ToggleInfo();
        }
    }
}
