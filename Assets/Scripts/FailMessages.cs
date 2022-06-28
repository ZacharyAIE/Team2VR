using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fail Message List")]
public class FailMessages : ScriptableObject
{
    [Multiline(10)]public List<string> possibleFailMessages;
}
