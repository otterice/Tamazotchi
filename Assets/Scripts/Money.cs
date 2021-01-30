using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    public Text moneyText;
    public Text levelUpMoneyText;

    [SerializeField] float money = 100f;
    public float levelUpMoney = 0f;
    public float amtOfLevelUpMoney = 0f;

    private void Start() {
        money = PlayerPrefs.GetFloat("moneyPref");
        money = 100f;
        levelUpMoneyText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + money;
    }

    public void UpdateMoney(float multipler) {
        amtOfLevelUpMoney = 10 + (5 * multipler);
        money += amtOfLevelUpMoney;
        StartCoroutine(MoneyUpdater());
        levelUpMoney = 0;
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

    private IEnumerator MoneyUpdater() {
        while (true) {
            if (levelUpMoney < amtOfLevelUpMoney) {
                levelUpMoney++;
                levelUpMoneyText.text = "$" + levelUpMoney;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
