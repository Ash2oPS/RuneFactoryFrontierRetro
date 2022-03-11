using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldsManager : MonoBehaviour
{
    #region PrivateVariables

    private PlayerManager _pm;
    private TimeManager _tm;

    private List<FieldTile> _allFieldTiles;

    #endregion PrivateVaribables

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

        Debug.LogWarning("Demander à Louis comment faire pour que la liste de tous les FieldTile soit créée avant le Start et pareil pour que chaque FieldTile possède PlayerManager");

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
