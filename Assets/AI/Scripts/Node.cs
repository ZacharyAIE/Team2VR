using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Node : MonoBehaviour
{
    public bool completed = false;

    public UnityEvent OnNodeComplete = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == CharacterComparison.GameManager.Instance.shipGameObject)
        {
            completed = true;

            //Trigger an event when completed.
            OnNodeComplete.Invoke();

            // Turn off collider so we dont accidentally 
            // clip another node and mess up the order
            GetComponent<Collider>().enabled = false;
        }
    }
    public void SetComplete()
    {
        completed = true;
    }
    public void SetIncomplete()
    {
        completed = false;
        GetComponent<Collider>().enabled = true;
    }
}

