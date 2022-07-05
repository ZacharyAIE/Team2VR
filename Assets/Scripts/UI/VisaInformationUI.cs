using UnityEngine;
using UnityEngine.Events;
using TMPro;
using CharacterComparison;

/// <summary>
/// This class is responsible for populating the Visa UI panel with data from <see cref="CharacterInstanceData"/>
/// </summary>
public class VisaInformationUI : MonoBehaviour
{
    CharacterInstanceData character;

    public TMP_Text visaNameText;
    public TMP_Text visaOriginText;
    public TMP_Text visaDestinationText;
    public TMP_Text visaDurationText;
    public TMP_Text visaTypeText;
    public TMP_Text visaPurposeText;

    public UnityEvent visaChanged;

    public void SetVisa()
    {
        character = GameManager.Instance.trueCharacterInstanceData;

        ResetText();
        visaChanged.Invoke();
    }

    [ContextMenu("Set Visa")]
    public void Setup()
    {
        SetVisa();
    }

    [ContextMenu("Fill")]
    public void FillVisaInfo()
    {
        if (character)
        {
            visaNameText.text = character.visaName;
            visaOriginText.text = character.visaPlanetOfOrigin.planetData.planetName;
            visaDestinationText.text = character.visaDestination.planetData.planetName;
            visaDurationText.text = character.stayDuration.ToString() + " Weeks";
            visaTypeText.text = character.visaType.ToString();
        }

    }
    void ResetText()
    {
        visaNameText.text = null;
        visaOriginText.text = null;
        visaDestinationText.text = null;
        visaDurationText.text = null;
        visaTypeText.text = null;
    }
}
    