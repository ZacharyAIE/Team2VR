using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using CharacterComparison;

public class ShipInformationUI : MonoBehaviour
{
    public Ship ship;
    public CharacterInstanceData character;

    [Header("Images")]
    public Image shipImage;
    public Image planetNavImage;
    public Image cargoImage;

    [Header("Panels")]
    public Image navigationPanel;
    public Image cargoPanel;

    [Header("Ship Data")]
    public TMP_Text regoText;
    public TMP_Text shipNameText;
    public TMP_Text shipOwnerText;
    public TMP_Text shipClassText;

    [Header("Ship Destination Data")]
    public TMP_Text shipDestinationText;
    public TMP_Text planetDesignationText;
    public TMP_Text planetStatusText;

    public Button navButton;
    public Button cargoButton;

    [Header("Cargo")]
    public TMP_Text shipCargoListText;

    public UnityEvent shipChanged;

    [ContextMenu("Set Ship")]
    public void SetShip(Ship s, CharacterInstanceData c)
    {
        ship = s;
        character = c;
        ResetText();
        shipChanged.Invoke();
    }
    private void Start()
    {
        navButton.onClick.AddListener(()=>EnableNav());
        cargoButton.onClick.AddListener(()=>EnableCargo());
    }

    void ResetText()
    {
        regoText.text = null;
        shipNameText.text = null;
        shipOwnerText.text = null;
        shipClassText.text = null;
        shipDestinationText.text = null;
        planetDesignationText.text = null;
        planetStatusText.text = null;
    }

    void EnableCargo()
    {
        if(navigationPanel.gameObject.activeSelf)
            navigationPanel.gameObject.SetActive(false);
        cargoPanel.gameObject.SetActive(true);
    }
    void EnableNav()
    {
        if (cargoPanel.gameObject.activeSelf)
            cargoPanel.gameObject.SetActive(false);
        navigationPanel.gameObject.SetActive(true);
    }

    [ContextMenu("Fill")]
    public void FillShipInfo()
    {
        regoText.text = ship.shipID;
        shipNameText.text = ship.shipName;
        shipOwnerText.text = character.shipOwnerName;
        shipClassText.text = ship.shipType._shipType.ToString();
        shipDestinationText.text = character.shipDestination.planetData.planetName;
        planetDesignationText.text = character.shipDestination.planetData.designation;
        planetStatusText.text = character.shipDestination.planetData.societalStatus;
        foreach(CargoItem c in ship.cargoItems)
        {
            shipCargoListText.text = shipCargoListText.text + c.name +"\n";
        }
    }
}
