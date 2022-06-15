using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    public class CharacterInstanceData : MonoBehaviour
    {
        public CharacterData characterData;
        public VisaData visaData;

        public string characterName;
        public string visaName;

        public string GenerateVisaName()
        {
            visaName = visaData.nameList[Random.Range(0, visaData.nameList.Count)]; // Turn this into a function with the list as a parameter
            if(characterName == null)
                characterName = visaName;

            return visaName;
        }
    }
}