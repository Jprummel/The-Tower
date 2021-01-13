using UnityEngine;
using DG.Tweening;

public class CombatActions : MonoBehaviour {

    public static void SkipTurn()
    {
        ActionBar.s_Instance.ToggleAllActions(false);

        Sequence waitSequence = DOTween.Sequence();
        waitSequence.AppendInterval(1f);
        waitSequence.AppendCallback(() => CombatTurns.s_OnActionCompleted());
    }

    public virtual void MoveForward()
    {
        ActionSelected();
        if (!CalculateStats.s_Instance.IsInRange)
        {
            float ExtraMovement = CombatTurns.s_Instance.ActiveCharacter.Agility * 0.05f;
            if (ExtraMovement > 1.5f)
            {
                ExtraMovement = 1.5f;
            }

            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " moved forward!", 1.5f, "Move Forward");
            float position;

            if (!CombatTurns.s_Instance.ActiveCharacter.RightSide)
                position = transform.position.x + 1.5f + ExtraMovement;
            else
                position = transform.position.x - 1.5f - ExtraMovement;

            transform.DOMoveX(position, 0.75f).SetId(1).OnComplete(() => ActionFinished());
        }
        else
        {
            ActionFinished();
        }
    }

    public virtual void MoveBackwards()
    {
        ActionSelected();
        float ExtraMovement = CombatTurns.s_Instance.ActiveCharacter.Agility * 0.05f;
        if (ExtraMovement > 1.5f)
        {
            ExtraMovement = 1.5f;
        }
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " moved backwards!", 1.5f, "Move Backwards");
        float position = 69;

        if (!CombatTurns.s_Instance.ActiveCharacter.RightSide)
            position = transform.position.x - 1.5f - ExtraMovement;
        else
            position = transform.position.x + 1.5f + ExtraMovement;

        transform.DOMoveX(position, 0.75f).SetId(1).OnComplete(() =>ActionFinished());
    }

    public virtual void Grapple()
    {
        WaitToCompleteAction();
        Transform opponentTransform = OpponentCombatAI.s_GetOpponentTransform();

        float grapplerPos = transform.position.x;
        float grappledPos = opponentTransform.position.x;

        transform.DOMoveX(grappledPos, 0.75f).SetId(1);
        opponentTransform.DOMoveX(grapplerPos, 0.75f).SetId(1);

        CombatTurns.s_Instance.IdleCharacter.RightSide = !CombatTurns.s_Instance.IdleCharacter.RightSide;
        CombatTurns.s_Instance.ActiveCharacter.RightSide = !CombatTurns.s_Instance.ActiveCharacter.RightSide;

        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used grapple to switch positions!", 1.5f,"Grapple");
    }

    public virtual void Shoot()
    {
        ActionSelected();
        Attack(80, 0.9f, "a ranged attack");
        WaitToCompleteAction();
    }

    public virtual void Shoot(int hitChance, float damageModifier, string attackName, float bonusDamage = 0f,bool isAbility = true)
    {
        ActionSelected();
        Attack(hitChance, damageModifier, attackName, bonusDamage);
        if (!isAbility)
        {
            WaitToCompleteAction();
        }
    }

    public virtual void LightAttack()
    {
        ActionSelected();
        Attack(99, 0.8f, "light attack");
        WaitToCompleteAction();
    }

    public virtual void NormalAttack()
    {
        ActionSelected();
        Attack(85, 1f, "normal attack");
        WaitToCompleteAction();
    }

    public virtual void HeavyAttack()
    {
        ActionSelected();
        Attack(70, 1.2f, "heavy attack");
        WaitToCompleteAction();
    }

    public virtual void SpecialAttack(int hitChance, float damageModifier, string attackName,bool isAbility = true, bool autoFinish = false)
    {
        ActionSelected();
        Attack(hitChance, damageModifier, attackName);
        if (autoFinish && !isAbility)
        {
            WaitToCompleteAction();
        }
    }

    public virtual void Rest()
    {
        //Restores 10% health and 5% mana
        ActionSelected();
        WaitToCompleteAction();

        Character ActiveCharacter = CombatTurns.s_Instance.ActiveCharacter;
        int HealthRestored = (int)(ActiveCharacter.MaxHealth + ActiveCharacter.MaxHealthBonus) / 10;
        int ManaRestored = (int)(ActiveCharacter.MaxMana + ActiveCharacter.MaxManaBonus) / 5;

        float hp = Mathf.Clamp(ActiveCharacter.CurrentHealth + HealthRestored, 0, ActiveCharacter.MaxHealth + ActiveCharacter.MaxHealthBonus);
        float healing = hp - ActiveCharacter.CurrentHealth;
        HealingPopup.s_Instance.PopupAnimation(ActiveCharacter.transform.position, (int)healing, !ActiveCharacter.RightSide);
        CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " Rested, and restored some health and mana!" , 1.5f, "Rest");

        ActiveCharacter.CurrentHealth = hp;

        float mp = Mathf.Clamp(ActiveCharacter.CurrentMana + ManaRestored, 0, ActiveCharacter.MaxMana + ActiveCharacter.MaxManaBonus);

        ActiveCharacter.CurrentMana = mp;
        AudioManager.s_Instance.PlaySoundEffect("Heal");
        BattleUI.s_UpdateBothInfo();
    }

    public virtual void Attack(int hitChance, float damageModifier, string attackName, float bonusDamage = 0f)
    {
        float Range = CombatTurns.s_Instance.ActiveCharacter.Weapon.Range;

        if (CombatCalculations.s_Instance.CalculateIfInRange(Range))
        {
            int damage = (int)CombatCalculations.s_Instance.CalculateDamage(damageModifier) + (int)bonusDamage;
            DealDamage(hitChance, attackName, damage);
        }
        else
        {
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + attackName + ", but is out of range!", 1.5f, attackName);
        }
    }
    public virtual void DealDamage(int hitChance, string attackName, float attackDamage, bool showNotification = true)
    {
        if (CombatCalculations.s_Instance.CalculateIfHit(hitChance))
        {
            float damage = attackDamage + CombatTurns.s_Instance.ActiveCharacter.ExtraDamage;

            if(CombatTurns.s_Instance.ActiveCharacter == PlayerData.s_Instance)
            {
                if (TalentManager.s_Instance.HasAbility("Mercy") && CombatTurns.s_Instance.IdleCharacter.CurrentHealth < (CombatTurns.s_Instance.IdleCharacter.MaxHealth + CombatTurns.s_Instance.IdleCharacter.MaxHealthBonus) / 2)
                    damage = Mathf.RoundToInt(damage * 1.25f);

                if (TalentManager.s_Instance.HasAbility("Berserk"))
                    damage = Mathf.RoundToInt(damage * 1.20f);

                if (TalentManager.s_Instance.HasAbility("Rage"))
                {
                    float maxHP = CombatTurns.s_Instance.ActiveCharacter.MaxHealth + CombatTurns.s_Instance.ActiveCharacter.MaxHealthBonus;
                    float damageAmp = (100 - (CombatTurns.s_Instance.ActiveCharacter.CurrentHealth / (maxHP / 100)));
                    Mathf.RoundToInt(damageAmp);
                    damage = Mathf.RoundToInt(damage / 100 * (100 + damageAmp));
                }
            }

            CombatTurns.s_Instance.ActiveCharacter.ExtraDamage = 0;
            float Finaldamage = damage * CombatTurns.s_Instance.IdleCharacter.DamageAmplifier;

            Camera.main.DOShakePosition(0.2f, 0.3f, 9, 70); //Screen shakes when damage is dealt

            CombatTurns.s_Instance.IdleCharacter.TakeDamage((int)damage);
            

            if(showNotification)
                CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + attackName + ", and dealt <color=red>" + (int)Finaldamage + "</color> damage!", 1.5f, attackName);        
        }else
            CombatNotification.s_Instance.AddNotification(CombatTurns.s_Instance.ActiveCharacter.Name + " used " + attackName + ", but <color=grey>missed</color>!", 1.5f, attackName);
    }

    public void ActionSelected()
    {
        ActionBar.s_Instance.ToggleAllActions(false);
    }

    public void ActionFinished()
    {
        CombatTurns.s_OnActionCompleted();
    }

    public void WaitToCompleteAction(float time = 1f)
    {
        Sequence waitSequence = DOTween.Sequence();
        waitSequence.AppendInterval(time);
        waitSequence.AppendCallback(() => ActionFinished());
    }
}