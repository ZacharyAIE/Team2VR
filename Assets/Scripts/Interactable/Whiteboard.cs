using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This class uses Texture2D and rendered to set-up the whiteboard based on the resolution provided
/// </summary>
public class Whiteboard : MonoBehaviour
{
    // Getting the resolution
    public Texture2D texture; 
    public Vector2 textureSize = new Vector2(2048, 2048);

    


    /// <summary>
    /// setting the resolution as a new texture so we can manipulate it 
    /// </summary>
    private void Start()
    {
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        Color[] color = Enumerable.Repeat(Color.white, (int)textureSize.x * (int)textureSize.y).ToArray();
        texture.SetPixels(color);
        GetComponent<Renderer>().material.mainTexture = texture;
    }
}
