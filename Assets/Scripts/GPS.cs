using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }
    public float latitude;
    public float longitude;


    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());      
    }

    private IEnumerator StartLocationService()
    {
#if UNITY_EDITOR
        //Wait until Unity connects to the Unity Remote, while not connected, yield return null
        while (!UnityEditor.EditorApplication.isRemoteConnected) {
            yield return null;
        }
#endif
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        Input.location.Start();
        //Timeout 
        int maxWait = 20;


        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        yield break;
    }
}
