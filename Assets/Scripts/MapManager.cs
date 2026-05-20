using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private Button buttonOffice;
    [SerializeField] private Button buttonPoliceStation;
    [SerializeField] private Button buttonParking;
    [SerializeField] private Button buttonVictimRoom;

    [SerializeField] private Button QuitMap;

    public enum Map
    {
        None, Office, PoliceStation, Parking, VictimRoom
    }

    [SerializeField] private Map _currentMap;

    public Map CurrentMap
    {
        get => _currentMap;
        private set
        {
            if (_currentMap != value)
            {
                _currentMap = value;
            }
        }
    }

    public event Action<Map> MapChanged;

    private void Start()
    {
        this.gameObject.SetActive(false);
        ClearPoints();
        
        buttonOffice.onClick.AddListener(GoToOffice);
        buttonPoliceStation.onClick.AddListener(GoToPS);
        buttonParking.onClick.AddListener(GoToParking);
        buttonVictimRoom.onClick.AddListener(GoToRoom);

        QuitMap.onClick.AddListener(GameManager.Get().OpenMap);
    }



    public void CurrentOptions(GameManager.Levels level)
    {
        buttonOffice.gameObject.SetActive(true);
        buttonPoliceStation.gameObject.SetActive(true);
        buttonParking.gameObject.SetActive(level == GameManager.Levels.Level1);
        buttonVictimRoom.gameObject.SetActive(level == GameManager.Levels.Level2);        
    }

    #region Go To
    private void GoToOffice()
    {
        CurrentMap = Map.Office;
        GameManager.Get().OpenMap();
        MapChanged?.Invoke(CurrentMap);

    }

    private void GoToRoom()
    {
        CurrentMap = Map.VictimRoom;
        GameManager.Get().OpenMap();
        MapChanged?.Invoke(CurrentMap);
    }

    private void GoToParking()
    {
        CurrentMap = Map.Parking;
        GameManager.Get().OpenMap();
        MapChanged?.Invoke(CurrentMap);
    }

    private void GoToPS()
    {
        CurrentMap = Map.PoliceStation;
        GameManager.Get().OpenMap();
        MapChanged?.Invoke(CurrentMap);
    }
    #endregion

    private void ClearPoints()
    {
        buttonOffice.gameObject.SetActive(false);
        buttonPoliceStation.gameObject.SetActive(false);
        buttonParking.gameObject.SetActive(false);
        buttonVictimRoom.gameObject.SetActive(false);
    }
}
