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

    // This class stores data about the ship specifically
    public class Ship : MonoBehaviour
    {
        private CargoList cargoList;
        private ShipTypeList shipTypeList;
        private PossibleShipData possibleShipData;

        public string shipName;
        public string shipID;
        public GameObject shipModel;
        public ShipType shipType;
        public List<CargoItem> cargoItems = new List<CargoItem>();
        

        private void Awake()
        {
            cargoList = FindObjectOfType<CargoList>();
            shipTypeList = FindObjectOfType<ShipTypeList>();
            possibleShipData = GetComponent<GameManager>().shipData;
            GenerateShip();
        }

        public void SetShipType()
        {
            // Randomly select ship type
            shipType = shipTypeList.shipTypes[Random.Range(0, shipTypeList.shipTypes.Count)];
        }

        // Get a random ID for the ship, for flavour text.
        public void SetShipID()
        {
            System.Random rnd = new System.Random();
            char randomChar = (char)rnd.Next('a', 'z');
            shipID = Random.Range(1000000, 9999999).ToString() + randomChar.ToString().ToUpper();
            
        }

        public void GenerateShip()
        {
            SetShipName();
            SetShipType();
            SetCargo();
            SetShipID();
        }

        // Reset all data then regenerate it
        public void ResetShip()
        {
            shipName = null;
            shipModel = null; // To Replace
            shipType._maxCargo = 0;
            shipType._shipType = 0;
            cargoItems.Clear();
            GenerateShip();
        }

        // Populate the cargo hold with random cargo items from a list
        public void SetCargo()
        {
            for(int i = 0; i < shipType._maxCargo; i++)
            {
                cargoItems.Add(cargoList.cargoItems[Random.Range(0, cargoList.cargoItems.Count)]);
            }
            
        }

        // Set the ship name
        public string SetShipName()
        {
            shipName = possibleShipData.shipNames[Random.Range(0, possibleShipData.shipNames.Count)]; // Turn this into a function with the list as a parameter

            return shipName;
        }
    }

    // This struct determines how much cargo a ship type enum can hold.
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