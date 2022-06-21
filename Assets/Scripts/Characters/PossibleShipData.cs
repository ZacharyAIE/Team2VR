using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    // This class stores all ship names and ship models
    [CreateAssetMenu(menuName = "Character/Ship Data")]
    public class PossibleShipData : ScriptableObject
    {
        public List<string> shipNames;
        public List<GameObject> shipModels;
    }

    
}