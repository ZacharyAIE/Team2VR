using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{

    /// <summary>
    /// Stores all possible character names 
    /// </summary>
    [CreateAssetMenu(menuName = "Character/Visa Data")]
    public class PossibleVisaData : ScriptableObject
    {
        public List<string> nameList; // Master list of names
        public List<GameObject> characterModels;
    }
}