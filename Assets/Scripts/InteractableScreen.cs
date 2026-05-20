using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScreen : MonoBehaviour
{
    [SerializeField] private GameObject _officeMap;
    [SerializeField] private GameObject _policeSMap;
    [SerializeField] private GameObject _parkingMap;
    [SerializeField] private GameObject _roomMap;

    private GameManager _gameManager;
    private MapManager _mapManager;

    private void Start()
    {
        ClearScreens();
        _mapManager = MapManager.Get();

        _mapManager.MapChanged += OpenInteractable;

    }

    private void OpenInteractable(MapManager.Map map)
    {
        if (_officeMap != null)
        {
            _officeMap.gameObject.SetActive(map == MapManager.Map.Office);
        }
        if (_policeSMap != null)
        {
            _policeSMap.gameObject.SetActive(map == MapManager.Map.PoliceStation);
        }
    }

    private void ClearScreens()
    {
        _officeMap.gameObject.SetActive(false);
        _policeSMap.gameObject.SetActive(false);
        _parkingMap.gameObject.SetActive(false);
        _roomMap.gameObject.SetActive(false);
    }
}
