using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Over_Controller : MonoBehaviour
{
    public Text score;

    private void Start() {
        score.text = Score_Controller.score.ToString();
    }

    public void Again() {
        SceneManager.LoadScene("Game");
    }

    public void Menu() {
        SceneManager.LoadScene("Main Menu");
    }
}
