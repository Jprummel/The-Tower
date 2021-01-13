using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TalentClasses
{
    //Neutral,
    Magician,
    Ninja,
    Warrior
}

[CreateAssetMenu(fileName = "New Talent", menuName = "Talent", order = 51)]
public class TalentData : ScriptableObject
{
    [SerializeField] private string m_TalentName;
    [SerializeField] private string m_TalentDescription;
    [SerializeField] private int m_TalentID;
    [SerializeField] private int m_MaxTalentLevel;
    [SerializeField] private int m_CurrentTalentLevel;
    [SerializeField] private int m_RequiredTalentID;
    [SerializeField] private bool m_IsActivatable;
    [SerializeField] private bool m_IsPassive;
    [SerializeField] private Sprite m_TalentIcon;
    [SerializeField] private List<string> m_TalentLevelValues = new List<string>();
    [SerializeField] private int m_ManaCost;
    [SerializeField] private WeaponTypes m_RequiredWeaponType;
    [SerializeField] private TalentClasses m_TalentClass;
    [SerializeField] private int m_Cooldown;

    public string TalentName
    {
        get { return m_TalentName; }
    }

    public string TalentDescription
    {
        get { return m_TalentDescription; }
    }

    public int TalentID
    {
        get { return m_TalentID; }
    }

    public int MaxTalentLevel
    {
        get { return m_MaxTalentLevel; }
    }

    public int CurrentTalentLevel
    {
        get { return m_CurrentTalentLevel; }
    }

    public int RequiredTalentID
    {
        get { return m_RequiredTalentID; }
    }

    public bool IsActivatable
    {
        get { return m_IsActivatable; }
    }

    public bool IsPassive
    {
        get { return m_IsPassive; }
    }

    public Sprite TalentIcon
    {
        get { return m_TalentIcon; }
    }

    public List<string> TalentLevelValues
    {
        get { return m_TalentLevelValues; }
    }

    public int ManaCost
    {
        get { return m_ManaCost; }
    }

    public WeaponTypes RequiredWeaponType
    {
        get { return m_RequiredWeaponType; }
    }

    public TalentClasses TalentClass
    {
        get { return m_TalentClass; }
    }

    public int Cooldown
    {
        get { return m_Cooldown; }
    }
}
