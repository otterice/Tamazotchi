using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {
    public HealthBar healthBar;

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        healthBar.GetComponent<HealthBar>();
        healthBar.deletePlayerPrefs();
        healthBar.createPlayerPrefs();
    }
}