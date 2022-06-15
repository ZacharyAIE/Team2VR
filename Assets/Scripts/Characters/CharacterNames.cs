using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison { 
    [CreateAssetMenu(fileName =("Name list"))]
    public class CharacterNames : ScriptableObject 
    {
        public List<string> names;
    }
}