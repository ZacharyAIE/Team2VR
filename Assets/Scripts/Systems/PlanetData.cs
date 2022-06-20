using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{

    [CreateAssetMenu(menuName = "Planet / Create Planet")]
    public class PlanetData : ScriptableObject
    {
        public string planetName;
        public int restrictionAmount;
        public int restrictedItemAmount;
    }
}
