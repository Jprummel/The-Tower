using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChanceManager : MonoBehaviour {

    public static HitChanceManager s_Instance;

    public Dictionary<string, int> HitChances = new Dictionary<string, int>();

    private void Awake()
    {
        Init();
        HitChances.Add("Light Attack", 99);
        HitChances.Add("Normal Attack", 85);
        HitChances.Add("Heavy Attack", 70);
    }

    void Init()
    {
        if (s_Instance == null)
            s_Instance = this;
        else
            Destroy(gameObject);
    }

    public int GetHitChanceByName(string name)
    {
        foreach (KeyValuePair<string, int> hitChance in HitChances)
        {
            if (name == hitChance.Key)
                return hitChance.Value;
        }
        return 0;
    }
}
