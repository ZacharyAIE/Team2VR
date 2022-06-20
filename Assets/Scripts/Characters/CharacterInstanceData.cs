using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    public class CharacterInstanceData : MonoBehaviour
    {
        public ShipData shipData;
        public PossibleVisaData visaData;
        public PlanetList planetList;

        [Header("SHIP DATA")]
        public string shipName;
        public string shipOwnerName;
        public Planet shipPlanetOfOrigin;
        public Planet shipDestination;
        public Ship ship;

        [Header("VISA DATA")]
        public string visaName;
        public Planet visaPlanetOfOrigin;
        public Planet visaDestination;
        [Multiline(2)]public string visaPurpose;
        [Tooltip("In Weeks")] public int stayDuration;

        private void Awake()
        {
            planetList = GetComponent<PlanetList>();
        }

        public string GenerateVisaName()
        {
            visaName = visaData.nameList[Random.Range(0, visaData.nameList.Count)]; // Turn this into a function with the list as a parameter
            if(shipOwnerName == null)
                shipOwnerName = visaName;

            return visaName;
        }

        public string GenerateShipName()
        {
            shipName = shipData.shipNames[Random.Range(0, shipData.shipNames.Count)]; // Turn this into a function with the list as a parameter

            return shipName;
        }

        public Planet GeneratePlanetOfOrigin()
        {
            visaPlanetOfOrigin = planetList.planetList[Random.Range(0, planetList.planetList.Count)];

            if (shipPlanetOfOrigin == null)
                shipPlanetOfOrigin = visaPlanetOfOrigin;

            return visaPlanetOfOrigin;
        }

        public Planet GenerateDestination(Planet excludePlanet)
        {
            if(excludePlanet != shipPlanetOfOrigin && excludePlanet != visaPlanetOfOrigin) { }
                visaDestination = planetList.planetList[Random.Range(0, planetList.planetList.Count)];

            if (shipDestination == null)
                shipDestination = visaDestination;
            return visaDestination;
        }

        public string GeneratePurpose()
        {
            visaPurpose = visaData.purposes[Random.Range(0, visaData.purposes.Count)]; // Turn this into a function with the list as a parameter

            return visaPurpose;
        }

    }
}