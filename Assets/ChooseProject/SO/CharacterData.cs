using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{

    [SerializeField] private string className;

    [SerializeField] private int health;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int speed;

    public string ClassName => className;

    public int Health => health;
    public int Attack => attack;
    public int Defense => defense;
    public int Speed => speed;
}
