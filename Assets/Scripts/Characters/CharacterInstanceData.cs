using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    public class CharacterInstanceData : MonoBehaviour
    {
        public PossibleShipData shipData;
        public PossibleVisaData visaData;
        ValidPurposeCombo validPurposeCombo;
        public PlanetList planetList;

        [Header("SHIP DATA")]
        public string shipName;
        public string shipOwnerName;
        public Planet shipPlanetOfOrigin;
        public Planet shipDestination;
        public Ship ship;

        [Header("VISA DATA")]
        public string visaName;
        public VisaType visaType;
        public Planet visaPlanetOfOrigin;
        public Planet visaDestination;
        private Purpose visaPurpose;
        [Tooltip("In Weeks")] public int stayDuration;

        private void Awake()
        {
            planetList = GetComponent<PlanetList>();
            validPurposeCombo = GetComponent<ValidPurposeCombo>();
        }

        public void SetShip()
        {
            ship = gameObject.AddComponent<Ship>();
        }

        public string SetVisaName()
        {
            visaName = visaData.nameList[Random.Range(0, visaData.nameList.Count)]; // Turn this into a function with the list as a parameter
            if(shipOwnerName == null)
                shipOwnerName = visaName;

            return visaName;
        }

        

        public Planet SetPlanetOfOrigin()
        {
            visaPlanetOfOrigin = planetList.planetList[Random.Range(0, planetList.planetList.Count)];

            if (shipPlanetOfOrigin == null)
                shipPlanetOfOrigin = visaPlanetOfOrigin;

            return visaPlanetOfOrigin;
        }

        public Planet SetDestination(Planet excludePlanet)
        {
            if(excludePlanet != shipPlanetOfOrigin && excludePlanet != visaPlanetOfOrigin) { }
                visaDestination = planetList.planetList[Random.Range(0, planetList.planetList.Count)];

            if (shipDestination == null)
                shipDestination = visaDestination;
            return visaDestination;
        }

        public Purpose SetPurpose()
        {
            visaPurpose = validPurposeCombo.purposes[Random.Range(0, validPurposeCombo.purposes.Count)];

            return visaPurpose;
        }

        public VisaType SetVisaType()
        {
            visaType = (VisaType)Random.Range(0, System.Enum.GetNames(typeof(Restriction)).Length);

            return visaType;
        }

    }
}