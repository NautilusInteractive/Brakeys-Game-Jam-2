﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public void Game() {
        SceneManager.LoadScene("Game");
    }

    public void Credits() {
        Debug.Log("Credits");
    }

    public void Quit() {
        Application.Quit();
    }
}
