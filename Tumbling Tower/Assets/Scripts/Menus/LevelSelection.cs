using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public int Level;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SelectLevel()
    {
        // level scene naming format: "Level1", "Level2"... in path: Levels/Levelx
        int buildIndex = SceneUtility.GetBuildIndexByScenePath("Levels/Level " + Level);
        if (buildIndex == -1)
            SceneManager.LoadScene("PoviloScena");
        else
            SceneManager.LoadScene(buildIndex);

    }
}
