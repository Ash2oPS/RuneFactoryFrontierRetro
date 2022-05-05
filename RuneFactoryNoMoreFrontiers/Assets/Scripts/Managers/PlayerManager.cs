using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region PrivateVariables

    private TimeManager _tm;
    private FieldsManager _fm;
    private InventoryManager _im;

    [SerializeField]
    [Header("Player Stats")]
    private string _playerName = "Raguna";

    [SerializeField]
    private StatPreset _playerStatPreset;

    [SerializeField]
    private Stats _playerTrueStats;

    [SerializeField]
    private Level _playerLevel = new Level("Level", 1);

    [SerializeField]
    private List<Level> _skillLevels;

    [SerializeField]
    [Header("Inventory")]
    private int _gold;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI _tmpGold;

    private bool _canMove = true;

    private bool _isMenuOpened;

    #endregion PrivateVariables

    #region GettersAndSetters

    public string PlayerName { get => _playerName; }

    public Stats PlayerTrueStats { get => _playerTrueStats; }

    public List<Level> SkillLevels { get => _skillLevels; }

    public int Gold { get => _gold; }

    public bool IsMenuOpened { get => _isMenuOpened; }

    public bool CanMove { get => _canMove; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Awake()
    {
        _tm = GetComponent<TimeManager>();
        _fm = GetComponent<FieldsManager>();
        _im = GetComponent<InventoryManager>();
    }

    private void Start()
    {
        UiUpdate();
        SwitchToMenu(false);
        _playerTrueStats = _playerStatPreset.stats;
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
        Debug.Log("Player fainted :/ (gros loser)");
    }

    private void UiUpdate()
    {
        _tmpGold.text = "GOLD : " + Gold.ToString();
    }

    private void SwitchToMenu(bool value)
    {
        if (value)
        {
            _im.DisplayInventoryUI(false);
            _isMenuOpened = true;
        }
        else
        {
            _im.DisplayInventoryUI(true);
            _isMenuOpened = false;
        }
    }

    public void CallMenu()
    {
        if (_isMenuOpened)
        {
            SwitchToMenu(false);
        }
        else
        {
            SwitchToMenu(true);
        }
    }

    public void SetCanMove(bool value)
    {
        _canMove = value;
    }

    #endregion Functions
}