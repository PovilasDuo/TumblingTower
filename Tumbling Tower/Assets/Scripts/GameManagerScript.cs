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
        // stores the current scene for restart
        Debug.Log("Level name: " + SceneManager.GetActiveScene().name);
        PlayerPrefs.SetString("PreviousLevel", SceneManager.GetActiveScene().name);

        // score reset
        PlayerPrefs.SetInt("CurrentScore", 0);

        DataManager.LoadTextures();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Removes a life on collision, ends game if 0
    private void OnTriggerEnter(Collider colidedObject)
    {
        if (colidedObject.tag != null)
        {
            Debug.Log("Life lost");
            Destroy(Hearts[Lives - 1]);
            Lives--;
            SaveManager.instance.TotalLivesLost += 1;
            SaveManager.instance.Save();
            if (Lives == 0)
            {
                Lives = 3;

                // adds score to credits
                PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits")
                                            + PlayerPrefs.GetInt("CurrentScore"));
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
