using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for Main Menu buttons
public class MainMenu : MonoBehaviour
{
    // Functions to Load other scenes or quit application
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
    public void StatsScreen() {
        SceneManager.LoadScene(2);
    }
    public void ExitGame() {
        Application.Quit();
    }

}
