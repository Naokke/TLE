using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAppManager : MonoBehaviour
{
    [SerializeField] private GameObject homeButton;

    [SerializeField] private List<AppsInteactable> apps;
    [SerializeField] private List<GameObject> screens;

    private void Start()
    {
        
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
        ClearScreen();
        if (appIndex >= 0 && appIndex < apps.Count)
        {
            screens[appIndex].gameObject.SetActive(true);
        }
    }

    public void HomeScreen()
    {
        ActiveApp(0);
    }

}
