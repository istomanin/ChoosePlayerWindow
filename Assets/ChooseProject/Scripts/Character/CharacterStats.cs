using System;
using System.Collections.Generic;

public class CharacterStats : ICloneable
{
    public List<Stats> Stats = new();

    public object Clone()
    {
        CharacterStats clone = new();

        foreach (Stats stat in Stats)
        {
            clone.Stats.Add(new Stats()
            {
                Type = stat.Type,
                Value = stat.Value
            });
        }

        return clone;
    }


    public int GetValue(StatType type)
    {
        return Stats.Find(s => s.Type == type).Value;
    }

    public void AddValue(StatType type, int value)
    {
        Stats stat = Stats.Find(s => s.Type == type);

        if (stat != null)
            stat.Value += value;
    }
}