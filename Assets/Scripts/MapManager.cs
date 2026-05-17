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

    private void Start()
    {
        this.gameObject.SetActive(false);
        ClearPoints();
        
        buttonOffice.onClick.AddListener(GoToOffice);
        buttonPoliceStation.onClick.AddListener(GoToPS);
        buttonParking.onClick.AddListener(GoToParking);
        buttonVictimRoom.onClick.AddListener(GoToRoom);
    }

    public void CurrentOptions(GameManager.Levels level)
    {
        switch (level)
        {
            case GameManager.Levels.Level1:
                //Do things
                break;
            case GameManager.Levels.Level2:
                //Do things
                break;
            case GameManager.Levels.Level3:
                //Do things
                break;
        }
    }

    #region Go To
    private void GoToOffice()
    {
        GameManager.Get().OpenMap();

    }

    private void GoToRoom()
    {
        throw new NotImplementedException();
    }

    private void GoToParking()
    {
        throw new NotImplementedException();
    }

    private void GoToPS()
    {
        throw new NotImplementedException();
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
