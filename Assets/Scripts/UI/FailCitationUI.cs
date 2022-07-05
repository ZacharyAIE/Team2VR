using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CharacterComparison;


/// <summary>
/// This class is responsible for populating the UI of citation notes from a <see cref="FailMessages"/> Scriptable Object
/// </summary>
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class FailCitationUI : MonoBehaviour
{
    public FailMessages failMessages;
    public TMP_Text failMessageBox;

    private void Start()
    {
        failMessageBox.text = failMessages.possibleFailMessages[Random.Range(0, failMessages.possibleFailMessages.Count)];
    }
}
