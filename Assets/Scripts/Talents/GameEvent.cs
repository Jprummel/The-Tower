using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> m_Listeners = new List<GameEventListener>();

    public void TalentClicked()
    {
        for (int i = m_Listeners.Count - 1; i >= 0; i--)
        {
            m_Listeners[i].OnEventClicked();
        }
    }

    public void TalentHovered()
    {
        for (int i = m_Listeners.Count - 1; i >= 0; i--)
        {
            m_Listeners[i].OnEventHovered();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        m_Listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        m_Listeners.Remove(listener);
    }
}