using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{

    public enum ShipTypes
    {
        Cargo,
        Personal,
        Transport,
        Cruiser
    }


    [CreateAssetMenu(menuName = "Character/Create Ship Type")]
    public class Ship : ScriptableObject
    {
        public ShipTypes shipType;
        public List<CargoItem> cargoItems;

    }
}