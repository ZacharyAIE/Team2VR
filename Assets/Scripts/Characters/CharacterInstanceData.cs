using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    /// <summary>
    /// This class stores and generates all data about the character
    /// It takes data from <see cref="PossibleShipData"/>, <see cref="PossibleVisaData"/>, <see cref="ValidPurposes"/> and <see cref="PlanetList"/>
    /// </summary>
    public class CharacterInstanceData : MonoBehaviour
    {
        public PossibleShipData shipData;
        public PossibleVisaData visaData;
        ValidPurposes validPurposes;
        public PlanetList planetList;

        [Header("SHIP DATA")]
        public string shipName;
        public string shipOwnerName;
        public Planet shipPlanetOfOrigin;
        public Planet shipDestination;
        public Ship ship;

        [Header("VISA DATA")]
        public string visaName;
        public GameObject visaCharacterModel;
        public VisaType visaType;
        public Planet visaPlanetOfOrigin;
        public Planet visaDestination;
        private Purpose visaPurpose;
        [Tooltip("In Weeks")] public int stayDuration;

        private void Awake()
        {
            planetList = GetComponent<PlanetList>();
            validPurposes = GetComponent<ValidPurposes>();
        }

        // Add the ship to the game manager.
        public void SetShip()
        {
            // Don't make a new one if we already have one.
            if(gameObject.GetComponent<Ship>() == null)
                ship = gameObject.AddComponent<Ship>();
            shipName = ship.shipName;
        }

        public void SetCharModel()
        {
            visaCharacterModel = visaData.characterModels[Random.Range(0, visaData.characterModels.Count)];
        }

        public string SetVisaName()
        {
            visaName = visaData.nameList[Random.Range(0, visaData.nameList.Count)]; // Turn this into a function with the list as a parameter
            shipOwnerName = visaName;

            return visaName;
        }

        // Reset the ship's data
        public void ResetShip()
        {
            ship.ResetShip();
        }

        public Planet SetPlanetOfOrigin()
        {
            visaPlanetOfOrigin = planetList.planetList[Random.Range(0, planetList.planetList.Count)];

            shipPlanetOfOrigin = visaPlanetOfOrigin;

            return visaPlanetOfOrigin;
        }

        public Planet SetDestination(Planet excludePlanet)
        {
            // Select a planet from a list of planets, but don't include their origin planet.
            if(excludePlanet != shipPlanetOfOrigin && excludePlanet != visaPlanetOfOrigin) { }
                visaDestination = planetList.planetList[Random.Range(0, planetList.planetList.Count)];

            shipDestination = visaDestination;
            return visaDestination;
        }

        public Purpose SetPurpose()
        {
            visaPurpose = validPurposes.purposeCombo.purposes[Random.Range(0, validPurposes.purposeCombo.purposes.Count)];

            return visaPurpose;
        }

        public VisaType SetVisaType()
        {
            if(visaDestination.restrictions.Count > 0)
                visaType = visaDestination.restrictions[0].visaType;
            else
                visaType = (VisaType)Random.Range(0, System.Enum.GetNames(typeof(Restriction)).Length);

            return visaType;
        }

    }
}