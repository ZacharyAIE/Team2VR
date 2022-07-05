using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    /// <summary>
    /// This class contains data about a planet.
    /// It uses data from a <see cref="CargoList"/> and <see cref="PlanetData"/>
    /// </summary>
    public class Planet : MonoBehaviour
    {
        public PlanetData planetData;
        public CargoList cargoList;
        public ValidPurposeCombo validPurposeCombos;
        public List<Purpose> restrictions;
        public List<CargoItem> restrictedItems;

        private void Awake()
        {
            
            // Set random travel restrictions
            for (int i = 0; i < planetData.restrictionAmount; i++)
            {
                var rand = validPurposeCombos.purposes[UnityEngine.Random.Range(0, validPurposeCombos.purposes.Count)];
                if (restrictions.FindIndex(p => ((p.restriction == rand.restriction) && (p.visaType == rand.visaType))) == -1)
                {
                    restrictions.Add(rand);
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


                    


