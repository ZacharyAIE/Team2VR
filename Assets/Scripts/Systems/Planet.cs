using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    // This class contains data about a planet.
    public class Planet : MonoBehaviour
    {
        public PlanetData planetData;
        public CargoList cargoList;
        public List<Restriction> restrictions;
        public List<CargoItem> restrictedItems;

        private void Start()
        {
            
            // Set random travel restrictions
            for (int i = 0; i < planetData.restrictionAmount; i++)
            {
                var rand = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Restriction)).Length);
                if (!restrictions.Contains((Restriction)rand))
                {
                    restrictions.Add((Restriction)rand);
                }
            }

            // Ban all globally illegal items
            for (int i = 0; i < cargoList.cargoItems.Count; i++)
            {
                if(cargoList.cargoItems[i] && !cargoList.cargoItems[i].isLegal)
                {
                    restrictedItems.Add(cargoList.cargoItems[i]);
                }
            }

            // Set random Planet-specific banned items
            for (int i = 0; i < planetData.restrictedItemAmount; i++)
            {
                var rand = UnityEngine.Random.Range(0, cargoList.cargoItems.Count);
                if (!restrictedItems.Contains(cargoList.cargoItems[rand]))
                {
                    restrictedItems.Add(cargoList.cargoItems[rand]);
                }
            }
        }
    }
}


                    


