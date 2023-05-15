using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeintBlock : MonoBehaviour
{
    public Renderer Block;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Color c = Block.material.color;
        for (float alpha = 1f; alpha >0.1f; alpha -= 0.01f)
        {
            c.a = alpha;
            Block.material.color = c;

            yield return new WaitForSeconds(0.01f);
        }
    }
}
