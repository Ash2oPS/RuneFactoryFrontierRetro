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

    private bool _isWatered;
    private FieldTileState _state;
    private int _daysToBeGathered, _daysSinceHarvested, _daySinceNotWatered;
    private Seed _harvestedSeed;
    private InventoryManager _im;

    #endregion PrivateVariables

    #region GettersAndSetters

    public bool IsWatered { get => _isWatered; set => _isWatered = value; }
    public FieldTileState State { get => _state; }
    public int DaysToBeGathered { get => _daysToBeGathered; set => _daysToBeGathered = value; }
    public int DaysSinceHarvested { get => _daysSinceHarvested; set => _daysSinceHarvested = value; }
    public int DaySinceNotWatered { get => _daySinceNotWatered; set => _daySinceNotWatered = value; }
    public Seed HarvestedSeed { get => _harvestedSeed; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    protected override void Start()
    {
        base.Start();
        _im = FindObjectOfType<InventoryManager>();
    }

    protected override void Interact()
    {
        if (State == FieldTileState.readyToBeGathered)
        {
            EmptyTile();
        }
    }

    #endregion InheritedFunctions

    #region Functions

    private void EmptyTile()
    {
        _state = FieldTileState.empty;
        R = 0.8490566f;
        G = 0.6567275f;
        B = 0.4685831f;
        A = 1;

        _im.ModifyInventory(_harvestedSeed.correspondingHarvest, 1);

        _harvestedSeed = null;
        _daySinceNotWatered = 0;
        _daysSinceHarvested = 0;
    }

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

    private void SetToHarvested(bool value, Seed seedHarvested)
    {
        if (value)
        {
            ChangeSpriteColor(0, 0.2f, 0, 0);
            _state = FieldTileState.harvested;
            _harvestedSeed = seedHarvested;
            _im.ModifyInventory(seedHarvested, -1);
            _daysToBeGathered = _harvestedSeed.daysToHarvest;
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

    public void CutTile()
    {
        SetToDried(false);
        SetToHarvested(false, null);

        _state = FieldTileState.hoed;

        DisplayInformation("Cut", Color.red);
    }

    public void GatherTile()
    {
        SetToReadyToBeGathered(false);
        SetToHarvested(false, null);

        _state = FieldTileState.hoed;

        DisplayInformation("Harvested successfully", Color.green);

        _pm.AddGold(100);
    }

    public void WaterTile()
    {
        SetToWatered(true);

        DaySinceNotWatered = 0;

        DisplayInformation("Watered", Color.blue);
    }

    public void HarvestTile(Seed seedHarvested)
    {
        SetToHarvested(true, seedHarvested);

        DisplayInformation("Harvested", Color.yellow);
    }

    public void HoeTile()
    {
        SetToHoed(true);

        DisplayInformation("Hoed", Color.gray);
    }

    public void DryTile()
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