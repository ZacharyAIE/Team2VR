using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    // This enum stores all visa types, Designers, this is for you :)
    public enum VisaType
    {
        Humanitarian,
        Tourist,
        Military,
        Citizen,
        Diplomatic
    }

    // Stores all possible character names 
    [CreateAssetMenu(menuName = "Character/Visa Data")]
    public class PossibleVisaData : ScriptableObject
    {
        public List<string> nameList; // Master list of names
        public List<GameObject> characterModels;
    }
}