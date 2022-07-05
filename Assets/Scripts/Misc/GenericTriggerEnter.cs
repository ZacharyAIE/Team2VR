using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class allows trigger enter, exit and stay functions to be used through events. This is useful for small physics interactions that need a way to be triggered.
/// </summary>
public class GenericTriggerEnter : MonoBehaviour
{
    public Collider collider;
    public UnityEvent OnTriggerEntered;
    public UnityEvent OnTriggerExited;
    public UnityEvent OnTriggerStayed;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        OnTriggerExited.Invoke();
    }
    private void OnTriggerStay(Collider other)
    {
        OnTriggerStayed.Invoke();
    }
}
