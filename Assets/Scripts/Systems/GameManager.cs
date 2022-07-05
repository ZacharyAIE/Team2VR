using UnityEngine;
using UnityEngine.Events;

namespace CharacterComparison 
{ 
    /// <summary>
    /// This is the main class that handles game state and has access to all data on characters.
    /// The GameManager calls on various classes to generate character data then compares data points to determine if the character generated is acceptable.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [Header("Data Lists")]
        [Tooltip("Insert the list of possible data in the visa")]
        public PossibleVisaData visaData;
        [Tooltip("Insert the list of possible data for ship data")]
        public PossibleShipData shipData;

        [Header("Settings")]
        [Tooltip("How many times the player can choose the wrong option")] 
        public int failLimit = 5;
        [Tooltip("The place where the ship should be instantiated when the character is generated")]
        public Transform shipSpawnPoint;
        [Tooltip("Chance for the character to have randomised data")]
        public float randomiseChance = 0.8f; // % as a decimal
        public ParticleSystem explosionParticleSystem;


        public CharacterInstanceData trueCharacterInstanceData;
        
        ValidPurposes validPurposes;
        
        public GameObject shipGameObject;
        
        public CharacterSwapper characterCamera;
        bool isCharacterAcceptable;
        public UnityEvent OnAnswerCorrect;
        public UnityEvent OnAnswerIncorrect;
        public UnityEvent OnCharacterRefresh;



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
            GenerateCharacter();
            shipGameObject = Instantiate(trueCharacterInstanceData.shipData.shipModels[Random.Range(0, shipData.shipNames.Count)], shipSpawnPoint.position, Quaternion.identity);
            shipGameObject.transform.parent = shipSpawnPoint;

            
        }

        [ContextMenu("Reset Character")]
        public void ResetGameState()
        {
            explosionParticleSystem.Play();
            
            Destroy(shipGameObject);
            trueCharacterInstanceData.ResetShip();
            GenerateCharacter();
            
            shipGameObject = Instantiate(trueCharacterInstanceData.shipData.shipModels[Random.Range(0, shipData.shipNames.Count)], shipSpawnPoint.position, Quaternion.identity);
            shipGameObject.transform.parent = shipSpawnPoint;
        }

        /// <summary>
        /// Randomise the character data with randomiseChance
        /// </summary>
        /// <param name="data"></param>
        private void RandomiseData(CharacterInstanceData data)
        {
            var seed = Random.value;

            // If the generated value is less than randomise chance
            if(seed < randomiseChance)
            {
                data.visaName = data.visaData.nameList[Random.Range(0, data.visaData.nameList.Count)];
                data.shipOwnerName = data.visaData.nameList[Random.Range(0, data.visaData.nameList.Count)];
                data.ship.shipName = data.shipData.shipNames[Random.Range(0, data.shipData.shipNames.Count)];
                data.shipPlanetOfOrigin = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.visaPlanetOfOrigin = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.shipDestination = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.visaDestination = data.planetList.planetList[Random.Range(0, data.planetList.planetList.Count)];
                data.visaType = (VisaType)Random.Range(0, System.Enum.GetNames(typeof(Restriction)).Length);

            }
        }

        /// <summary>
        /// Calls all the Set functions on the character data
        /// </summary>
        private void GenerateCharacter()
        {
            // Set up the character's real data
            trueCharacterInstanceData.visaData = visaData;
            trueCharacterInstanceData.shipData = shipData;
            trueCharacterInstanceData.SetVisaName();
            trueCharacterInstanceData.SetShip();
            
            trueCharacterInstanceData.SetPlanetOfOrigin();
            trueCharacterInstanceData.SetDestination(trueCharacterInstanceData.shipPlanetOfOrigin); // Dont include our origin.
            trueCharacterInstanceData.SetVisaType();
            trueCharacterInstanceData.SetPurpose();
            trueCharacterInstanceData.SetCharModel();
            trueCharacterInstanceData.stayDuration = Random.Range(0, 52);

            // Randomise it
            RandomiseData(trueCharacterInstanceData);
            Debug.Log(IsCharacterCorrect(trueCharacterInstanceData));
        }

        /// <summary>
        /// Check whether the character would be considered correct.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
                foreach (Purpose p in validPurposes.purposeCombo.purposes)
                {
                    
                    if (c.visaType == p.visaType && c.visaDestination.restrictions.Contains(p))
                    {
                        return true;
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

        public void InvokeCharacterRefresh()
        {
            OnCharacterRefresh.Invoke();
        }
    }
}