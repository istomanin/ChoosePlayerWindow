using System;

public class StatModifier
{
    public StatType StatType;

    public int Value;

    public override string ToString()
    {
        return $"+{Value} {StatType}";
    }

}
