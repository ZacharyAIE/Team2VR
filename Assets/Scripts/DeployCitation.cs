using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCitation : MonoBehaviour
{
    public FailCitationUI failCitation;
    public Transform exitPoint;
    public float exitSpeed = 50;

    public void GenerateCitation()
    {
        var temp = Instantiate(failCitation, exitPoint.position, Quaternion.identity);
        temp.transform.parent = null;
        temp.GetComponent<Rigidbody>().AddForce(exitPoint.forward * exitSpeed);
        temp = null;
    }
}
