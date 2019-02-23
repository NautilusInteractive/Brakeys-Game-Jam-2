using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splashscreen_Controller : MonoBehaviour
{
    public float showTime;

    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown || showTime <= 0.0f) {
            NextScene();
        }

        showTime -= Time.deltaTime;
    }

    void NextScene() {
        SceneManager.LoadScene("Main Menu");
    }
}
