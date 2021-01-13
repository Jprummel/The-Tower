using UnityEngine;
using DG.Tweening;

public class CharacterCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle")
        {
            DOTween.Kill(1);
            ActionBar.s_Instance.AddUnavailableAction("Move Backwards");
            CombatTurns.s_OnActionCompleted();
        }
        else
        {
            DOTween.Kill(1);
            CalculateStats.s_Instance.IsInRange = true;
            ActionBar.s_Instance.AddUnavailableAction("Move Forward");
            ActionBar.s_Instance.RemoveUnavailableAction("Grapple");
            CombatTurns.s_OnActionCompleted();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Obstacle")
            ActionBar.s_Instance.RemoveUnavailableAction("Move Backwards");
        else
        {
            CalculateStats.s_Instance.IsInRange = false;
            ActionBar.s_Instance.RemoveUnavailableAction("Move Forward");
            ActionBar.s_Instance.AddUnavailableAction("Grapple");
        }
    }
}