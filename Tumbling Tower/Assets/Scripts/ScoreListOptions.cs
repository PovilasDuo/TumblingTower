using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreListOptions : MonoBehaviour
{
    // max size of list
    public const int MAX_SIZE = 100;

    /// <summary>
    /// Resets any saved scores in PlayerPrefs
    /// </summary>
    public static void ResetScoreboard()
    {
        PlayerPrefs.SetInt("Scoreboard_count", 0);
        for (int i = 0; i < MAX_SIZE; i++)
        {
            PlayerPrefs.SetString("Scoreboard_s" + i, "");
            PlayerPrefs.SetInt("Scoreboard_i" + i, 0);
        }
    }

    /// <summary>
    /// Returns list of saved scores from PlayerPrefs
    /// </summary>
    /// <returns>saved score list</returns>
    public static List<Scores> GetScoreboard()
    {
        int count = PlayerPrefs.GetInt("Scoreboard_count", 0);
        List<Scores> Scoreboard = new List<Scores>(count);

        for (int i = 0; i < count; i++)
        {
            string name = PlayerPrefs.GetString("Scoreboard_s" + i);
            int score = PlayerPrefs.GetInt("Scoreboard_i" + i);
            Scores scores = new Scores(name, score);
            Scoreboard.Add(scores);
        }
        return Scoreboard;
    }

    /// <summary>
    /// Stores given score list to PlayerPrefs
    /// </summary>
    /// <param name="Scoreboard">Score list to store</param>
    public static void SaveScoreboard(List<Scores> Scoreboard)
    {
        if (Scoreboard.Count > MAX_SIZE) return;

        PlayerPrefs.SetInt("Scoreboard_count", Scoreboard.Count);
        for (int i = 0; i < Scoreboard.Count; i++)
        {
            PlayerPrefs.SetString("Scoreboard_s" + i, Scoreboard[i].name);
            PlayerPrefs.SetInt("Scoreboard_i" + i, Scoreboard[i].score);
        }
    }

    /// <summary>
    /// Adds score to given list
    /// </summary>
    /// <param name="Scoreboard">Score list</param>
    /// <param name="name">player name</param>
    /// <param name="score"></param>
    public static void AddSccore(List<Scores> Scoreboard, string name, int score)
    {
        if (Scoreboard.Count > MAX_SIZE || name.Length > 10) return;

        Scores scores = new Scores(name, score);
        Scoreboard.Add(scores);
    }
}
