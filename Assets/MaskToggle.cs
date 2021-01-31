using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskToggle : MonoBehaviour
{
    //public Button MaskBtn;
    public GameObject MaskActive;
    // Start is called before the first frame update
    void Start()
    {
        //Button btn1 = MaskBtn.GetComponent<Button>();
        //btn1.onClick.AddListener(maskToggle);
    }

    public void maskToggle() {
        Debug.Log("check");
        if (MaskActive.gameObject.activeSelf) {
            MaskActive.SetActive(false);
        }
        else {
            MaskActive.SetActive(true);
        }
    }
}
