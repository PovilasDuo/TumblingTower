using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelFormat", menuName = "ScriptableObjects/Level Format", order = 2)]
public class LevelFormat : ScriptableObject
{
    // List of blocks to be spawned in the level.
    public List<CustomBlock> blockList = new List<CustomBlock>();
    // Delay between spawning different blocks.
    public int spawnDelay;
    // Maximum number of fails allowed.
    public int maxFails = 3;
    // Maximum number of fails allowed.
    public int blockVariety = 3;
    // Maximum number of blocks that can spawn.
    public int maxBlockCount = 3;

}
