using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {

    public static ActionBar s_Instance;
    private List<string> m_UnavailableActions = new List<string>();
    [SerializeField] private List<GameObject> m_AbilityButtons = new List<GameObject>();
    [SerializeField] private List<Text> m_AbilityCooldowns = new List<Text>();

    private void Awake()
    {
        Init();
        StartCoroutine(LateStart());
        AddUnavailableAction("Grapple");
        ToggleGeneralAttackActions();
    }

    private void ToggleGeneralAttackActions()
    {
        if (PlayerData.s_Instance.Weapon.WeaponRangeType == WeaponTypes.Ranged.ToString())
        {
            AddUnavailableAction("Light Attack");
            AddUnavailableAction("Normal Attack");
            AddUnavailableAction("Heavy Attack");
        }
        else if (PlayerData.s_Instance.Weapon.WeaponRangeType == WeaponTypes.Melee.ToString())
            AddUnavailableAction("Shoot");
        else if (PlayerData.s_Instance.Weapon.WeaponRangeType == WeaponTypes.Any.ToString())
            return;
    }

    private void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        AddActions();
        ToggleAllActions(true);
    }

    public void ToggleAllActions(bool active)
    {
        if (CombatTurns.s_Instance.ActiveCharacter.Disabled)
            DisableAbilities();
        else
            EnableAbilities();

        foreach (Transform child in transform)
        {
            Button currentAction;

            currentAction = child.GetComponent<Button>();
            currentAction.interactable = active;          

            for (int i = 0; i < m_UnavailableActions.Count; i++)
            {
                if (child.gameObject.name == m_UnavailableActions[i])
                {
                    currentAction = child.GetComponent<Button>();
                    currentAction.interactable = false;
                    AbilityDescription.s_Instance.DisableText();
                }
            }
        }
    }

    public void AddUnavailableAction(string action)
    {
        m_UnavailableActions.Add(action);
    }

    public void RemoveUnavailableAction(string action)
    {
        m_UnavailableActions.Remove(action);
    }

    public void AddActions()
    {
        for (int i = 0; i < PlayerAbilityManager.s_ActivePlayerAbilities.Count; i++)
        {
            m_AbilityButtons[i].GetComponent<Image>().sprite = PlayerAbilityManager.s_ActivePlayerAbilities[i].TalentIcon;
            SetAbility.s_Instance.SetAbilityOnButton(m_AbilityButtons[i].GetComponent<Button>(), PlayerAbilityManager.s_ActivePlayerAbilities[i]);
            m_AbilityButtons[i].SetActive(true);
        }
    }

    public void DisableAbilities()
    {
        for (int i = 0; i < m_AbilityButtons.Count; i++)
        {
            if (m_AbilityButtons[i].activeInHierarchy)
                AddUnavailableAction(m_AbilityButtons[i].name);
        }
    }

    public void ClearCooldowns()
    {
        PlayerAbilityManager.s_PlayerCooldowns.Clear();
        for (int i = 0; i < m_AbilityCooldowns.Count; i++)
        {
            m_AbilityCooldowns[i].text = string.Empty;
        }
    }

    public void EnableAbilities()
    {
        for (int i = 0; i < m_AbilityButtons.Count; i++)
        {
            if (m_AbilityButtons[i].activeInHierarchy)
            {
                TalentData ability;
                ability = SetAbility.s_Instance.GetAbilityByName(m_AbilityButtons[i].name);

                Text cooldown = m_AbilityButtons[i].GetComponentInChildren<Text>();

                if (ability.RequiredWeaponType.ToString() != WeaponTypes.Any.ToString() && ability.RequiredWeaponType.ToString() == PlayerData.s_Instance.Weapon.WeaponRangeType)
                {

                    if (!PlayerAbilityManager.s_PlayerCooldowns.ContainsKey(ability.TalentName))
                    {
                        RemoveUnavailableAction(ability.TalentName);
                        cooldown.text = string.Empty;
                    }
                    else
                    {
                           
                        if (cooldown != null)
                        {
                            cooldown.text = PlayerAbilityManager.s_PlayerCooldowns[ability.TalentName].ToString();
                        }
                    }
                }
                else if(ability.RequiredWeaponType.ToString() == WeaponTypes.Any.ToString())
                {
                    if (!PlayerAbilityManager.s_PlayerCooldowns.ContainsKey(ability.TalentName))
                    {
                        RemoveUnavailableAction(ability.TalentName);
                        cooldown.text = string.Empty;
                    }
                    else
                    {
                        if (cooldown != null)
                        {
                            cooldown.text = PlayerAbilityManager.s_PlayerCooldowns[ability.TalentName].ToString();
                        }
                    }
                }
            }
        }
    }
}
