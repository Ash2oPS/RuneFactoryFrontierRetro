using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FieldTileState
{
    empty, hoed, harvested, readyToBeGathered, dried
}

public class FieldTile : SpriteOnClick
{
    #region PrivateVariables

    private PlayerManager _pm;

    private bool _isWatered;
    private FieldTileState _state;
    private int _daysToBeGathered, _daysSinceHarvested, _daySinceNotWatered;

    #endregion PrivateVariables

    #region GettersAndSetters

    public bool IsWatered { get => _isWatered; set => _isWatered = value; }
    public FieldTileState State { get => _state; }
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
        switch (_state)
        {
            case FieldTileState.dried:
                CutTile();
                break;

            case FieldTileState.readyToBeGathered:
                GatherTile();
                break;

            case FieldTileState.harvested:
                if (!_isWatered)
                {
                    WaterTile();
                }
                break;

            case FieldTileState.hoed:
                HarvestTile();
                break;

            case FieldTileState.empty:
                HoeTile();
                break;
        }
    }

    #endregion InheritedFunctions

    #region Functions

    private void SetToDried(bool value)
    {
        if (value)
        {
            ChangeSpriteColor(-0.6f, -0.6f, -0.6f, 0);
            _state = FieldTileState.dried;
        }
        else
        {
            ChangeSpriteColor(0.6f, 0.6f, 0.6f, 0);
        }
    }

    private void SetToHarvested(bool value)
    {
        if (value)
        {
            ChangeSpriteColor(0, 0.2f, 0, 0);
            _state = FieldTileState.harvested;
        }
        else
        {
            ChangeSpriteColor(0, -0.2f, 0, 0);
        }
    }

    private void SetToReadyToBeGathered(bool value)
    {
        if (value)
        {
            ChangeSpriteColor(0.2f, 0.2f, 0.2f, 0);
            DisplayInformation("Ready to be gathered !", Color.cyan);
            _state = FieldTileState.readyToBeGathered;
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
        if (value)
        {
            ChangeSpriteColor(0.2f, 0, 0, 0);
            _state = FieldTileState.hoed;
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

        _state = FieldTileState.hoed;

        DisplayInformation("Cut", Color.red);
    }

    private void GatherTile()
    {
        SetToReadyToBeGathered(false);
        SetToHarvested(false);

        _state = FieldTileState.hoed;

        DisplayInformation("Harvested successfully", Color.green);

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
        SetToHarvested(true);

        DisplayInformation("Harvested", Color.yellow);
    }

    private void HoeTile()
    {
        SetToHoed(true);

        DisplayInformation("Hoed", Color.gray);
    }

    private void DryTile()
    {
        SetToDried(true);
        if (_state == FieldTileState.readyToBeGathered)
        {
            SetToReadyToBeGathered(false);
        }

        DisplayInformation("Dried :(", Color.black);
    }

    public void NextDayTile()
    {
        if (_state != FieldTileState.dried)
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
            else if (_state == FieldTileState.harvested)
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