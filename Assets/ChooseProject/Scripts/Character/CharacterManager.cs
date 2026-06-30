using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private List<StatModifier> modifiers = new();



    public void AddRandomModifier()
    {
        StatModifier modifier = new StatModifier();

        modifier.StatType = (StatType)Random.Range(0, 4);

        modifier.Value = Random.Range(10, 31);

        modifiers.Add(modifier);
    }

    public void RemoveLastModifier()
    {
        if (modifiers.Count == 0)
            return;

        modifiers.RemoveAt(modifiers.Count - 1);
    }
}