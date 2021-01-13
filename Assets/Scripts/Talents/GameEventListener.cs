using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]private GameEvent m_GameEvent;
    [SerializeField]private UnityEvent m_TalentClicked;
    [SerializeField]private UnityEvent m_TalentHovered;

    private void OnEnable()
    {
        m_GameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_GameEvent.UnregisterListener(this);
    }

    public void OnEventClicked()
    {
        m_TalentClicked.Invoke();
    }

    public void OnEventHovered()
    {
        m_TalentHovered.Invoke();
    }
}