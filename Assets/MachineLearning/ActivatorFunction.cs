using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatorFunction
{
    abstract public double Calculate(double input);
}

public class StepFunction : ActivatorFunction
{
    public override double Calculate(double input)
    {
        return input < 0 ? 0 : 1;
    }
}

public class BalancedSigmoid : ActivatorFunction
{
    public override double Calculate(double input)
    {
        double k = (double)System.Math.Exp(input);
        return (k / (1 + k)) - 0.5f;
    }
}

public class Tanh : BalancedSigmoid
{
    public override double Calculate(double input)
    {
        return 2 * base.Calculate(2 * input) - 1;
    }
}