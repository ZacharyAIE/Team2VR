using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison 
{ 

    public class GameManager : MonoBehaviour
    {
        CharacterInstanceData trueCharacterInstanceData;
        //CharacterInstanceData falseCharacterInstanceData;

        public PossibleVisaData visaData;
        public ShipData shipData;

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
            //falseCharacterInstanceData = gameObject.AddComponent<CharacterInstanceData>();
            GenerateCharacter();
            var ship = Instantiate(trueCharacterInstanceData.shipData.shipModels[Random.Range(0, shipData.shipNames.Count)], shipSpawnPoint.position, Quaternion.identity);
            ship.transform.parent = shipSpawnPoint;
        }

        public void RandomiseData(CharacterInstanceData data)
        {
            var seed = Random.value;

            // Randomise the name with 20% chance
            if(seed < randomiseChance)
            {
                data.visaName = data.visaData.nameList[Random.Range(0, data.visaData.nameList.Count)];
                data.shipOwnerName = data.visaData.nameList[Random.Range(0, data.visaData.nameList.Count)];
                data.shipName = data.shipData.shipNames[Random.Range(0, data.shipData.shipNames.Count)];
                data.shipPlanetOfOrigin = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.visaPlanetOfOrigin = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.shipDestination = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.visaDestination = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
            }
        }

        public void GenerateCharacter()
        {
            // Set up the character's real data
            trueCharacterInstanceData.visaData = visaData;
            trueCharacterInstanceData.shipData = shipData;
            trueCharacterInstanceData.GenerateVisaName();
            trueCharacterInstanceData.GenerateShipName();
            trueCharacterInstanceData.GeneratePlanetOfOrigin();
            trueCharacterInstanceData.GenerateDestination(trueCharacterInstanceData.shipPlanetOfOrigin); // Dont include our origin.
            trueCharacterInstanceData.GeneratePurpose();
            trueCharacterInstanceData.stayDuration = Random.Range(0, 52);

            //// Set up the false instance data
            //falseCharacterInstanceData.visaData = visaData;
            //falseCharacterInstanceData.shipData = shipData;
            //falseCharacterInstanceData.visaName = trueCharacterInstanceData.visaName;
            //falseCharacterInstanceData.shipName = trueCharacterInstanceData.shipName;
            //falseCharacterInstanceData.shipOwnerName = trueCharacterInstanceData.shipOwnerName;
            //falseCharacterInstanceData.shipDestination = trueCharacterInstanceData.shipDestination;
            //falseCharacterInstanceData.visaDestination = trueCharacterInstanceData.visaDestination;
            //falseCharacterInstanceData.planetOfOrigin = trueCharacterInstanceData.planetOfOrigin;
            //falseCharacterInstanceData.visaPlanetOfOrigin = trueCharacterInstanceData.visaPlanetOfOrigin;
            //falseCharacterInstanceData.visaPurpose = trueCharacterInstanceData.visaPurpose;

            // Randomise it
            RandomiseData(trueCharacterInstanceData);
        }
    }
}