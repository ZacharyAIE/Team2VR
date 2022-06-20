using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    public enum VisaType
    {
        Humanitarian,
        Tourist,
        Military,
        Citizen,
        Diplomatic
    }

    [CreateAssetMenu(menuName = "Character/Create Visa")]
    public class PossibleVisaData : ScriptableObject
    {
        public List<string> nameList; // Master list of names
        public List<Sprite> characterSprites;
        public List<string> planetsOfOrigin;
    }
}