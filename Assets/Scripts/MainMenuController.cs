using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame() {
        SceneManager.LoadScene("Demo");
    }
 
    public void exitGame() {
        Application.Quit();
    }

    public void returnToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
