using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkin : MonoBehaviour
{
    public int SkinNumber;
    public Texture[] textures;
    // Start is called before the first frame update
    public void SetTexture()
    {
        Resources.Load<Material>("block_basic").SetTexture("_MainTex", textures[SkinNumber]);
    }

}
