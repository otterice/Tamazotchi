using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text steps;
    double stepCount = 0;
    private void Start()
    {
        Accelerometer.Instance.OnShake += WhenShake;
        
    }

    private void OnDestroy()
    {
        Accelerometer.Instance.OnShake -= WhenShake;
    }

    private void WhenShake()
    {
       
        stepCount += 0.052;
        int roundCount = Convert.ToInt32(stepCount);
        steps.text = "Steps: " + roundCount;
        Debug.Log(stepCount);
    }


}
