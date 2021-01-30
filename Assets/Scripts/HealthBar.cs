using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Money money;
    public GameObject GameManager;

    public Image currentHunger;
    public Image currentLevel;

    public Text hungerText;
    public Text levelPercent;
    public Text levelText;

    private float hunger = 100f;
    //percent level
    private float level = 0f;
    private float characterLevel = 1f;
    private float max = 100f;

    public Button Feed;

    public Text GameOverText;

    private void Start()
    {
        //Button Listener for Hunger
        Button btn1 = Feed.GetComponent<Button>();
        btn1.onClick.AddListener(FeedThePet);
        GameObject GameManager = this.GameManager;
        money = GameManager.GetComponent<Money>();

        hunger = PlayerPrefs.GetFloat("hungerPref", 100f);
        characterLevel = PlayerPrefs.GetFloat("levelPref", 1f);
        level = PlayerPrefs.GetFloat("levelPercentPref", 0f);

        levelText.text = "Level " + characterLevel;

        UpdateHungerBar();
    }

    // Update is called once per frame
    private void Update()
    {
        hunger -= 0.2f * Time.deltaTime;
        if (hunger < 0) {
            hunger = 0;
        }

        UpdateHungerBar();
        UpdateLevelBar();
    }

    private void UpdateHungerBar() {
        float ratio = hunger / max;
        currentHunger.rectTransform.localScale = new Vector3(ratio, 1, 1);
        hungerText.text = (ratio * 100).ToString("0") + '%';
        PlayerPrefs.SetFloat("hungerPref", hunger);
    }

    private void UpdateLevelBar() {
        float ratio = level / max;
        if (level == 100) {
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

    void FeedThePet() {
        Debug.Log("Feed has been clicked");
        hunger += 10;
        level += 10f;
        if (hunger > max) {
            hunger = max;
        }
    }
}
