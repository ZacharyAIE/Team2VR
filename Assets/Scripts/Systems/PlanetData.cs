using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    /// <summary>
    /// This scriptable object stores a planet's preset name and amount of travel and item restrictions
    /// </summary>
    [CreateAssetMenu(menuName = "Planet / Create Planet")]
    public class PlanetData : ScriptableObject
    {
        public string planetName;
        public string designation;
        public string societalStatus;
        public GameObject planetModel;
        public int restrictionAmount;
        public int restrictedItemAmount;
    }
}
