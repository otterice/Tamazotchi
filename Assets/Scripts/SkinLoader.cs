using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinLoader : MonoBehaviour
{
    public Image playerSR;

    private void Awake() {
        playerSR.sprite = SkinManager.equippedSkin;
    }
}
