using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    [SerializeField]
    private int lives;
    [SerializeField]
    private int score;

    public GameObject[] lifeUI;
    public GameObject scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        ShowScore();
        ShowLives();
    }

    public void AddScore(int amount) {
        score += amount;
    }

    public void loseLive() {
        lives--;
        if (lives <= 0) {
            SceneManager.LoadScene("Game Over");
        }
        ShowLives();
    }

    private void ShowScore() {
        scoreUI.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
    }

    private void ShowLives() {
        switch (lives) {
            case 3:
                lifeUI[0].active = true;
                break;
            case 2:
                lifeUI[0].active = true;
                lifeUI[1].active = true;
                break;
            case 1:
                lifeUI[0].active = true;
                lifeUI[1].active = true;
                lifeUI[2].active = true;
                break;
        }
    }

    private void GameOver() {
        SceneManager.LoadScene("Game Over");
    }
}
