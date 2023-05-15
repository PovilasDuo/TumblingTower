using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public GameObject playerPaddle { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collision Detected");
        //if (!other.collider.CompareTag("Landed")) return;
        //transform.tag = "Landed";
        //transform.parent = playerPaddle.transform;
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("Collision Exit");

    }
}
