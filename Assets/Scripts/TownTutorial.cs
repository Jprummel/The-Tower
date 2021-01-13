using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownTutorial : MonoBehaviour
{
    private void Awake()
    {
        if(PlayerPrefs.GetInt("Tutorial") == 1)
        {
            ScreenEffects.s_Instance.Fade(1f, 0.5f);
        }
    }
}
