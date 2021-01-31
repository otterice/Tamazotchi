using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public GameObject longText;
    public GameObject latText;

    public Text longitudeText;
    public Text latitudeText;

    IEnumerator coroutine;

    IEnumerator Start() {
        coroutine = updateGPS();

        Text longitudeText = longText.GetComponent<Text>();
        Text latitudeText = latText.GetComponent<Text>();

        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1) {
            print("Timed out");
            yield break;
        }


        if (Input.location.status == LocationServiceStatus.Failed) {
            print("Unable to determine device location");
            yield break;
        }
        else {
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            longitudeText.text = "Longitude: " + Input.location.lastData.longitude;
            latitudeText.text = "Latitude: " + Input.location.lastData.latitude;
            StartCoroutine(coroutine);
        }
    }

    IEnumerator updateGPS() {
        float UPDATE_TIME = 3f; //Every  3 seconds
        WaitForSeconds updateTime = new WaitForSeconds(UPDATE_TIME);

        

        while (true) {            
            var sr = File.CreateText("LATLON.txt");
            sr.WriteLine(Input.location.lastData.latitude + "," + Input.location.lastData.longitude);
            sr.Close();

            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            longitudeText.text = "Longitude: " + Input.location.lastData.longitude;
            latitudeText.text = "Latitude: " + Input.location.lastData.latitude;


            yield return updateTime;
        }
    }

    void stopGPS() {
        Input.location.Stop();
        StopCoroutine(coroutine);
    }

    void OnDisable() {
        stopGPS();
    }
}
