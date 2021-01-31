using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text steps;

    public HealthBar hb;
    double stepCount = 0;

   
    private void Awake() {
        Accelerometer.Instance.OnShake += WhenShake;
        stepCount = PlayerPrefs.GetInt("stepCountPref", 0);

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
        PlayerPrefs.SetInt("stepCountPref", roundCount);
        hb.walkToIncreaseLevel();


    }


}
