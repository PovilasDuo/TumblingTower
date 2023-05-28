using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float transitionSpeed = 0.002f;
    public EndlessSpawner blockSpawner;
    //public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.canCameraMove = false;
        GlobalVariables.canSpawnerMove = false;
        GlobalVariables.blockSpawnerHeight = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.canCameraMove)
        {
            Vector3 position = new Vector3(0, blockSpawner.transform.position.y - 2, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, position, transitionSpeed);
        }
    }
}
