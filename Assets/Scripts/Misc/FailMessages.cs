using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    /// <summary>
    /// This class stores a list of possible fail messages.
    /// This is used in <see cref="FailCitationUI"/>.
    /// </summary>
    [CreateAssetMenu(menuName = "Fail Message List")]
    public class FailMessages : ScriptableObject
    {
        [Multiline(10)] public List<string> possibleFailMessages;
    }
}


