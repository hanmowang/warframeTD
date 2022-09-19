using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;


    public void Retry() {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        Debug.Log("Go to menu");
        sceneFader.FadeTo(menuSceneName);
    }
}
