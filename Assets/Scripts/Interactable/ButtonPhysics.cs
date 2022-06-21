using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class manages the Button physics byt controlling the treshold, dead zone and the configurable joint.
/// It also handles the event system for what happenes on each state (i.e OnPressed, turn on the ligh or  OnReleased open the door)
/// </summary>
public class ButtonPhysics : MonoBehaviour
{
    [Tooltip("How far the button can be pressed down")]
    [SerializeField] private float threshold = 0.1f;

    [Tooltip("How far a button needs to be pushed to register as pressed")]
    [SerializeField] private float deadZone = 0.025f;

    private bool isPressed;
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
        if (!isPressed && GetValue() + threshold >= 1)
            Pressed();
        if(isPressed && GetValue() + threshold >= 0)
            Released();
    }

    // Get the current value of the button to determain it's state, from -1 to 0 and 0 to 1.
    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Button is pressed");
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Button is released");
    }
}
