using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    // This scriptable object stores a planet's preset name and amount of travel and item restrictions
    [CreateAssetMenu(menuName = "Planet / Create Planet")]
    public class PlanetData : ScriptableObject
    {
        public string planetName;
        public int restrictionAmount;
        public int restrictedItemAmount;
    }
}
