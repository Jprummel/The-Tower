using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class VitalsDisplay : MonoBehaviour {

    public static VitalsDisplay s_Instance;

    private Sequence m_HealthbarSequence;

    private void Awake()
    {
        m_HealthbarSequence = DOTween.Sequence();

        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void DisplayHealth(Character Character,Image HealthBar, Text HealthValue)
    {
        m_HealthbarSequence.Append(HealthBar.DOFillAmount(Character.CurrentHealth / (Character.MaxHealth + Character.MaxHealthBonus), 0.3f));
        HealthValue.text = Character.CurrentHealth + " / " + (Character.MaxHealth + Character.MaxHealthBonus);
        if(Character.CurrentHealth <= 0)
        {
            HealthValue.text = 0 + " / " + (Character.MaxHealth+ Character.MaxHealthBonus);
        }
    }

    public void DisplayMana(Character Character, Image ManaBar, Text ManaValue)
    {
        ManaBar.DOFillAmount(Character.CurrentMana / (Character.MaxMana + Character.MaxManaBonus), 0.3f);
        ManaValue.text = Character.CurrentMana + " / " + (Character.MaxMana + Character.MaxManaBonus);
        if (Character.CurrentMana <= 0)
        {
            ManaValue.text = 0 + " / " + (Character.MaxMana + Character.MaxManaBonus);
        }
    }

    public void DisplayShield(Character Character, Image ShieldBar)
    {
        m_HealthbarSequence.Append(ShieldBar.DOFillAmount(Character.ShieldValue / Character.MaxHealth, 0.1f));
    }

    private IEnumerator DisplayHealthWithDelay(Character Character, Image HealthBar, Text HealthValue)
    {
        yield return new WaitForSeconds(0.2f);
        HealthBar.DOFillAmount(Character.CurrentHealth / (Character.MaxHealth + Character.MaxHealthBonus), 0.3f);
        HealthValue.text = Character.CurrentHealth + " / " + (Character.MaxHealth + Character.MaxHealthBonus);
    }
}
