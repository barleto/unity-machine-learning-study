using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ActivatorFunction
{
     double Calculate(double input);
    double Derivative(double input);
}

public class PassThroughFunction : ActivatorFunction
{
    public double Calculate(double input)
    {
        return input;
    }

    public double Derivative(double input)
    {
        return 1;
    }
}

public class StepFunction : ActivatorFunction
{
    public double Calculate(double input)
    {
        return input < 0 ? 0 : 1;
    }

    public double Derivative(double input)
    {
        return 0;
    }
}

public class BalancedSigmoid : ActivatorFunction
{
    public virtual double Calculate(double input)
    {
        double k = (double)System.Math.Exp(input);
        return (k / (1 + k)) - 0.5f;
    }

    public virtual double Derivative(double input)
    {
        return Calculate(input) * (1 - Calculate(input));
    }
}

public class Tanh : BalancedSigmoid
{
    public override double Calculate(double input)
    {
        return System.Math.Tanh(input);
    }

    public override double Derivative(double input)
    {
        return 1 - Math.Pow(Calculate(input), 2);
    }
}