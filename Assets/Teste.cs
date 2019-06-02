using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    private Perceptron p;
    private double[,] trainSet = { { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 }, { 0, 0, 0 } };
    public int epochs = 10;


    // Start is called before the first frame update
    void Start()
    {
        p = new Perceptron(new StepFunction(), 2,1);
        var i = new List<double>();
        for (int e = 0; e < epochs; e++)
        {
            i.Clear();
            i.Add(trainSet[0, 0]);
            i.Add(trainSet[0, 1]);
            p.Train(i,trainSet[0,2]);
            i.Clear();
            i.Add(trainSet[1, 0]);
            i.Add(trainSet[1, 1]);
            p.Train(i, trainSet[1, 2]);
            i.Clear();
            i.Add(trainSet[2, 0]);
            i.Add(trainSet[2, 1]);
            p.Train(i, trainSet[2, 2]);
            i.Clear();
            i.Add(trainSet[3, 0]);
            i.Add(trainSet[3, 1]);
            p.Train(i, trainSet[3, 2]);
        }
        
        i.Clear();
        i.Add(trainSet[0, 0]);
        i.Add(trainSet[0, 1]);
        p.CalcOutput(i);
        Debug.Log(p.Output);
        i.Clear();
        i.Add(trainSet[1, 0]);
        i.Add(trainSet[1, 1]);
        p.CalcOutput(i);
        Debug.Log(p.Output);
        i.Clear();
        i.Add(trainSet[2, 0]);
        i.Add(trainSet[2, 1]);
        p.CalcOutput(i);
        Debug.Log(p.Output);
        i.Clear();
        i.Add(trainSet[3, 0]);
        i.Add(trainSet[3, 1]);
        p.CalcOutput(i);
        Debug.Log(p.Output);
    }

}
