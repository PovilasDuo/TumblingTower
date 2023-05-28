using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockProperties : MonoBehaviour
{
    public enum Property
    {
        Normal = 1,
        Sticky = 2,
        Sliding = 3,
        Feint = 4
    }

    public Property blockProperty;
    public GameObject playerPaddle;
    public bool isFading = false;
    public void ApplyProperty(GameObject obj)
    {
        switch (blockProperty)
        {
            case Property.Normal:
                Debug.Log("Spawned Normal Block");
                obj.GetComponent<MeshRenderer>().material = GlobalVariables.basic;
                break;
            case Property.Sticky:
                Debug.Log("Spawned Sticky Block");
                obj.GetComponent<MeshRenderer>().material = GlobalVariables.sticky;
                break;
            case Property.Sliding:
                Debug.Log("Spawned Sliding Block");
                obj.GetComponent<MeshRenderer>().material = GlobalVariables.sliding;
                break;
            case Property.Feint:
                Debug.Log("Spawned Feint Block");
                //obj.GetComponent<MeshRenderer>().material = GlobalVariables.feint;
                StartCoroutine(FadeOut(this.gameObject, 0, 10f));
                break;
            default:
                Debug.Log("No Block Type Specified");
                obj.GetComponent<MeshRenderer>().material = GlobalVariables.basic;
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Detected");
        // checks if landed block height > blockspawner height
        if (other.transform.position.y >= GlobalVariables.blockSpawnerHeight - GlobalVariables.increment)
        {
            GlobalVariables.blockSpawnerHeight = other.transform.position.y + GlobalVariables.increment + 7;
            GlobalVariables.canSpawnerMove = true;
        }
        if (!other.collider.CompareTag("Landed")) return;
        else
        {
            transform.tag = "Landed";
            transform.parent = playerPaddle.transform;
            if (blockProperty == Property.Sliding)
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (blockProperty == Property.Sticky)
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    public IEnumerator FadeOut(GameObject obj, float aValue, float fadeTime)
    {
        if (!obj.GetComponent<BlockProperties>().isFading)
        {
            obj.GetComponent<BlockProperties>().isFading = true;
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            Color color = renderer.material.color;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime)
            {
                Color newColor = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, aValue, t));
                renderer.material.color = newColor;
                yield return null;
            }
            Destroy(obj);
        }
    }

}
