using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    public List<Node> travelPoints;
    public GameObject ship;
    public float speed = 1;
    public Node current;

    private void Start()
    {
        ship = CharacterComparison.GameManager.Instance.shipGameObject;
        current = travelPoints[0];
    }

    private void Update()
    {
        if (!ship)
        {
            ship = CharacterComparison.GameManager.Instance.shipGameObject;
        }
        if (!current.completed && ship)
        {
            ship.transform.position = Vector3.MoveTowards(ship.transform.position, current.transform.position, speed * Time.deltaTime);
        }
        else
        {
            if(travelPoints.IndexOf(current) != travelPoints.Count - 1)
            {
                current = travelPoints[travelPoints.IndexOf(current) + 1];
            }
        }
                
    }

    public void ResetTravelPoints()
    {
        current = travelPoints[0];
        foreach(Node n in travelPoints)
        {
            n.SetIncomplete();
            n.GetComponent<Collider>().enabled = true;
        }
    }
}
