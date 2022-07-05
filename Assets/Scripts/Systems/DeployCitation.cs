using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterComparison;

/// <summary>
/// This class is responsible for instantiating citations.
/// </summary>
public class DeployCitation : MonoBehaviour
{
    public FailCitationUI failCitation;
    public Transform exitPoint;
    public UnityEvent citationDeployed;
    public UnityEvent maxCitationsReached;
    public float exitSpeed = 50;
    private int currentCitationCount;

    /// <summary>
    /// Instantiates an object with a <see cref="FailCitationUI"/>
    /// </summary>
    public void GenerateCitation()
    {
        // If we hit the max count, run an event - lose the game
        if(currentCitationCount > GameManager.Instance.citationLimit)
        {
            maxCitationsReached.Invoke();
        }
        currentCitationCount++;
        var temp = Instantiate(failCitation, exitPoint.position, Quaternion.identity);
        temp.transform.parent = null;
        temp.GetComponent<Rigidbody>().AddForce(exitPoint.forward * exitSpeed);
        temp = null;
        citationDeployed.Invoke();
    }
}
