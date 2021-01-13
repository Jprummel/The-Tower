using UnityEngine;

public class Fireball : Ability
{
    public Fireball()
    {
        AbilityName = AbilityNames.FIREBALL;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 25;
        Cooldown = 2;
    }

    public override void AbilityEffect()
    {
        int damage = PlayerPrefs.GetInt("Fireball Talent Level") * 4 * CombatTurns.s_Instance.ActiveCharacter.Level + CombatTurns.s_Instance.ActiveCharacter.Intellect;
        AudioManager.s_Instance.PlaySoundEffect("Fireball");

        if (CombatCalculations.s_Instance.CalculateIfHit(90))
        {
            DealDamage(999, "Fireball", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
            if (TalentManager.s_Instance.HasAbility("Upgrade Fireball"))
            {
                if (CombatCalculations.s_Instance.CalculateIfHit(34))
                {
                    WaitToAddNotification("And applied Ignite!", 1.5f, "Ignite");
                    Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 3, DebuffNames.Ignite, "Ignite", value: (int)(CombatTurns.s_Instance.IdleCharacter.MaxHealth + CombatTurns.s_Instance.IdleCharacter.MaxHealthBonus) / 100 * 10);
                }
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Fireball, but <color=grey>missed</color>!", 1.5f,"Fireball");

        }
        AudioManager.s_Instance.PlaySoundEffect("Fireball");
        BattleUI.s_UpdateBothInfo();
        base.AbilityEffect();
    }
}