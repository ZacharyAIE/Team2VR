using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{

    [CreateAssetMenu(menuName = "Character/Ship Data")]
    public class ShipData : ScriptableObject
    {
        public List<string> shipNames;
        public List<GameObject> shipModels;
    }

    
}