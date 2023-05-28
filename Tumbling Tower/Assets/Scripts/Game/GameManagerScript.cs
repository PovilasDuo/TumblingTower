using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static int Lives = 3;
    public GameObject[] Hearts = new GameObject[Lives];

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;     // VSync disable
        Application.targetFrameRate = 120;   // fps cap

        // stores the current scene for restart
        Debug.Log("Level name: " + SceneManager.GetActiveScene().name);
        PlayerPrefs.SetString("PreviousLevel", SceneManager.GetActiveScene().name);

        // score reset
        PlayerPrefs.SetInt("CurrentScore", 0);

        DataManager.LoadTextures();
    }

    // Removes a life on collision, ends game if 0
    private void OnTriggerEnter(Collider colidedObject)
    {
        if (colidedObject.tag != null)
        {
            Debug.Log("Life lost");
            Destroy(Hearts[Lives - 1]);
            Lives--;

            PlayerPrefs.SetInt("TotalLivesLost", PlayerPrefs.GetInt("TotalLivesLost", 0) + 1);

            if (Lives == 0)
            {
                Lives = 3;

                // adds score to credits
                PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits", 0)
                                            + PlayerPrefs.GetInt("CurrentScore"));
                PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore", 0)
                                            + PlayerPrefs.GetInt("CurrentScore"));
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
