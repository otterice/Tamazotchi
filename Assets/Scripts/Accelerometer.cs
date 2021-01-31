using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Accelerometer : MonoBehaviour
{
    #region Instance
    private static Accelerometer instance;
    public static Accelerometer Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Accelerometer>();
                if(instance == null)
                {
                    instance = new GameObject("Created Accelerometer", typeof(Accelerometer)).GetComponent<Accelerometer>();
                }
            }
            return instance;

        }
        set
        {
            instance = value;
        }

    }
    #endregion

    [Header("Shake Detection")]
    public Action OnShake;
    [SerializeField] private float shakeDetectionThreshold = 2.0f;
    private float accelerometerUpdateInterval = 1.0f / 100.0f;
    private float lowPassKernelWidthInSeconds = 1.0f;
    private float lowPassFilterFactor;
    private Vector3 lowpassValue;

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowpassValue = Input.acceleration;

    }

    public void Update()
    {
        Vector3 acceleration = Input.acceleration;
        lowpassValue = Vector3.Lerp(lowpassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowpassValue;

        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            OnShake?.Invoke();
        }
    }

   

}
