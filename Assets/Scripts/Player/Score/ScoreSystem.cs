using System;

public class ScoreSystem
{
    private int _value;

    public event Action ValueChanged;
    
    public void Add(int count)
    {
        _value += count;
        ValueChanged?.Invoke();
    }

    public void GetValue(out int value)
    {
        value = _value;
    }

    public void ResetValue()
    {
        _value = 0;
        ValueChanged?.Invoke();
    }
}
