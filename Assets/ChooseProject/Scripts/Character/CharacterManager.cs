using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    public event Action OnStatsChanged;

    public CharacterStats FinalStats => finalStats;
    private readonly List<StatModifier> modifiers = new();
    [SerializeField] private CharacterData currentCharacterData;

    private CharacterStats baseStats;

    private CharacterStats finalStats;


    private void Awake()
    {

        baseStats = CreateStats(currentCharacterData);
        //Debug.Log($"Current Character: {currentCharacterData.ClassName}");
        RecalculateStats();
        //Debug.Log($"Base Stats: Health: {baseStats.Health}, Attack: {baseStats.Attack}, Defense: {baseStats.Defense}, Speed: {baseStats.Speed}");
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

    private CharacterStats CreateStats(CharacterData data)
    {
        return new CharacterStats()
        {
            Health = data.Health,
            Attack = data.Attack,
            Defense = data.Defense,
            Speed = data.Speed
        };
    }

    private void RecalculateStats()
    {
        finalStats = (CharacterStats)baseStats.Clone();

        foreach (StatModifier modifier in modifiers)
        {
            switch (modifier.StatType)
            {
                case StatType.Health:
                    finalStats.Health += modifier.Value;
                    break;

                case StatType.Attack:
                    finalStats.Attack += modifier.Value;
                    break;

                case StatType.Defense:
                    finalStats.Defense += modifier.Value;
                    break;

                case StatType.Speed:
                    finalStats.Speed += modifier.Value;
                    break;
            }
        }
        OnStatsChanged?.Invoke();
    }
}