using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{

    [CreateAssetMenu(menuName = "Create Cargo")]
    public class CargoItem : ScriptableObject
    {
        public string itemName;
        public bool isLegal;
    }

}