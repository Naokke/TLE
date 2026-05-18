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
        ClearPoints();
        switch (level)
        {
            case GameManager.Levels.Level1:
                buttonOffice.gameObject.SetActive(true);
                buttonParking.gameObject.SetActive(true);
                buttonPoliceStation.gameObject.SetActive(true);                
                break;

            case GameManager.Levels.Level2:
                buttonOffice.gameObject.SetActive(true);
                buttonPoliceStation.gameObject.SetActive(true);
                buttonVictimRoom.gameObject.SetActive(true);
                break;

            case GameManager.Levels.Level3:
                buttonPoliceStation.gameObject.SetActive(true);
                buttonOffice.gameObject.SetActive(true);
                break;

            case GameManager.Levels.Level4:
                buttonOffice.gameObject.SetActive(true);
                buttonPoliceStation.gameObject.SetActive(true);
                break;
        }
    }

    #region Go To
    private void GoToOffice()
    {
        CurrentMap = Map.Office;
        GameManager.Get().OpenMap();

    }

    private void GoToRoom()
    {
        CurrentMap = Map.VictimRoom;
        GameManager.Get().OpenMap();
    }

    private void GoToParking()
    {
        CurrentMap = Map.Parking;
        GameManager.Get().OpenMap();
     }

    private void GoToPS()
    {
        CurrentMap = Map.PoliceStation;
        GameManager.Get().OpenMap();
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
