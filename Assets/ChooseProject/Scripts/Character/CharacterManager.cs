using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    public event Action OnStatsChanged;

    public CharacterStats FinalStats => finalStats;
    private readonly List<StatModifier> modifiers = new();

    [SerializeField]
    private CharacterData[] characterClasses;

    private CharacterStats baseStats;

    private CharacterStats finalStats;


    private void Awake()
    {

        SelectCharacter(0);

        RecalculateStats();

    }


    public void SelectCharacter(int index)
    {
        if (index < 0 || index >= characterClasses.Length) return;

        ChangeCharacter(characterClasses[index]);
    }
    public void AddRandomModifier()
    {
        StatModifier modifier = new()
        {
            StatType = (StatType)Random.Range(0, 4),

            Value = Random.Range(10, 31)
        };

        modifiers.Add(modifier);

        RecalculateStats();
    }

    public void RemoveLastModifier()
    {
        if (modifiers.Count == 0)
            return;

        modifiers.RemoveAt(modifiers.Count - 1);
        RecalculateStats();
    }

    private void ChangeCharacter(CharacterData data)
    {
        modifiers.Clear();

        baseStats = CreateStats(data);

        RecalculateStats();
    }

    private CharacterStats CreateStats(CharacterData data)
    {
        CharacterStats stats = new();

        foreach (Stats stat in data.BaseStats)
        {
            stats.Stats.Add(new Stats()
            {
                Type = stat.Type,
                Value = stat.Value
            });
        }

        return stats;
    }

    private void RecalculateStats()
    {

        finalStats = (CharacterStats)baseStats.Clone();

        foreach (StatModifier modifier in modifiers)
        {
            finalStats.AddValue(modifier.StatType, modifier.Value);
        }

        OnStatsChanged?.Invoke();

    }
}