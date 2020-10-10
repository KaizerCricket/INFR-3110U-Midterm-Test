using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for Stat/End screen button to go back to main menu
public class EndScreen : MonoBehaviour {
    public void ToMainMenu() {
        SceneManager.LoadScene(0);
    }

}
