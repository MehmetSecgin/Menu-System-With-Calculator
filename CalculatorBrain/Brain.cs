using System;
using System.Globalization;

namespace CalculatorBrain;

public class Brain
{
    public double CurrentValue { get; private set; }

    public double Add(double value) 
    {
        CurrentValue += value;
        return CurrentValue;
    }  
    public double Subtract(double value) 
    {
        CurrentValue -= value;
        return CurrentValue;
    }

    public double Divide(double value)
    {
        if (value == 0) return CurrentValue;
        CurrentValue /= value;
        return CurrentValue;

    }

    public void Clear() => CurrentValue = 0;
    public void SetValue(double value) => CurrentValue = value;
        

    public double ApplyCustomFunction(Func<double, double, double> func, double value)
    {
        CurrentValue = func(CurrentValue, value);
        return CurrentValue;
    }

    public override string ToString() => CurrentValue.ToString(CultureInfo.CurrentCulture);
}