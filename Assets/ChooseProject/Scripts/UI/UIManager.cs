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
    private CharacterManager characterManager;

    private void Start()
    {
        characterManager.OnStatsChanged += UpdateStats;

        UpdateStats();
    }

    public void UpdateStats()
    {
        CharacterStats stats = characterManager.FinalStats;

        statsHealth.text = stats.GetValue(StatType.Health).ToString();
        statsAttack.text = stats.GetValue(StatType.Attack).ToString();
        statsDefense.text = stats.GetValue(StatType.Defense).ToString();
        statsSpeed.text = stats.GetValue(StatType.Speed).ToString();
    }

    private void OnDestroy()
    {
        characterManager.OnStatsChanged -= UpdateStats;
    }
}