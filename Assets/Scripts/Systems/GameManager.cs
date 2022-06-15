using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison 
{ 

    public class GameManager : MonoBehaviour
    {
        CharacterInstanceData trueCharacterInstanceData;
        CharacterInstanceData falseCharacterInstanceData;

        public VisaData visaData;
        public CharacterData characterData;

        public float randomiseChance = 0.8f; // % as a decimal

        public Transform shipSpawnPoint;

        // GAME MANAGER SINGLETON INSTANCE
        public static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        void Start()
        {
            // Create the Character Data Instances
            trueCharacterInstanceData = gameObject.AddComponent<CharacterInstanceData>();
            falseCharacterInstanceData = gameObject.AddComponent<CharacterInstanceData>();
            GenerateCharacter();      
        }

        void Update()
        {
            // Debugging
            Debug.Log("True Name: " + trueCharacterInstanceData.characterName);
            Debug.Log("True Visa: " + trueCharacterInstanceData.visaName);

            Debug.Log("False Name: " + falseCharacterInstanceData.characterName);
            Debug.Log("False Visa: " + falseCharacterInstanceData.visaName);
        }

        public void RandomiseData(CharacterInstanceData data)
        {
            var seed = Random.value;

            // Randomise the name with 20% chance
            if(seed < randomiseChance)
            {
                data.visaName = data.visaData.nameList[Random.Range(0, data.visaData.nameList.Count)];
                data.characterName = data.visaData.nameList[Random.Range(0, data.visaData.nameList.Count)];
            }
        }

        public void GenerateCharacter()
        {
            trueCharacterInstanceData.visaData = visaData;
            trueCharacterInstanceData.characterData = characterData;
            trueCharacterInstanceData.GenerateVisaName();

            // Set up the false instance data
            falseCharacterInstanceData.visaData = visaData;
            falseCharacterInstanceData.characterData = characterData;
            falseCharacterInstanceData.visaName = trueCharacterInstanceData.visaName;
            falseCharacterInstanceData.characterName = trueCharacterInstanceData.characterName;

            // Randomise it
            RandomiseData(falseCharacterInstanceData);
        }
    }
}