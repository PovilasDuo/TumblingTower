using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class BlockSpawner : MonoBehaviour
{
    public bool spawnsEnabled = true;
    public GameObject blockTemplate;
    public GameObject playerPaddle;
    public List<BlockGroup> blockGroups = new List<BlockGroup>();
    public int secondsDelay = 5;
    public int currentBlock = 0;
    public int caughtBlocks = 0;

    public int currentDifficulty = 0;
    public int difficultyIncreaseStep = 5;
    public int difficultyStep = 0;
    private System.Random _R = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[BlockSpawner] Blockspawner Started!");
        Debug.Log("[BlockSpawner] Custom Groups Detected: " + blockGroups.Count);
        Debug.Log("[BlockSpawner] Starting Spawns");
        Invoke("StartSpawns", 5);

    }

    IEnumerator SpawnBlocks()
    {
        while (true)
        {
            // Spawn Block
            int blockSpawnDifficulty = currentDifficulty;
            if (currentDifficulty > blockGroups.Count-1) blockSpawnDifficulty = blockGroups.Count-1;
            CustomBlock toSpawn = blockGroups[blockSpawnDifficulty].blocks[UnityEngine.Random.Range(0, blockGroups[blockSpawnDifficulty].blocks.Count)];
            var allProperties = Enum.GetValues(typeof(BlockProperties.Property));
            GameObject newBlock = GameObject.Instantiate(blockTemplate);
            BlockProperties.Property selectedProperty = (BlockProperties.Property)allProperties.GetValue(_R.Next(allProperties.Length));
            newBlock.GetComponent<BlockProperties>().blockProperty = selectedProperty;
            newBlock.GetComponent<BlockProperties>().playerPaddle = playerPaddle;
            newBlock.GetComponent<BlockProperties>().ApplyProperty(newBlock);
            newBlock.transform.localScale = new Vector3(toSpawn.x_value, toSpawn.y_value, toSpawn.z_value);
            newBlock.transform.position = transform.position;
            Debug.Log("[BlockSpawner] Spawned Block | X - " + toSpawn.x_value + " | Y - " + toSpawn.y_value + " | Z - " + toSpawn.z_value + " |");
            Debug.Log("[BlockSpawner] Property: " + selectedProperty);
            currentBlock++;
            // Increase Difficulty Step
            difficultyStep++;
            // Check Difficulty Step
            if(difficultyStep >= difficultyIncreaseStep)
            {
                currentDifficulty++;
                difficultyStep= 0;
                if (secondsDelay > 1) secondsDelay--;
            }
            yield return new WaitForSeconds(secondsDelay);
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
