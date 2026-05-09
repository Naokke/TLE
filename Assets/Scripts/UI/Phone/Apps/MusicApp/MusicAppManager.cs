using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAppManager : MonoBehaviour
{
    [SerializeField] Button buttonFavSongs;
    [SerializeField] Button buttonTendenciesSongs;
    [SerializeField] Button buttonChatSongs;

    [SerializeField] List<GameObject> MusicAppScreens;


    private void Start()
    {
        buttonFavSongs.onClick.AddListener(() => ActiveMusicAppScreen(0));
        buttonTendenciesSongs.onClick.AddListener(() => ActiveMusicAppScreen(1));
        buttonChatSongs.onClick.AddListener(() => ActiveMusicAppScreen(2));

        ActiveMusicAppScreen(0);
    }

    private void ActiveMusicAppScreen(int selected)
    {
        ClearScreens();
        MusicAppScreens[selected].gameObject.SetActive(true);
    }

    private void ClearScreens()
    {
        foreach (var screen in MusicAppScreens)
        {
            screen.gameObject.SetActive(false);
        }
    }

}
