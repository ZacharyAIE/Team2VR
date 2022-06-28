using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class manages the Button physics byt controlling the treshold, dead zone and the configurable joint.
/// It also handles the event system for what happenes on each state (i.e OnPressed, turn on the ligh or  OnReleased open the door)
/// </summary>
public class ButtonPhysics : MonoBehaviour
{
    /// <summary>
    /// How far the button can be pressed down
    /// ID string generated is "M:ButtonPhysics.threshold".
    /// </summary>
    [Tooltip("How far the button can be pressed down")]
    [SerializeField] private float threshold = 0.1f;

    /// <summary>
    /// How far the button needs to be pushed before registering its state
    /// ID string generated is "M:ButtonPhysics.deadZone".
    /// </summary>
    [Tooltip("How far a button needs to be pushed to register as pressed")]
    [SerializeField] private float deadZone = 0.025f;

    private bool isPressed;
    private bool isActive;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    public UnityEvent onPressed;
    public UnityEvent onReleased;

    private void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {

        if (!isPressed && GetValue() + threshold >= 1 && !isActive)
                Pressed();       
        if (isPressed && GetValue() + threshold <= 0.1f)
                Released();
    }

    /// <summary>
    /// Get the current value of the button to determain its state
    /// </summary>
    /// <returns>from -1 to 0 = is released and 0 to 1 = is pressed</returns>
    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    /// <summary>
    /// sets <param name="isPressed">Bool.</param> to true and invoke the OnPressed event 
    /// </summary>
    private void Pressed()
    {
        isPressed = true;
        isActive = true;
        onPressed.Invoke();
        Debug.Log("pressed");
    }

    /// <summary>
    /// sets <param name="isPressed">Bool.</param> to false and invoke the OnPressed event 
    /// </summary>
    private void Released()
    {
        isPressed = false;
        isActive = false;
        onReleased.Invoke();
        Debug.Log("Not pressed");
    }
}
