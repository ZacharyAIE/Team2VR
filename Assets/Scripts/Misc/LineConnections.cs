using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class draws lines between a list of <see cref="Vector3"/> points
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class LineConnections : MonoBehaviour
{
    public List<GameObject> objects;
    List<Vector3> positions = new List<Vector3>();
    LineRenderer lineRenderer;

    private void Start()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
        foreach (GameObject g in objects)
        {
            positions.Add(g.transform.position);
            
        }
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }
}
