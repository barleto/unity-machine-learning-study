using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron
{
    ActivatorFunction _activatorFunction;
    double _bias;
    int _inputNumber;
    List<double> _weights = new List<double>();
    List<double> _inputs = new List<double>();
    double _output;
    double _alpha;

    public double Output {get{return _output;}}

    public Perceptron(ActivatorFunction activatorFunction, int inputNumbers, double learningRate)
    {
        _activatorFunction = activatorFunction;
        _alpha = learningRate;
        _inputNumber = inputNumbers;
        InitializePerceptron();
    }

    private void InitializePerceptron()
    {
        _bias = UnityEngine.Random.Range(-1f, 1f);
        for (int i = 0; i < _inputNumber; i++)
        {
            _weights.Add(UnityEngine.Random.Range(-1f,1f));
        }
    }

    public double Train(List<double> inputs, double desiredOutput)
    {
        CalcOutput(inputs);
        AdjustWeights(inputs, desiredOutput);
        return _output;
    }

    private double DotProductBias(List<double> inputs)
    {
        double res = 0;
        for (int i = 0; i < inputs.Count; i++)
        {
            res += _weights[i] * inputs[i];
        }
        res += _bias;
        return res;
    }

    public double CalcOutput(List<double> inputs)
    {
        _output = _activatorFunction.Calculate(DotProductBias(inputs));
        return _output;
    }

    void AdjustWeights(List<double> inputs, double desiredOutput)
    {
        var error =  desiredOutput - _output;
        for (int i = 0; i < _weights.Count; i++)
        {
            _weights[i] =inputs[i] * error + _weights[i];
        }
        _bias += error;
    }
    
}
