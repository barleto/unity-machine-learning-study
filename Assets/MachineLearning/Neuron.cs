using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron
{
    public ActivatorFunction activatorFunction;
    public double bias;
    int _inputNumber;
    public List<double> weights = new List<double>();
    public List<double> inputs = new List<double>();
    double _output;
    double _lastWeightedSum;
    public double learningRate;
    public double errorGradient;

    public double Output {get{return _output;}}

    public Neuron(ActivatorFunction activatorFunction, int inputNumbers, double learningRate)
    {
        this.activatorFunction = activatorFunction;
        this.learningRate = learningRate;
        _inputNumber = inputNumbers;
        InitializePerceptron();
    }

    private void InitializePerceptron()
    {
        bias = UnityEngine.Random.Range(-1f, 1f);
        for (int i = 0; i < _inputNumber; i++)
        {
            weights.Add(UnityEngine.Random.Range(-1f,1f));
        }
    }

    private double DotProductBias(List<double> inputs)
    {
        double res = 0;
        for (int i = 0; i < inputs.Count; i++)
        {
            res += weights[i] * inputs[i];
        }
        res += bias;
        return res;
    }

    public double Calculate(List<double> inputs)
    {
        _lastWeightedSum = DotProductBias(inputs);
        _output = activatorFunction.Calculate(_lastWeightedSum);
        return _output;
    }

    public void AdjustWeigths()
    {
        for (int w = 0; w < weights.Count; w++)
        {
            weights[w] += -1 * learningRate * inputs[w] * errorGradient;
        }
    }

}
