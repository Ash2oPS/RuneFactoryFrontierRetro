using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldsManager : MonoBehaviour
{
    #region PrivateVariables

    private PlayerManager _pm;
    private TimeManager _tm;

    private List<FieldTile> _allFieldTiles;

    #endregion PrivateVariables

    #region GettersAndSetters

    public List<FieldTile> AllFieldTiles { get => _allFieldTiles; set => _allFieldTiles = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Awake()
    {
        _pm = GetComponent<PlayerManager>();
        _tm = GetComponent<TimeManager>();
    }

    private void Start()
    {
        AllFieldTiles = new List<FieldTile>();

        FieldTile[] allFieldTilesArray = FindObjectsOfType<FieldTile>();
        if (allFieldTilesArray.Length > 0)
        {
            for (int i = 0; i < allFieldTilesArray.Length; i++)
            {
                AllFieldTiles.Add(allFieldTilesArray[i]);
            }
        }
    }

    private void Update()
    {
    }

    #endregion InheritedFunctions

    #region Functions

    // YOUR NEW FUNCTIONS

    #endregion Functions
}