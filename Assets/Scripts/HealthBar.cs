using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Money money;
    public GameObject GameManager;

    public GameObject panel;

    public Image currentHunger;
    public Image currentHealth;
    public Image currentLevel;

    public Text hungerText;
    public Text healthText;
    public Text levelPercent;
    public Text levelText;

    public float hunger = 100f;
    public float health = 100f;
    //percent level
    public float level = 0f;
    public float characterLevel = 1f;
    public int priceOfFood = 5;

    private float max = 100f;

    public Button Feed;

    public Text GameOverText;

    private void Start() {
        //Button Listener for Hunger
        Button btn1 = Feed.GetComponent<Button>();
        btn1.onClick.AddListener(FeedThePet);
        GameObject GameManager = this.GameManager;
        money = GameManager.GetComponent<Money>();
        createPlayerPrefs();

        levelText.text = "Level " + characterLevel;

        UpdateHungerBar();
    }

    public void deletePlayerPrefs() {
        Debug.Log("clicked delete");
        PlayerPrefs.DeleteAll();
    }

    public void createPlayerPrefs() {
        hunger = PlayerPrefs.GetFloat("hungerPref", 100f);
        health = PlayerPrefs.GetFloat("healthPref", 100f);
        characterLevel = PlayerPrefs.GetFloat("levelPref", 1f);
        level = PlayerPrefs.GetFloat("levelPercentPref", 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        hunger -= 0.2f * Time.deltaTime;
        if (hunger < 0) {
            hunger = 0;
            health -= 0.2f * Time.deltaTime;
        }

        if (health < 0) {
            health = 0;
            panel.gameObject.SetActive(true);
        }

        UpdateHungerBar();
        UpdateLevelBar();
        UpdatHealthBar();
    }

    private void UpdateHungerBar() {
        float ratio = hunger / max;
        currentHunger.rectTransform.localScale = new Vector3(ratio, 1, 1);
        hungerText.text = (ratio * 100).ToString("0") + '%';
        PlayerPrefs.SetFloat("hungerPref", hunger);
    }

    private void UpdatHealthBar() {
        float ratio = health / max;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        healthText.text = (ratio * 100).ToString("0") + '%';
        PlayerPrefs.SetFloat("healthPref", health);
    }

    private void UpdateLevelBar() {
        float ratio = level / max;
        if (level >= 100) {
            money.UpdateMoney(characterLevel);
            characterLevel++;
            PlayerPrefs.SetFloat("levelPref", characterLevel);
            level = 0;
            levelText.text = "Level " + characterLevel;
        }
        PlayerPrefs.SetFloat("levelPercentPref", level);
        currentLevel.rectTransform.localScale = new Vector3(ratio, 1, 1);
        levelPercent.text = (ratio * 100).ToString("0") + '%';
    }

    public void walkToIncreaseLevel() {
        level += characterLevel * 0.005f  + 0.10f;
    }

    void FeedThePet() {
        Debug.Log("Feed has been clicked");
        if (money.TryRemoveMoney(priceOfFood)) {
            hunger += 10;
            level += 10f;
        }
        
        if (hunger > max) {
            hunger = max;
        }
    }
}
