using UnityEngine;

public class ShadowBeam : Ability
{
    public ShadowBeam()
    {
        AbilityName = AbilityNames.SHADOWBEAM;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 50;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        int damage = 50 + (CombatTurns.s_Instance.ActiveCharacter.Intellect * 2);

        int finalDamage = CombatCalculations.s_Instance.CalculateMagicDamage((int)damage);

        if (CombatCalculations.s_Instance.CalculateIfHit(85))
        {
            float hp = Mathf.Clamp(CombatTurns.s_Instance.ActiveCharacter.CurrentHealth + CombatTurns.s_Instance.ActiveCharacter.Intellect, 0, CombatTurns.s_Instance.ActiveCharacter.MaxHealth + CombatTurns.s_Instance.ActiveCharacter.MaxHealthBonus);
            float healing = hp - CombatTurns.s_Instance.ActiveCharacter.CurrentHealth;
            CombatTurns.s_Instance.ActiveCharacter.CurrentHealth = hp;

            DealDamage(999, "Shadow Beam", finalDamage);

            HealingPopup.s_Instance.PopupAnimation(CombatTurns.s_Instance.ActiveCharacter.transform.position, (int)healing, !CombatTurns.s_Instance.ActiveCharacter.RightSide);
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Shadow Beam, but <color=grey>missed</color>!", 1.5f, "Shadow Beam");
        }
        BattleUI.s_UpdateBothInfo();
    }
}