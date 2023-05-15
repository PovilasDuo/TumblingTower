using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameModeSelection");
    }


    public static void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Exits to desktop
    public static void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void StartEndless()
    {
        SceneManager.LoadScene("Endless");
    }

    public void StartChallenge()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void OpenStats()
    {
        SceneManager.LoadScene("LifetimeStatsMenu");
    }
}
