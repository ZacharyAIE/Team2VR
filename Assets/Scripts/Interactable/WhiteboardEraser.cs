using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WhiteboardEraser : MonoBehaviour
{
    [SerializeField] private Transform eraser;
    [SerializeField] private int eraserSize;
    [SerializeField] private Whiteboard whiteboard;

    private Renderer renderer;
    private Color[] colors;
    private float eraserHight;

    private RaycastHit touch;
    private Vector2 touchPos;
    private Vector2 lastTouchPos;
    private bool touchedLastFrame;
    private Quaternion lastTouchRot;

    void Start()
    {
        //renderer = whiteboard.GetComponent<Renderer>().material.color;
        renderer = eraser.GetComponent<Renderer>();
        colors = Enumerable.Repeat(renderer.material.color, eraserSize * eraserSize).ToArray();
        eraserHight = eraser.localScale.y;
    }

    void Update()
    {
        Erase();
    }

    private void Erase()
    {
        if (Physics.Raycast(eraser.position, transform.up, out touch, eraserHight))
        {
            // Check if we actually drwaing on a whiteboard 
            if (touch.transform.CompareTag("Whiteboard"))
            {
                // if whiteboard components is missing, add it
                if (whiteboard == null)
                    whiteboard = touch.transform.GetComponent<Whiteboard>();


                touchPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                // translate the touch point on the whiteboard in unity to the x y pixels within the resolution
                var x = (int)(touchPos.x * whiteboard.textureSize.x - (eraserSize / 2));
                var y = (int)(touchPos.y * whiteboard.textureSize.x - (eraserSize / 2));

                // Check if we trying to draw on the whiteboard still
                if (y < 0 || y >= whiteboard.textureSize.y || x < 0 || x >= whiteboard.textureSize.x)
                    return;

                // If we touched last frame, we do work 1 frame late
                if (touchedLastFrame)
                {
                    // set the last initial group of pixels we touced
                    whiteboard.texture.SetPixels(x, y, eraserSize, eraserSize, colors);

                    // Interpolate between our last point touched and this point we touching, fill in the pixels space between them with color 
                    for (float f = 0.01f; f < 1.00; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(lastTouchPos.y, y, f);
                        whiteboard.texture.SetPixels(lerpX, lerpY, eraserSize, eraserSize, colors);
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
