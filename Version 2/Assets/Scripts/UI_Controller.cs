using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public int lives;

    public Image[] lifeUI;
    public Text scoreUI;
    public Pickup_Controller pickup_Controller;

    // Start is called before the first frame update
    void Start() {
        Score_Controller.score = 0;
        ShowScore();
        ShowLives();
    }

    public void AddScore(int amount) {
        Score_Controller.score += amount;
        ShowScore();
        pickup_Controller.spawnPickup();
    }

    public void LoseLife() {
        if (--lives <= 0) {
            GameOver();
        }
        ShowLives();
    }

    private void ShowScore() {
        scoreUI.text = Score_Controller.score.ToString();
    }

    private void ShowLives() {
        lifeUI[0].enabled = true;
        lifeUI[1].enabled = true;
        lifeUI[2].enabled = true;

        if (lives < 3) {
            lifeUI[2].enabled = false;
        }
        if (lives < 2) {
            lifeUI[1].enabled = false;
        }
    }

    private void GameOver() {
        SceneManager.LoadScene("Game Over");
    }
}
