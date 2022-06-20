using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison 
{ 

    public class GameManager : MonoBehaviour
    {
        ShipInstanceData trueCharacterInstanceData;
        ShipInstanceData falseCharacterInstanceData;

        public PossibleVisaData visaData;
        public ShipData characterData;

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
            trueCharacterInstanceData = gameObject.AddComponent<ShipInstanceData>();
            falseCharacterInstanceData = gameObject.AddComponent<ShipInstanceData>();
            GenerateCharacter();      
        }

        public void RandomiseData(ShipInstanceData data)
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
            // Set up the character's real data
            trueCharacterInstanceData.visaData = visaData;
            trueCharacterInstanceData.shipData = characterData;
            trueCharacterInstanceData.GenerateVisaName();

            // Set up the false instance data
            falseCharacterInstanceData.visaData = visaData;
            falseCharacterInstanceData.shipData = characterData;
            falseCharacterInstanceData.visaName = trueCharacterInstanceData.visaName;
            falseCharacterInstanceData.characterName = trueCharacterInstanceData.characterName;

            // Randomise it
            RandomiseData(falseCharacterInstanceData);
        }
    }
}