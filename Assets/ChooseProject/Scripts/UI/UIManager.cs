using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text statsHealth;
    [SerializeField]
    private Text statsAttack;
    [SerializeField]
    private Text statsDefense;
    [SerializeField]
    private Text statsSpeed;

    [SerializeField]
    private Text modifiersText;

    [SerializeField]
    private CharacterManager characterManager;

    private void Start()
    {
        characterManager.OnStatsChanged += UpdateUI;

        UpdateUI();
    }

    public void UpdateUI()
    {

        UpdateStats();
        UpdateModifiers();



    }

    private void UpdateStats()
    {
        CharacterStats stats = characterManager.FinalStats;
        statsHealth.text = stats.GetValue(StatType.Health).ToString();
        statsAttack.text = stats.GetValue(StatType.Attack).ToString();
        statsDefense.text = stats.GetValue(StatType.Defense).ToString();
        statsSpeed.text = stats.GetValue(StatType.Speed).ToString();
    }

    private void UpdateModifiers()
    {
        if (characterManager.Modifiers.Count == 0)
        {
            modifiersText.text = "No modifiers";
            return;
        }

        System.Text.StringBuilder builder = new();

        foreach (StatModifier modifier in characterManager.Modifiers)
        {
            builder.AppendLine(modifier.ToString());
        }

        modifiersText.text = builder.ToString();
    }

    private void OnDestroy()
    {
        characterManager.OnStatsChanged -= UpdateUI;
    }
}