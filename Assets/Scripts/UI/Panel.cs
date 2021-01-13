using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {

    public bool IsPanelOpen {get; set;}

    public void Show()
    {
        IsPanelOpen = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        IsPanelOpen = false;
        gameObject.SetActive(false);
    }
}
