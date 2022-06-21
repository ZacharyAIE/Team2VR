using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{

    public enum ShipTypes
    {
        Cargo,
        Personal,
        Transport,
        Cruiser
    }

    public class Ship : MonoBehaviour
    {
        private CargoList cargoList;
        private ShipTypeList shipTypeList;
        private PossibleShipData possibleShipData;

        public string shipName;
        public GameObject shipModel;
        public ShipType shipType;
        public List<CargoItem> cargoItems = new List<CargoItem>();
        

        private void Awake()
        {
            cargoList = FindObjectOfType<CargoList>();
            shipTypeList = FindObjectOfType<ShipTypeList>();
        }

        public void SetShipType()
        {
            shipType = shipTypeList.shipTypes[Random.Range(0, shipTypeList.shipTypes.Count)];
        }

        private void Start()
        {
            possibleShipData = GetComponent<GameManager>().shipData;
            SetShipName();
            SetShipType();
            SetCargo();
        }

        public void SetCargo()
        {
            for(int i = 0; i < shipType._maxCargo; i++)
            {
                cargoItems.Add(cargoList.cargoItems[Random.Range(0, cargoList.cargoItems.Count)]);
            }
            
        }
        public string SetShipName()
        {
            shipName = possibleShipData.shipNames[Random.Range(0, possibleShipData.shipNames.Count)]; // Turn this into a function with the list as a parameter

            return shipName;
        }
    }

    [System.Serializable]
    public struct ShipType
    {
        public ShipTypes _shipType;
        public int _maxCargo;

        // Compare the params to the given enums
        public bool Compare(ShipTypes st, int cargoMax)
        {
            if (st == _shipType && cargoMax == _maxCargo)
                return true;
            else
                return false;
        }
    }
}