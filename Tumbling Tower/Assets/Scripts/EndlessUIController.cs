using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndlessUIController : MonoBehaviour
{

    public EndlessSpawner blockSpawner;

    public TextMeshProUGUI currentBlockText;
    public TextMeshProUGUI nextBlock;
    public TextMeshProUGUI score;
    public TextMeshProUGUI difficulty;

    // Start is called before the first frame update
    void Start()
    {
        currentBlockText.text = "Block NR: 0";
        StartCoroutine(ScoreRefresh());
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("CurrentScore", blockSpawner.caughtBlocks);
        score.text = PlayerPrefs.GetInt("CurrentScore").ToString();
        difficulty.text = "Difficulty rank: " + blockSpawner.level.spawnDelay;
    }

    IEnumerator ScoreRefresh()
    {
        while (true)
        {
            blockSpawner.CountBlocks();
            yield return new WaitForSeconds(1);
        }
    }

}