using UnityEngine;

public class LightningBolt : Ability
{
    public LightningBolt()
    {
        AbilityName = AbilityNames.LIGHTNING_BOLT;
        AbilityType = AbilityTypes.Ranged;
        Range = 50f;
        ManaCost = 35;
        Cooldown = 3;
    }

    public override void AbilityEffect()
    {
        AudioManager.s_Instance.PlaySoundEffect("Lightning Bolt");

        float damage = (PlayerPrefs.GetInt("Lightning Bolt Talent Level") * 25) + (CombatTurns.s_Instance.ActiveCharacter.Intellect * 2);

        if (CombatCalculations.s_Instance.CalculateIfHit(85))
        {
            DealDamage(999, "Lightning Bolt", CombatCalculations.s_Instance.CalculateMagicDamage((int)damage));
            if (TalentManager.s_Instance.HasAbility("Upgrade Lightning Bolt"))
            {
                if (CombatCalculations.s_Instance.CalculateIfHit(40))
                {
                    WaitToAddNotification("And applied a stun!", 1.5f, "Lightning Bolt");
                    Debuffs.s_Instance.AddDebuff(CombatTurns.s_Instance.IdleCharacter, 1, DebuffNames.Stun, "LightningBolt");
                }
            }
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used Lightning Bolt, but <color=grey>missed</color>!", 1.5f, "Lightning Bolt");
        }
        BattleUI.s_UpdateEnemyInfo();
    }
}