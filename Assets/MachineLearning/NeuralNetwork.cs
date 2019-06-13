using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class NeuralNetwork
{
    int _numberOfInputs;
    int _numberOfOutputs;
    List<Layer> _layers = new List<Layer>();
    double _learningRate;

    public NeuralNetwork(int numberOfInputs, int numberOfLayers, ActivatorFunction[] activatorsList, int[] numberOfPerceptronsInEachLayer, double learningRate = 0.01)
    {
        _numberOfInputs = numberOfInputs;
        _numberOfOutputs = numberOfPerceptronsInEachLayer[numberOfPerceptronsInEachLayer.Length - 1];
        _learningRate = learningRate;
        if (activatorsList.Length != numberOfLayers)
        {
            throw new Exception("Activators list must have same length as numberOfHiddenLayers");
        }

        if (numberOfLayers <= 0)
        {
            throw new Exception("Number o layers must be >= 1. ");
        }

        //create user hidden layers
        int lastLayerOutputSize = numberOfInputs;
        for(int i = 0; i < numberOfLayers; i++)
        {
            _layers.Add(new Layer(lastLayerOutputSize, numberOfPerceptronsInEachLayer[i], activatorsList[i], learningRate));
            if (numberOfPerceptronsInEachLayer[i] < 1)
            {
                throw new Exception("All layers must have, at least 1 neuron.");
            }
            lastLayerOutputSize = numberOfPerceptronsInEachLayer[i];
        }
    }

    public List<double> Calculate(List<double> inputs)
    {
        if (inputs.Count != _numberOfInputs)
        {
            throw new Exception("parameters length mismatch");
        }

        var currentLayerInput = new List<double>(inputs);

        foreach (var layer in _layers)
        {
            currentLayerInput = layer.Calculate(currentLayerInput);
        }

        return currentLayerInput;
    }

    public List<double> Train(List<double> inputs, List<double> desiresOutputs)
    {
        if (inputs.Count != _numberOfInputs || desiresOutputs.Count != _numberOfOutputs)
        {
            throw new Exception("parameters length mismatch");
        }

        var realOuputs = this.Calculate(inputs);

        BackPropagate(realOuputs, desiresOutputs);

        return realOuputs;
    }
    //SSM = (1/2)(t-y)^2

    private void BackPropagate(List<double> realOuputs, List<double> desiredOutputs)
    {
        ///more on back propagation here:
        ///https://en.wikipedia.org/wiki/Backpropagation
        ///
        var errorDerivatives = realOuputs.Select((x, i) => x - desiredOutputs[i]).ToList();
        for (int l = _layers.Count -1; l >= 0; l--)
        {
            var layer = _layers[l];
            if (IsOutputLayer(layer))
            {
                layer.UpdateLayerWeigths(errorDerivatives, null);
            }
            else
            {
                layer.UpdateLayerWeigths(errorDerivatives, _layers[l+1].GetNeurons());
            }
        }
    }

    bool IsOutputLayer(Layer l)
    {
        return _layers.IndexOf(l) == _layers.Count - 1;
    }
}
