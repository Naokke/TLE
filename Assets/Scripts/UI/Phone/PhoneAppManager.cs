using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneAppManager : Singleton<PhoneAppManager>
{
    [SerializeField] private Button homeButton;
    

    [SerializeField] private List<AppsInteactable> apps;
    [SerializeField] private List<GameObject> screens;
    [SerializeField] private GameObject musicScreenHome;
    [SerializeField] private GameObject musicLogInMinigame;
    [SerializeField] private GameObject musicCaptChaMinigame;

    private bool _isMusicUnlocked = false;
    private bool _isCaptChaUnlocked = false;

    private void Start()
    {
        homeButton.onClick.AddListener(HomeScreen);

        HomeScreen();
        this.gameObject.SetActive(false);
    }

    private void ClearScreen()
    {
        musicLogInMinigame.gameObject.SetActive(false);
        musicCaptChaMinigame.gameObject.SetActive(false);
        musicScreenHome.gameObject.SetActive(false);
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
            if (appIndex == 3)
            {                
                MusicAppMinigame();                                
            }            
        }
    }

    public void LogIn(bool logIn)
    {
        _isCaptChaUnlocked = logIn;
        MusicAppMinigame();
    }

    public void CaptChaSuccess(bool Completed)
    {
        _isMusicUnlocked = Completed;
        MusicAppMinigame();
    }

    private void MusicAppMinigame()
    {
        musicScreenHome.gameObject.SetActive(_isMusicUnlocked);
        musicCaptChaMinigame.gameObject.SetActive(!_isMusicUnlocked);
        musicLogInMinigame.gameObject.SetActive(!_isCaptChaUnlocked);
    }

    public void HomeScreen()
    {
        ActiveApp(0);
    }

}
