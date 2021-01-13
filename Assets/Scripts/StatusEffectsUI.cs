using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectsUI : MonoBehaviour
{
    [SerializeField] private Image StatusEffects;

    // Update is called once per frame
    void Update()
    {
        Vector2 UIPosition = Camera.main.WorldToScreenPoint(transform.position);
        StatusEffects.transform.position = UIPosition;
    }
}
