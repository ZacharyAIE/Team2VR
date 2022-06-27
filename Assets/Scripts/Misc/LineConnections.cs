using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
