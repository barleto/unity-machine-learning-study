using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
    List<Perceptron> _perceptrons = new List<Perceptron>();

    public Layer(int numberOfInputs,int numberOfPerceptrons, ActivatorFunction function, double learningRate)
    {
        for(int i = 0; i < numberOfPerceptrons; i++)
        {
            _perceptrons.Add(new Perceptron(function, numberOfInputs, learningRate));
        }
    }
}
