using UnityEngine;
using UnityEngine.UI;

public class SetAbility : MonoBehaviour
{
    public static SetAbility s_Instance;

    private void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetAbilityMethod(string abilityName)
    {
        AbilityDictionary.s_Abilities[abilityName].UseAbility();
    }

    public void SetAbilityOnButton(Button button, TalentData talent)
    {
        button.gameObject.name = talent.TalentName;
        button.gameObject.GetComponent<AbilityDescriptionHandler>().Talent = talent;
        button.onClick.AddListener(()=>SetAbilityMethod(talent.TalentName));
        if (talent.RequiredWeaponType.ToString() != WeaponTypes.Any.ToString() && talent.RequiredWeaponType.ToString() != PlayerData.s_Instance.Weapon.WeaponRangeType)
            ActionBar.s_Instance.AddUnavailableAction(talent.TalentName);
    }

    public TalentData GetAbilityByName(string abilityName)
    {
        for (int i = 0; i < PlayerAbilityManager.s_ActivePlayerAbilities.Count; i++)
        {
            if (PlayerAbilityManager.s_ActivePlayerAbilities[i].TalentName == abilityName)
                return PlayerAbilityManager.s_ActivePlayerAbilities[i];
        }

        return null;
    }
}