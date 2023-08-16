using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private float baseValue;
    private List<float> modifiers = new List<float>();
    private Sprite icon;

    public float GetValue()
    {
        float totalValue = baseValue;
        for (int i = 0; i < modifiers.Count; i++)
        {
            totalValue += modifiers[i];   
        }
        return totalValue;
    }

    public void AddModifier(float amount)
    {
        if (amount != 0)
        {
            modifiers.Add(amount);
        }
    }
    public void RemoveModifier(float amount)
    {
        if (amount != 0)
        {
            modifiers.Remove(amount);
        }
    }
}
