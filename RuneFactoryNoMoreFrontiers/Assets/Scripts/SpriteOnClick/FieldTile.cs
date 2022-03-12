using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTile : SpriteOnClick
{
    #region PrivateVariables

    private PlayerManager _pm;

    private bool _isWatered, _isHoed, _isHarvested, _isReadyToBeGathered, isDried;
    private int _daysToBeGathered, _daysSinceHarvested, _daySinceNotWatered;

    #endregion PrivateVariables

    #region GettersAndSetters

    public bool IsWatered { get => _isWatered; set => _isWatered = value; }
    public bool IsHoed { get => _isHoed; set => _isHoed = value; }
    public bool IsHarvested { get => _isHarvested; set => _isHarvested = value; }
    public bool IsReadyToBeGathered { get => _isReadyToBeGathered; set => _isReadyToBeGathered = value; }
    public bool IsDried { get => isDried; set => isDried = value; }
    public int DaysToBeGathered { get => _daysToBeGathered; set => _daysToBeGathered = value; }
    public int DaysSinceHarvested { get => _daysSinceHarvested; set => _daysSinceHarvested = value; }
    public int DaySinceNotWatered { get => _daySinceNotWatered; set => _daySinceNotWatered = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Awake()
    {
        _pm = FindObjectOfType<PlayerManager>();
    }

    protected override void Interact()
    {
        if (isDried)
        {
            CutTile();
        }
        else if (IsReadyToBeGathered)
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

    private void SetToDried(bool value)
    {
        IsDried = value;
        if (value)
        {
            ChangeSpriteColor(-0.6f, -0.6f, -0.6f, 0);
        }
        else
        {
            ChangeSpriteColor(0.6f, 0.6f, 0.6f, 0);
        }
    }

    private void SetToHarvested(bool value)
    {
        IsHarvested = value;
        if (value)
        {
            ChangeSpriteColor(0, 0.2f, 0, 0);
        }
        else
        {
            ChangeSpriteColor(0, -0.2f, 0, 0);
        }
    }

    private void SetToReadyToBeGathered(bool value)
    {
        IsReadyToBeGathered = value;
        if (value)
        {
            ChangeSpriteColor(0.2f, 0.2f, 0.2f, 0);
            DisplayInformation("Ready to be gathered !", Color.cyan);
        }
        else
        {
            ChangeSpriteColor(-0.2f, -0.2f, -0.2f, 0);
        }
    }

    private void SetToWatered(bool value)
    {
        IsWatered = value;
        if (value)
        {
            ChangeSpriteColor(0, 0, 0.2f, 0);
        }
        else
        {
            ChangeSpriteColor(0, 0, -0.2f, 0);
        }
    }

    private void SetToHoed(bool value)
    {
        IsHoed = value;
        if (value)
        {
            ChangeSpriteColor(0.2f, 0, 0, 0);
        }
        else
        {
            ChangeSpriteColor(-0.2f, 0, 0, 0);
        }
    }

    private void CutTile()
    {
        SetToDried(false);
        SetToHarvested(false);

        DisplayInformation("Cut", Color.red);
    }

    private void GatherTile()
    {
        SetToReadyToBeGathered(false);
        SetToHarvested(false);

        DisplayInformation("Harvested successfully.\nIsReadyToBeGathered =" + IsReadyToBeGathered + "\nIsHarvested = " + IsHarvested, Color.green);

        _pm.AddGold(100);
    }

    private void WaterTile()
    {
        SetToWatered(true);

        DaySinceNotWatered = 0;

        DisplayInformation("Watered", Color.blue);
    }

    private void HarvestTile()
    {
        if (_pm.Seed > 0)
        {
            _pm.AddSeed(-1);

            SetToHarvested(true);

            DisplayInformation("Harvested", Color.yellow);
        }
        else
        {
            DisplayInformation("No more seeds :(", Color.red);
        }
    }

    private void HoeTile()
    {
        SetToHoed(true);

        DisplayInformation("Hoed", Color.gray);
    }

    private void DryTile()
    {
        SetToDried(true);
        if (IsReadyToBeGathered)
        {
            SetToReadyToBeGathered(false);
        }

        DisplayInformation("Dried :(", Color.black);
    }

    public void NextDayTile()
    {
        if (!IsDried)
        {
            if (IsWatered)
            {
                SetToWatered(false);
                if (DaysSinceHarvested < DaysToBeGathered)
                {
                    DaysSinceHarvested++;
                }
                else
                {
                    SetToReadyToBeGathered(true);
                }
            }
            else if (IsHarvested)
            {
                if (DaySinceNotWatered < 1)
                {
                    DaySinceNotWatered++;
                }
                else
                {
                    DaySinceNotWatered = 0;
                    DaysSinceHarvested = 0;
                    DryTile();
                }
            }
        }
    }

    #endregion Functions
}