using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region PrivateVariables

    private TimeManager _tm;
    private FieldsManager _fm;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI tmpGold;

    [SerializeField]
    [Header("Inventory")]
    private int _gold;

    #endregion PrivateVariables

    #region GettersAndSetters

    public int Gold { get => _gold; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Awake()
    {
        _tm = GetComponent<TimeManager>();
        _fm = GetComponent<FieldsManager>();
    }

    private void Start()
    {
        UiUpdate();
    }

    private void Update()
    {
    }

    #endregion InheritedFunctions

    #region Functions

    public void AddGold(int value)
    {
        _gold += value;
        UiUpdate();
    }

    public void LateTimeFaint()
    {
        _tm.NextDay(10);

        Faint();
    }

    private void Faint()
    {
        Debug.Log("Player fainted :/ (gros looser)");
    }

    private void UiUpdate()
    {
        tmpGold.text = "GOLD : " + Gold.ToString();
    }

    #endregion Functions
}