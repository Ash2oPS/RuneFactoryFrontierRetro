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
    private TextMeshProUGUI tmpSeed;

    [SerializeField]
    [Header("Inventory")]
    private int _gold;

    [SerializeField]
    private int _seed;

    #endregion PrivateVaribables

    #region GettersAndSetters

	public int Gold { get => _gold; }
    public int Seed { get => _seed; }

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

    public void AddSeed(int value)
    {
        _seed += value;
        UiUpdate();
    }

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
        tmpGold.text = "GOLD : " + Gold.ToString("0000000");
        tmpSeed.text = "SEED : " + Seed.ToString("0000000");
    }

    #endregion Functions
}
