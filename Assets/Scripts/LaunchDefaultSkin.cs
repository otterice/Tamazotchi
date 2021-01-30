using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchDefaultSkin : MonoBehaviour
{
    public Sprite defaultSkin;
    public Image image;
    public static Sprite equippedSkin;

    public void Start() {
        image.sprite = defaultSkin;
    }
}
