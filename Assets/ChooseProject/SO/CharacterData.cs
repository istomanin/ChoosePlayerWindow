using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{

 [SerializeField]
    private string className;

    [SerializeField]
    private List<Stats> baseStats = new();

    public string ClassName => className;

    public IReadOnlyList<Stats> BaseStats => baseStats;
}
