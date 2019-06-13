using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Layer
{
    List<Neuron> _neurons = new List<Neuron>();

    public Layer(int numberOfInputs,int numberOfPerceptrons, ActivatorFunction function, double learningRate)
    {
        for(int i = 0; i < numberOfPerceptrons; i++)
        {
            _neurons.Add(new Neuron(function, numberOfInputs, learningRate));
        }
    }

    internal List<Double> Calculate(List<double> inputs)
    {
        var layerOutput = new List<double>();
        foreach (var perceptron in _neurons)
        {
            layerOutput.Add(perceptron.Calculate(inputs));
        }

        return layerOutput;
    }

    public List<Double> GetOutputs()
    {
        var outputs = new List<double>();
        foreach (var perceptron in _neurons)
        {
            outputs.Add(perceptron.Output);
        }
        return outputs;
    }

    public List<Neuron> GetNeurons()
    {
        return new List<Neuron>(_neurons);
    }

    public void UpdateLayerWeigths(List<double> errorDerivative, List<Neuron> nextLayer)
    {
        //errorDerivative is the drivative of the error function E = 0.5*(desiredOutput - realOutput)^2 over the real output;

        for (int n = 0; n < _neurons.Count; n++)
        {
            var neuron = _neurons[n];

            //calculate error gradient
            if (nextLayer == null)
            {
                //outputLayer
                neuron.errorGradient = errorDerivative[n] * neuron.activatorFunction.Derivative(neuron.Output);
            }
            else
            {
                //other layers
                double weightedErrorGradient = 0;
                foreach (var nextLayerNeuron in nextLayer)
                {
                    weightedErrorGradient += nextLayerNeuron.errorGradient * nextLayerNeuron.weights[n];
                }
                neuron.errorGradient = weightedErrorGradient * neuron.activatorFunction.Derivative(neuron.Output);
            }


            //update neurons weigths:  
            neuron.AdjustWeigths();
        }
    }
}
