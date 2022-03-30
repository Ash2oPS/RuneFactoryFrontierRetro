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
    private string _playerName;

    [SerializeField]
    private Level _playerLevel;

    [SerializeField]
    private int _maxHp, _hp, _maxRp, _rp, _atk, _mag, _def, _magDef, _firePower, _waterPower, _earthPower, _windPower, _lightPower, _darknessPower;

    [SerializeField]
    private List<Level> _skillLevels;

    [SerializeField]
    [Header("Inventory")]
    private int _gold;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI _tmpGold;

    private bool _isMenuOpened;

    #endregion PrivateVariables

    #region GettersAndSetters

    public string PlayerName { get => _playerName; }
    public int MaxHp { get => _maxHp; }
    public int Hp { get => _hp; }
    public int MaxRp { get => _maxRp; }
    public int Rp { get => _rp; }
    public int Atk { get => _atk; }
    public int Mag { get => _mag; }

    public int Gold { get => _gold; }

    public bool IsMenuOpened { get => _isMenuOpened; }

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
        Debug.LogWarning("Demander à Louis si y a pas moyen de faire rapidement tous les getters");
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

    #endregion Functions
}