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

    [CreateAssetMenu(menuName = "Character/Create Ship List")]
    public class ShipData : ScriptableObject
    {
        public List<string> shipNames;
        public List<GameObject> shipModels;

        public List<AudioClip> voiceLines;
    }

    [CreateAssetMenu(menuName = "Character/Create Ship Type")]
    public class ShipType : ScriptableObject
    {
        ShipTypes shipType;
        List<CargoItem> cargoItems;

    }
}