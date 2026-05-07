using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneAppManager : Singleton<PhoneAppManager>
{
    [SerializeField] private Button homeButton;
    private int currentApp;

    [SerializeField] private List<AppsInteactable> apps;
    [SerializeField] private List<GameObject> screens;

    private void Start()
    {
        homeButton.onClick.AddListener(HomeScreen);

        this.gameObject.SetActive(false);
    }

    private void ClearScreen()
    {
        foreach (var appScreen in screens)
        {
            appScreen.gameObject.SetActive(false);
        }
    }

    public void ActiveApp(int appIndex)
    {        
        if (appIndex >= 0 && appIndex < apps.Count)
        {
            ClearScreen();
            screens[appIndex].gameObject.SetActive(true);
            currentApp = appIndex;
        }
    }

    public void HomeScreen()
    {
        ActiveApp(0);
    }

}
