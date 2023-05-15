using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public FormatBlockSpawner blockSpawner;

    public TextMeshProUGUI nextBlock;
    public TextMeshProUGUI score;
    public TextMeshProUGUI difficulty;
    public GameObject levelCompleteText;

    // Start is called before the first frame update
    void Start()
    {
        levelCompleteText.gameObject.SetActive(false);
        StartCoroutine(ScoreRefresh());
        difficulty.text = "Block variety: " + blockSpawner.level.blockVariety;
    }

    // Update is called once per frame
    void Update()
    {
        if (blockSpawner.isComplete)
            levelCompleteText.gameObject.SetActive(true);

        PlayerPrefs.SetInt("CurrentScore", blockSpawner.caughtBlocks);
        score.text = PlayerPrefs.GetInt("CurrentScore").ToString();
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
