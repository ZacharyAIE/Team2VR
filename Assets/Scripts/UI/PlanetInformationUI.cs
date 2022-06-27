using UnityEngine;
using UnityEngine.Events;
using TMPro;
using CharacterComparison;

/// <summary>
/// This class handles the population of the planet UI space.
/// </summary>
public class PlanetInformationUI : MonoBehaviour
{
    public Planet planetToDisplay;
    public GameObject planetModel;
    [Tooltip("The position the planet model should spawn at")]
    public Transform planetModelPosition;
    public TMP_Text planetTitleText;
    [Tooltip("The travel restrictions text box")]
    public TMP_Text travelRestrictionText;
    [Tooltip("The goods restrictions text box")]
    public TMP_Text goodsRestrictionText;
    [Tooltip("Enter any text box formatting here")]
    [Multiline(2)] public string markupFormattingText = "<indent=15%><line-indent=-15%>";
    public UnityEvent planetChanged;

    public void SetPlanet(Planet p)
    {
        planetToDisplay = p;
        if(planetModel)
            Destroy(planetModel);
        planetChanged.Invoke();
    }

    [ContextMenu("Fill")]
    public void FillPlanetInfo()
    {
        if (planetToDisplay)
        {
            if (planetToDisplay.planetData.planetModel)
                planetModel = Instantiate(planetToDisplay.planetData.planetModel, planetModelPosition);
            else
            {
                Debug.LogError("No Planet Model Assigned");
                return;
            }
            planetTitleText.text = planetToDisplay.planetData.name;

            // Populate travel restrictions
            travelRestrictionText.text = markupFormattingText;
            foreach (Restriction r in planetToDisplay.restrictions)
            {
                travelRestrictionText.text = travelRestrictionText.text + r.ToString() + "\n";
            }

            // Populate goods restrictions
            goodsRestrictionText.text = markupFormattingText;
            foreach (CargoItem c in planetToDisplay.restrictedItems)
            {
                goodsRestrictionText.text = goodsRestrictionText.text + c.itemName + "\n";
            }
        }
        else
        {
            Debug.LogWarning("Missing Planet");
        }
        
    }
}
