using UnityEngine;
using UnityEngine.Events;

namespace CharacterComparison 
{ 

    public class GameManager : MonoBehaviour
    {
        public CharacterInstanceData trueCharacterInstanceData;
        public int citationLimit = 5;
        ValidPurposes validPurposes;
        [Tooltip("Insert the list of possible data in the visa")]
        public PossibleVisaData visaData;
        [Tooltip("Insert the list of possible data for ship data")]
        public PossibleShipData shipData;
        public GameObject shipGameObject;
        [Tooltip("The place where the ship should be instantiated when the character is generated")]
        public Transform shipSpawnPoint;
        [Tooltip("Chance for the character to have randomised data")]
        public float randomiseChance = 0.8f; // % as a decimal
        bool isCharacterAcceptable;
        public UnityEvent OnAnswerCorrect;
        public UnityEvent OnAnswerIncorrect;



        // GAME MANAGER SINGLETON INSTANCE
        public static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();
                }
                return instance;
            }
        }

        void Start()
        {
            // Create the Character Data Instances
            trueCharacterInstanceData = gameObject.AddComponent<CharacterInstanceData>();
            validPurposes = GetComponent<ValidPurposes>();
            //falseCharacterInstanceData = gameObject.AddComponent<CharacterInstanceData>();
            GenerateCharacter();
            shipGameObject = Instantiate(trueCharacterInstanceData.shipData.shipModels[Random.Range(0, shipData.shipNames.Count)], shipSpawnPoint.position, Quaternion.identity);
            shipGameObject.transform.parent = shipSpawnPoint;

            Debug.Log(IsCharacterCorrect(trueCharacterInstanceData));
        }

        [ContextMenu("Reset Character")]
        public void ResetGameState()
        {
            Destroy(shipGameObject);
            trueCharacterInstanceData.ResetShip();
            GenerateCharacter();
            
            shipGameObject = Instantiate(trueCharacterInstanceData.shipData.shipModels[Random.Range(0, shipData.shipNames.Count)], shipSpawnPoint.position, Quaternion.identity);
            shipGameObject.transform.parent = shipSpawnPoint;
        }

        private void RandomiseData(CharacterInstanceData data)
        {
            var seed = Random.value;

            // Randomise the name with 20% chance
            if(seed < randomiseChance)
            {
                data.visaName = data.visaData.nameList[Random.Range(0, data.visaData.nameList.Count)];
                data.shipOwnerName = data.visaData.nameList[Random.Range(0, data.visaData.nameList.Count)];
                data.ship.shipName = data.shipData.shipNames[Random.Range(0, data.shipData.shipNames.Count)];
                data.shipPlanetOfOrigin = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.visaPlanetOfOrigin = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.shipDestination = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.visaDestination = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
            }
        }

        // Generate the data for the character
        private void GenerateCharacter()
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

        // These functions check whether the character would be considered correct.
        private bool IsCharacterCorrect(CharacterInstanceData c)
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
        private bool CheckPurpose(CharacterInstanceData c)
        {
            if(c.visaDestination.restrictions.Count != 0)
            {
                foreach (Restriction r in c.visaDestination.restrictions)
                {
                    foreach (Purpose p in validPurposes.purposeCombo.purposes)
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
        private bool CheckName(CharacterInstanceData c)
        {
            if (c.shipOwnerName == c.visaName)
            {
                return true;
            }
            return false;
        }
        private bool CheckOrigin(CharacterInstanceData c)
        {
            if (c.shipPlanetOfOrigin == c.visaPlanetOfOrigin)
            {
                return true;
            }
            return false;
        }
        private bool CheckDestination(CharacterInstanceData c)
        {
            if (c.shipDestination == c.visaDestination)
            {
                return true;
            }
            return false;
        }
        public void AcceptButton()
        {
            if (IsCharacterCorrect(trueCharacterInstanceData))
                OnAnswerCorrect.Invoke();
            else
                OnAnswerIncorrect.Invoke();
        }

        public void DenyButton()
        {
            if (!IsCharacterCorrect(trueCharacterInstanceData))
                OnAnswerCorrect.Invoke();
            else
                OnAnswerIncorrect.Invoke();
        }
    }
}