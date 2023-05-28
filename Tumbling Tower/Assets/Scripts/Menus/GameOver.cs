using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public class GameOver : MonoBehaviour
{
    // name input
    public TMP_InputField Input;
    public UnityEngine.UI.Button Confirmation;

    // leaderboard object
    public GameObject Leaderboard;

    // leaderboard children panels/textboxes
    public GameObject Scoreboard_panel;
    public TextMeshProUGUI Rank;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Name;

    // score display
    public TextMeshProUGUI ScoreCounter;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Scoreboard_count"))
            ScoreListOptions.ResetScoreboard();

        if (PlayerPrefs.GetString("PreviousLevel") != "Endless")
        {
            Leaderboard.SetActive(false);
            Input.enabled = false;
            Confirmation.enabled = false;
        }
        else
        {
            Leaderboard.SetActive(true);
            Scoreboard_panel.SetActive(false);
            Input.enabled = true;
            Confirmation.enabled = true;
        }

        //score display
        ScoreCounter.text += PlayerPrefs.GetInt("CurrentScore", 0);
    }

    // Starts game by moving to last selected level
    public void RestartGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousLevel"));
    }

    // Exits to desktop
    public void QuitGame()
    {
        MainMenu.QuitGame();
    }

    public void QuitToMainMenu()
    {
        MainMenu.QuitToMainMenu();
    }

    public void ConfirmInput()
    {
        if (Input.text == "")
            return;

        // ui adjustment
        Scoreboard_panel.SetActive(true);
        DisplayLeaderboard();
        Input.gameObject.SetActive(false);
        Confirmation.gameObject.SetActive(false);
    }

    public void DisplayLeaderboard()
    {
        Rank.text = "";
        Score.text = "";
        Name.text = "";

        // gets scoreboard
        List<Scores> List = ScoreListOptions.GetScoreboard();
        // adds current score
        ScoreListOptions.AddSccore(List, Input.text, PlayerPrefs.GetInt("CurrentScore"));
        // updates scoreboard
        ScoreListOptions.SaveScoreboard(List);

        // sorts list in descending order
        List.Sort((first, second) =>
        {
            if (first.score > second.score)
                return -1;
            else
                return 1;
        });

        // displays list
        for (int i = 0; i <= 5; i++)
        {
            if (i >= List.Count)
                break;

            Rank.text += (i + 1).ToString() + "\n";
            Score.text += List[i].score + "\n";
            Name.text += List[i].name.ToString() + "\n";
        }
    }
}
