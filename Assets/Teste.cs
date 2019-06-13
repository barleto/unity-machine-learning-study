using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    private Neuron p;
    private double[,] trainSet = { { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 }, { 0, 0, 0 } };
    public int epochs = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

}
