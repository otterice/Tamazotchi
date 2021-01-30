using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour {
    public static Sprite equippedSkin;

    public SkinInfo[] allSkins;

    private void Awake() {
        string lastSkinUsed = PlayerPrefs.GetString("skinPref", SkinInfo.SkinIDs.default_petr.ToString());
        foreach (SkinInfo s in allSkins) {
            if (s.skinID.ToString() == lastSkinUsed) {
                EquipSkin(s);
            }
        }
    }

    public void EquipSkin(SkinInfo skinInfo) {
        equippedSkin = skinInfo.skinSprite;
        PlayerPrefs.SetString("skinPref", skinInfo.skinID.ToString());
    }
}
