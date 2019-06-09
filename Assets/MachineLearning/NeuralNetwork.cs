using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NeuralNetwork
{
    int _numberOfInputs;
    int _numberOfOutputs;
    List<Layer> _layers = new List<Layer>();
    double _learningRate;

    public NeuralNetwork(int numberOfInputs, int numberOfOutputs, int numberOfLayers, ActivatorFunction[] activatorsList, int[] numberOfPerceptronsInEachLayer, double learningRate = 0.01)
    {
        _numberOfInputs = numberOfInputs;
        _numberOfOutputs = numberOfOutputs;
        _learningRate = learningRate;
        if (activatorsList.Length != numberOfLayers)
        {
            throw new Exception("Activators list must have same length as numberOfHiddenLayers");
        }

        if (numberOfLayers <= 0)
        {
            throw new Exception("Number o layers must be > 0");
        }

        int lastLayerOutputSize = numberOfInputs;
        for(int i = 0; i < numberOfLayers; i++)
        {
            _layers.Add(new Layer(lastLayerOutputSize, numberOfPerceptronsInEachLayer[i], activatorsList[i], learningRate));
            lastLayerOutputSize = numberOfPerceptronsInEachLayer[i];
        }
    }
}
