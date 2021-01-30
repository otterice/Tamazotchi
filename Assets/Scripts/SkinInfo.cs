using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName ="New Skin", menuName ="Create New Skin")]
public class SkinInfo : ScriptableObject
{
    public enum SkinIDs { default_petr, anime_petr1, anime_petr2, anime_petr3 }
    public SkinIDs skinID;

    public Sprite skinSprite;

    public int skinPrice;
}
