using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    public event Action OnStatsChanged;

    public CharacterStats FinalStats => finalStats;
    private readonly List<StatModifier> modifiers = new();
    public IReadOnlyList<StatModifier> Modifiers => modifiers;

    [SerializeField]
    private CharacterData[] characterClasses;

    private CharacterStats baseStats;

    private CharacterStats finalStats;


    private void Awake()
    {

        SelectCharacter(0);

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
            StatType = GetRandomStat(),
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
        CharacterStats result = new();

        foreach (Stats stat in data.BaseStats)
        {
            result.Stats.Add(new Stats
            {
                Type = stat.Type,
                Value = stat.Value
            });
        }

        return result;
    }

    public void ResetCharacter()
    {
        modifiers.Clear();

        RecalculateStats();
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

    private StatType GetRandomStat()
    {
        return baseStats.GetRandomStatType();
    }
}