using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;
    public Transform playerTransform;
    private Vector3 playerPosition;
    public int MovementBounds = 0;


    void Start()
    {
        playerTransform = this.transform;
    }

    void Update()
    {
        // Check if the game is paused
        if (Time.timeScale != 0f)
        {

            playerPosition = playerTransform.position; // Takes the current player position
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerPosition -= new Vector3(speed, 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                playerPosition += new Vector3(speed, 0, 0);
            }
            playerTransform.position = playerPosition; // Delivers changes to the position
        }
    }
}
