using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifetimeStats : MonoBehaviour
{

    public TextMeshProUGUI TotalScore;
    public TextMeshProUGUI TotalLivesLost;
    public TextMeshProUGUI TotalCredits;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    public void ClearStats()
    {
        for (int i = 0; i < SaveManager.instance.UnlockedSkins.Length; i++)
        {
            SaveManager.instance.UnlockedSkins[i] = false;
        }
        SaveManager.instance.Save();
        PlayerPrefs.DeleteAll();
        UpdateText();
    }

    public void UpdateText()
    {
        TotalScore.text = "Total score: " + PlayerPrefs.GetInt("TotalScore", 0);
        TotalLivesLost.text = "Total lives lost: " + PlayerPrefs.GetInt("TotalLivesLost", 0);
        TotalCredits.text = "Current credits: " + PlayerPrefs.GetInt("Credits", 0);
    }
}
