using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormatBlockSpawner : MonoBehaviour
{
    public bool spawnsEnabled = true;
    public GameObject blockTemplate;
    public GameObject playerPaddle;

    public LevelFormat level;

    public bool isComplete = false;
    public int caughtBlocks = 0;

    private System.Random _R = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[BlockSpawner] Blockspawner Started!");
        Debug.Log("[BlockSpawner] Custom Blocks Detected: " + level.blockList.Count);
        Debug.Log("[BlockSpawner] Starting Spawns");
        Invoke("StartSpawns", level.spawnDelay);
    }

    IEnumerator SpawnBlocks()
    {
        while (true)
        {
            if (caughtBlocks >= level.maxBlockCount)
            {
                Debug.Log("All Blocks have been spawned! Level is finished.");
                isComplete = true;

                // adds score to credits
                PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits")
                    + PlayerPrefs.GetInt("CurrentScore"));

                break;
            }


            // moves spawner when highest block reaches screen limit
            if (GlobalVariables.canSpawnerMove)
            {
                transform.position = new Vector3(transform.position.x, GlobalVariables.blockSpawnerHeight, 0);
                GlobalVariables.canCameraMove = true;
                GlobalVariables.canSpawnerMove = false;
            }

            // block size
            int blockSize = _R.Next(level.blockList.Count);

            // Spawn Block
            CustomBlock toSpawn = level.blockList[blockSize];

            var allProperties = Enum.GetValues(typeof(BlockProperties.Property));
            GameObject newBlock = GameObject.Instantiate(blockTemplate);
            BlockProperties.Property selectedProperty = (BlockProperties.Property)allProperties.GetValue(_R.Next(level.blockVariety));

            newBlock.GetComponent<BlockProperties>().blockProperty = selectedProperty;
            newBlock.GetComponent<BlockProperties>().playerPaddle = playerPaddle;
            newBlock.GetComponent<BlockProperties>().ApplyProperty(newBlock);

            newBlock.transform.localScale = new Vector3(toSpawn.x_value, toSpawn.y_value, toSpawn.z_value);
            newBlock.transform.position = transform.position;

            yield return new WaitForSeconds(level.spawnDelay);
        }
    }

    void StartSpawns()
    {
        if (spawnsEnabled)
        {
            StartCoroutine(SpawnBlocks());
        }
    }

    public void CountBlocks()
    {
        GameObject[] list;
        list = GameObject.FindGameObjectsWithTag("Landed");
        caughtBlocks = list.Length - 2;
    }


}
