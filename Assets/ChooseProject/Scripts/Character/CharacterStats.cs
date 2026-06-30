using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : ICloneable
{
    [SerializeField]
    private readonly List<Stats> stats = new();

    public object Clone()
    {
        CharacterStats clone = new();

        foreach (Stats stat in stats)
        {
            clone.stats.Add(new Stats()
            {
                Type = stat.Type,
                Value = stat.Value
            });
        }

        return clone;
    }


    public int GetValue(StatType type)
    {
        Stats stat = stats.Find(s => s.Type == type);

        if (stat == null)
            return 0;

        return stat.Value;
    }
    public void AddStat(Stats stat)
    {
        stats.Add(stat);
    }

    public void AddValue(StatType type, int value)
    {
        Stats stat = stats.Find(s => s.Type == type);

        if (stat != null)
            stat.Value += value;
    }

    public StatType GetRandomStatType()
    {
        int randomIndex = UnityEngine.Random.Range(0, stats.Count);

        return stats[randomIndex].Type;
    }

    public int GetPower()
    {
        int power = 0;

        foreach (Stats stat in stats)
        {
            power += stat.Value;
        }

        return power;
    }
}