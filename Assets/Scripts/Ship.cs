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

    public class Ship : MonoBehaviour
    {
        public string shipName;
        public GameObject shipModel;
        public ShipTypes shipType;
        public List<CargoItem> cargoItems;

    }
}