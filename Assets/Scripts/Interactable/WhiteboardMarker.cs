using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This class manages the marker functions and handles all the drawing
/// It has a simple algorithm that draws each picel induvidually on the texture and then applies it 
/// </summary>
public class WhiteboardMarker : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private int penSize;

    private Renderer renderer;
    private Color[] colors;
    private float tipHeight;

    private RaycastHit touch;
    private Whiteboard whiteboard;
    private Vector2 touchPos;
    private Vector2 lastTouchPos;
    private bool touchedLastFrame;
    private Quaternion lastTouchRot;

    void Start()
    {
        renderer = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(renderer.material.color, penSize * penSize).ToArray();
        tipHeight = tip.localScale.y;
    }

    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Physics.Raycast(tip.position, transform.up, out touch, tipHeight))
        {
            // Check if we actually drwaing on a whiteboard 
            if (touch.transform.CompareTag("Whiteboard"))
            {
                // if whiteboard components is missing, add it
                if (whiteboard == null)
                    whiteboard = touch.transform.GetComponent<Whiteboard>();


                touchPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                // translate the touch point on the whiteboard in unity to the x y pixels within the resolution
                var x = (int)(touchPos.x * whiteboard.textureSize.x - (penSize / 2));
                var y = (int)(touchPos.y * whiteboard.textureSize.x - (penSize / 2));

                // Check if we trying to draw on the whiteboard still
                if (y < 0 || y >= whiteboard.textureSize.y || x < 0 || x >= whiteboard.textureSize.x)
                    return;

                // If we touched last frame, we do work 1 frame late
                if (touchedLastFrame)
                {
                    // set the last initial group of pixels we touced
                    whiteboard.texture.SetPixels(x, y, penSize, penSize, colors);

                    // Interpolate between our last point touched and this point we touching, fill in the pixels space between them with color 
                    for (float f = 0.01f; f < 1.00; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(lastTouchPos.y, y, f);
                        whiteboard.texture.SetPixels(lerpX, lerpY, penSize, penSize, colors);
                    }

                    // Lock pen rotation to prevent the pen from standing flat along the wall (using physics) while touching the board
                    transform.rotation = lastTouchRot;

                    // Update the texture and apply all the pixels we changed
                    whiteboard.texture.Apply();
                }

                // if we didn't touch last frame, set all the variables
                lastTouchPos = new Vector2(x, y);
                lastTouchRot = transform.rotation;
                touchedLastFrame = true;
                return;
            }
        }

        // If we didn't go trough any of the above, delete the chached whiteboard and last frame touched
        whiteboard = null;
        touchedLastFrame = false;
    }
}
