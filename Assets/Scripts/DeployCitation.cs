using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterComparison;

public class DeployCitation : MonoBehaviour
{
    public FailCitationUI failCitation;
    public Transform exitPoint;
    public UnityEvent citationDeployed;
    public UnityEvent maxCitationsReached;
    public float exitSpeed = 50;
    private int currentCitationCount;

    public void GenerateCitation()
    {
        // If we hit the max count, run an event - lose the game
        if(currentCitationCount > GameManager.Instance.citationLimit)
        {
            maxCitationsReached.Invoke();
        }
        var temp = Instantiate(failCitation, exitPoint.position, Quaternion.identity);
        temp.transform.parent = null;
        temp.GetComponent<Rigidbody>().AddForce(exitPoint.forward * exitSpeed);
        temp = null;
        citationDeployed.Invoke();
    }
}
