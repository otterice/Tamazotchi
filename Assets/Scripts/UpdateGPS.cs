using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateGPS : MonoBehaviour
{

    public Text coordinates;
    public GPS gps;

    private void Start() {
        gps = FindObjectOfType<GPS>();
    }

    // Update is called once per frame
    void Update()
    {
        //coordinates.text = "Lat: " + GPS.Instance.latitude.ToString() + "  Lon: " + GPS.Instance.longitude.ToString();
    }
}
