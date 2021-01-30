using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;

    public float money = 100f;

    private void Start() {
        money = PlayerPrefs.GetFloat("moneyPref");
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + money;
    }

    public void UpdateMoney(float multipler) {
        money += 10 + (2 * multipler);
        PlayerPrefs.SetFloat("moneyPref", money);
    }

    public float GetMoney() {
        return money;
    }

    public bool TryRemoveMoney(int moneyToRemove) {
        if (money >= moneyToRemove) {
            money -= moneyToRemove;
            PlayerPrefs.SetFloat("moneyPref", money);
            return true;
        }
        else {
            return false;
        }
    }
}
