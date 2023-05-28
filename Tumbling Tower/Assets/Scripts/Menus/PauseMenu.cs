using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenuUI;
    public AudioSource onClick;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses "Esc", the game pauses/resumes
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    // Pauses game
    public void PauseGame()
    {
        System.Console.WriteLine("Pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Resumes game
    public void ResumeGame()
    {
        System.Console.WriteLine("Resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        onClick.Play();
    }

    // Quits to main menu
    public void QuitToMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
}
