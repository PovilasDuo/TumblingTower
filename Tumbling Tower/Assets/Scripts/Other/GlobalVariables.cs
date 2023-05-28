using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{
    // block materials
    public static Material basic;
    public static Material sticky;
    public static Material sliding;
    public static Material feint;

    public static int increment = 1;
    public static float blockSpawnerHeight;
    public static bool canSpawnerMove;
    public static bool canCameraMove;
}
