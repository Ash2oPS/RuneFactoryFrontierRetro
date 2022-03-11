using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTile : SpriteOnClick
{
    #region PrivateVariables

    [SerializeField]
    private DisplayInfoText _displayInfoText;

    private bool _isWatered, _isHoed, _isHarvested, _isReadyToBeGathered;

    #endregion PrivateVaribables

    #region GettersAndSetters

    public bool IsWatered { get => _isWatered; set => _isWatered = value; }
    public bool IsHoed { get => _isHoed; set => _isHoed = value; }
    public bool IsHarvested { get => _isHarvested; set => _isHarvested = value; }
    public bool IsReadyToBeGathered { get => _isReadyToBeGathered; set => _isReadyToBeGathered = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    protected override void Interact()
    {
        if (IsReadyToBeGathered)
        {
            GatherTile();
        }
        else if (!IsWatered && IsHarvested)
        {
            WaterTile();
        } 
        else if (!IsHarvested && IsHoed)
        {
            HarvestTile();
        }
        else if (!IsHoed)
        {
            HoeTile();
        }
    }

    #endregion InheritedFunctions

    #region Functions

    private void GatherTile() {
        IsReadyToBeGathered = false;
        IsHarvested = false;

        DisplayInformation("Harvested successfully.\nIsReadyToBeGathered =" + IsReadyToBeGathered + "\nIsHarvested = " + IsHarvested, Color.green);

        ChangeSpriteColor(0, -0.2f, 0, 0);
    }
    private void WaterTile() {
        IsWatered = true;

        DisplayInformation("Watered", Color.blue);

        ChangeSpriteColor(0, 0, 0.2f, 0);
    }
    private void HarvestTile() {
        IsHarvested = true;

        DisplayInformation("Harvested", Color.yellow);

        ChangeSpriteColor(0, 0.2f, 0, 0);
    }
    private void HoeTile() {
        IsHoed = true;

        DisplayInformation("Hoed", Color.gray);

        ChangeSpriteColor(0.2f, 0, 0, 0);
    }
    private void DisplayInformation(string textToDisplay, Color textColor)
    {
        DisplayInfoText dit = Instantiate(_displayInfoText, transform);

        dit.GetComponent<TextMesh>().text = textToDisplay;
        dit.GetComponent<TextMesh>().color = textColor;
    }

    #endregion Functions
}
