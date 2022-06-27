using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    // Getting the resolution
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);


    // setting the resolution as a new texture so we can manipulate it 
    private void Start()
    {
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        GetComponent<Renderer>().material.mainTexture = texture;
    }
}
