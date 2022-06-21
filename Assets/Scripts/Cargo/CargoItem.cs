using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    // This scriptable object stores an item's name and whether it is globally illegal
    [CreateAssetMenu(menuName = "Create Cargo")]
    public class CargoItem : ScriptableObject
    {
        public string itemName;
        public bool isLegal;
    }

}