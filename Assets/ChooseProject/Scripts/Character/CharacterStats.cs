using System;

public class CharacterStats : ICloneable
{
    public int Health;
    public int Attack;
    public int Defense;
    public int Speed;

    public object Clone()
    {
        return new CharacterStats
        {
            Health = Health,
            Attack = Attack,
            Defense = Defense,
            Speed = Speed
        };
    }
}
