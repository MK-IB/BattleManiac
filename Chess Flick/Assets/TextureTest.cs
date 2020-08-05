using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureTest : MonoBehaviour
{
    public Texture texture;
    public Material material;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            material.mainTexture = texture;
            material.color = Color.white;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            material.mainTexture = null;
            material.color = Color.yellow;
        }
    }
}
