using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;

    public float money = 100f;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + money;
    }

    public void UpdateMoney(float multipler) {
        money += 10 + (2 * multipler);
    }

    public float GetMoney() {
        return money;
    }

    public bool TryRemoveMoney(int moneyToRemove) {
        if (money >= moneyToRemove) {
            money -= moneyToRemove;
            return true;
        }
        else {
            return false;
        }
    }
}
