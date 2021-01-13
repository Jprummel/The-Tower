using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookPanels : MonoBehaviour
{
      
    public void OpenPanel(GameObject panelToOpen)
    {
        panelToOpen.SetActive(true);
    }

    public void ClosePanel(GameObject panelToClose)
    {
        panelToClose.SetActive(false);
    }
}
