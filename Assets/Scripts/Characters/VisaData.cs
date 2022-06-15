using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    [CreateAssetMenu(menuName = "Character/Create Visa")]
    public class VisaData : ScriptableObject
    {
        public List<string> nameList; // Master list of names
        public List<Sprite> characterSprites;
    }
}