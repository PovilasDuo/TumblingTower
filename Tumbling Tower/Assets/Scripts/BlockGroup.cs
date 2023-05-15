using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockGroup 
{
    public List<CustomBlock> blocks = new List<CustomBlock>();

    public BlockGroup(List<CustomBlock> blocks)
    {
        this.blocks = blocks;
    }
}
