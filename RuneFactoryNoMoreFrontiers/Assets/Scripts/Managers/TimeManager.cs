using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    #region PrivateVariables

    private PlayerManager _pm;
    private FieldsManager _fm;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI tmpDate;

    [SerializeField]
    private TextMeshProUGUI tmpTime;

    [SerializeField]
    [Header("DEBUG (Default : 1)")]
    private int _timeFactor;

    private bool _timeCanGo;

    [Header("CurrentTime")]
    [SerializeField]
    private int _year;

    [SerializeField]
    private int _season, _day, _hour, _minute;

    #endregion PrivateVariables

    #region GettersAndSetters

    public bool TimeCanGo { get => _timeCanGo; set => _timeCanGo = value; }

    public int Year { get => _year; set => _year = value; }
    public int Season { get => _season; set => _season = value; }
    public int Day { get => _day; set => _day = value; }
    public int Hour { get => _hour; set => _hour = value; }
    public int Minute { get => _minute; set => _minute = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Awake()
    {
        _pm = GetComponent<PlayerManager>();
        _fm = GetComponent<FieldsManager>();
    }

    private void Start()
    {
        SetTimeCanGo(true);
    }

    #endregion InheritedFunctions

    #region Functions

    public void NextDay(int hourToWakeUp)
    {
        if (Hour > 5)
        {
            Day++;
        }

        if (Day == 1)
        {
            SeasonChanger();
        }

        if (_fm.AllFieldTiles.Count > 0)
        {
            for (int i = 0; i < _fm.AllFieldTiles.Count; i++)
            {
                _fm.AllFieldTiles[i].NextDayTile();
            }
        }

        Hour = hourToWakeUp;
        Minute = 0;

        CorrectTimeChecker();

        ClockUpdate();
    }

    public void SetTimeCanGo(bool value)
    {
        TimeCanGo = value;

        if (value)
        {
            StartCoroutine(TimeTick());
        }
    }

    private IEnumerator TimeTick()
    {
        while (TimeCanGo)
        {
            ClockUpdate();

            yield return new WaitForSeconds(1 / _timeFactor);

            Minute++;

            CorrectTimeChecker();

            LateTimeFaintChecker();
        }
    }

    private void CorrectTimeChecker()
    {
        if (Minute > 59)
        {
            Hour++;
            Minute = 0;
        }
        if (Hour > 23)
        {
            Hour = 0;
            Day++;
        }
        if (Day > 28)
        {
            Season++;
            Day = 1;
        }

        if (Season > 4)
        {
            Year++;
            Season = 1;
        }
    }

    private void ClockUpdate()
    {
        tmpDate.text = "Year : " + Year.ToString("00") + " - Season : " + Season.ToString() + " - Day : " + Day.ToString("00");
        tmpTime.text = Hour.ToString("00") + " : " + Minute.ToString("00");
    }

    private void LateTimeFaintChecker()
    {
        if (Hour > 2 && Hour < 6)
        {
            _pm.LateTimeFaint();
        }
    }

    private void SeasonChanger()
    {
        Debug.Log("Hop là on a changé de saison !");
    }

    #endregion Functions
}