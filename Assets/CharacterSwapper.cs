using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterComparison;

public class CharacterSwapper : MonoBehaviour
{
    
    public Transform characterPosition;
    public GameObject currentModel;


    public void SetCharacter()
    {
        if (currentModel != null)
            Destroy(currentModel);
        currentModel = Instantiate(GameManager.instance.trueCharacterInstanceData.visaCharacterModel, characterPosition);
    }
}
