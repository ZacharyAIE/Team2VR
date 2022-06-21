using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison 
{ 

    public class GameManager : MonoBehaviour
    {
        CharacterInstanceData trueCharacterInstanceData;
        ValidPurposeCombo validPurposeCombos;
        bool isCharacterAcceptable;
        //CharacterInstanceData falseCharacterInstanceData;

        public PossibleVisaData visaData;
        public PossibleShipData shipData;

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
            validPurposeCombos = GetComponent<ValidPurposeCombo>();
            //falseCharacterInstanceData = gameObject.AddComponent<CharacterInstanceData>();
            GenerateCharacter();
            var ship = Instantiate(trueCharacterInstanceData.shipData.shipModels[Random.Range(0, shipData.shipNames.Count)], shipSpawnPoint.position, Quaternion.identity);
            ship.transform.parent = shipSpawnPoint;

            Debug.Log(IsCharacterCorrect(trueCharacterInstanceData));
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
            trueCharacterInstanceData.SetVisaName();
            trueCharacterInstanceData.SetShip();
            trueCharacterInstanceData.SetVisaType();
            trueCharacterInstanceData.SetPlanetOfOrigin();
            trueCharacterInstanceData.SetDestination(trueCharacterInstanceData.shipPlanetOfOrigin); // Dont include our origin.
            trueCharacterInstanceData.SetPurpose();
            trueCharacterInstanceData.stayDuration = Random.Range(0, 52);

            // Randomise it
            RandomiseData(trueCharacterInstanceData);
        }

        public bool IsCharacterCorrect(CharacterInstanceData c)
        {
            if (CheckPurpose(c) && CheckName(c) && CheckOrigin(c) && CheckDestination(c))
            {
                isCharacterAcceptable = true;
            }
            else
            {
                isCharacterAcceptable = false;
            }
            return isCharacterAcceptable;

            
        }
        public bool CheckPurpose(CharacterInstanceData c)
        {
            if(c.visaDestination.restrictions.Count != 0)
            {
                foreach (Restriction r in c.visaDestination.restrictions)
                {
                    foreach (Purpose p in validPurposeCombos.purposes)
                    {
                        if (p.Compare(c.visaType, r))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckName(CharacterInstanceData c)
        {
            if (c.shipOwnerName == c.visaName)
            {
                return true;
            }
            return false;
        }
        public bool CheckOrigin(CharacterInstanceData c)
        {
            if (c.shipPlanetOfOrigin == c.visaPlanetOfOrigin)
            {
                return true;
            }
            return false;
        }
        public bool CheckDestination(CharacterInstanceData c)
        {
            if (c.shipDestination == c.visaDestination)
            {
                return true;
            }
            return false;
        }
    }
}