using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    public static void SaveBlockTextures(string basic, string sticky,
                                         string sliding, string feint)
    {
        PlayerPrefs.SetString("basic", basic);
        PlayerPrefs.SetString("sticky", sticky);
        PlayerPrefs.SetString("sliding", sliding);
        PlayerPrefs.SetString("feint", feint);
    }

    /// <summary>
    /// Loads textures, if none are selected, loads default for each type
    /// </summary>
    public static void LoadTextures()
    {
        GlobalVariables.basic = (Material)Resources.Load(PlayerPrefs.GetString("basic", "block_basic"));
        GlobalVariables.sticky = (Material)Resources.Load(PlayerPrefs.GetString("basic", "block_sticky"));
        GlobalVariables.sliding = (Material)Resources.Load(PlayerPrefs.GetString("basic", "block_sliding"));
        GlobalVariables.feint = (Material)Resources.Load(PlayerPrefs.GetString("basic", "block_feint"));
    }
}
