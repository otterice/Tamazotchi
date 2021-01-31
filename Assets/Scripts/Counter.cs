using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text steps;
    int stepCount = 0;
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
       
        stepCount += 1;
        steps.text = "Steps: " + stepCount;
        Debug.Log(stepCount);
    }


}
