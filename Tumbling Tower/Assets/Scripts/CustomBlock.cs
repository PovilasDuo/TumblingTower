using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomBlock", menuName = "ScriptableObjects/Custom Block", order = 1)]
public class CustomBlock : ScriptableObject
{
    public int x_value;
    public int y_value;
    public int z_value;
    public BlockProperties.Property property;

    public CustomBlock(int x_value, int y_value, int z_value)
    {
        this.x_value = x_value;
        this.y_value = y_value;
        this.z_value = z_value;
    }
}
