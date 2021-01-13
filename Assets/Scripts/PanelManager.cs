using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    public static PanelManager s_Instance;

    [SerializeField] private List<Panel> m_Panels = new List<Panel>();
    private Panel m_CurrentOpenPanel;
    public bool IsAnyPanelOpen
    {
        get { return (m_CurrentOpenPanel != null) ? true : false; }
    }

	void Awake () {
		if(s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    public void ShowPanel(string PanelName)
    {
        for (int i = 0; i < m_Panels.Count; i++)
        {
            if (m_Panels[i].name == PanelName)
                ShowPanel(m_Panels[i]);
        }
    }

    public void ShowPanel(Panel Panel)
    {
        if (IsAnyPanelOpen)
        {
            m_CurrentOpenPanel.Hide();
            m_CurrentOpenPanel = null;
        }
        Panel.Show();
        m_CurrentOpenPanel = Panel;
    }

    public void HidePanel(string PanelName)
    {
        for (int i = 0; i < m_Panels.Count; i++)
        {
            if (m_Panels[i].name == PanelName)
            {
                HidePanel(m_Panels[i]);
            }
        }
    }

    public void HidePanel(Panel Panel)
    {
        Panel.Hide();
    }

    public void TogglePanel(Panel Panel)
    {
        if (IsAnyPanelOpen)
        {
            if (m_CurrentOpenPanel != Panel)
            {
                m_CurrentOpenPanel.Hide();
                Panel.Show();
                m_CurrentOpenPanel = Panel;
            }
            else
            {
                m_CurrentOpenPanel = null;
                Panel.Hide();
            }
        }
        else
        {
            Panel.Show();
            m_CurrentOpenPanel = Panel;
        }
    }

    public void TogglePanel(string PanelName)
    {
        for (int i = 0; i < m_Panels.Count; i++)
        {
            if(m_Panels[i].name == PanelName)
            {
                TogglePanel(m_Panels[i]);
            }
        }
    }
}