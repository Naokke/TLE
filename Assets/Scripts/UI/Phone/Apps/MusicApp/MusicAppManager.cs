using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class MusicAppManager : MonoBehaviour
{
    [Header("Buttons to Screens")]
    [SerializeField] private Button buttonFavSongs;
    [SerializeField] private Button buttonTendenciesSongs;
    [SerializeField] private Button buttonChatSongs;

    [Header("Screeens")]
    [SerializeField] private List<GameObject> MusicAppScreens;

    [Header("Chat Buttons")]
    [SerializeField] private Button buttonChatDamian;
    [SerializeField] private Button buttonChatReceba;

    [Header("Chat Screen")]
    [SerializeField] private GameObject chatScreen;

    [Header("Chat Utilities")]
    [SerializeField] private Button buttonBack;
    [SerializeField] private Image imageProfileChat;
    [SerializeField] private TMP_Text textNameChat;
    [SerializeField] private Image imageChatText;

    [Header("Resources")]
    [SerializeField] private Sprite chatDamian;
    [SerializeField] private Sprite chatRebeca;
    [SerializeField] private Sprite profileDamian;
    [SerializeField] private Sprite profileRebeca;


    private void Start()
    {
        buttonFavSongs.onClick.AddListener(() => ActiveMusicAppScreen(0));
        buttonTendenciesSongs.onClick.AddListener(() => ActiveMusicAppScreen(1));
        buttonChatSongs.onClick.AddListener(() => ActiveMusicAppScreen(2));

        buttonChatDamian.onClick.AddListener(() => OpenChat(0));
        buttonChatReceba.onClick.AddListener(() => OpenChat(1));

        buttonBack.onClick.AddListener(() => ActiveMusicAppScreen(2));

        ActiveMusicAppScreen(0);
    }

    private void OpenChat(int selected)
    {
        ClearScreens();
        chatScreen.gameObject.SetActive(true);
        switch (selected)
        {
            case 0:
                imageProfileChat.sprite = profileDamian;
                imageChatText.sprite = chatDamian;
                textNameChat.text = "Damián";
                break;
            case 1:
                imageProfileChat.sprite = profileRebeca;
                imageChatText.sprite = chatRebeca;
                textNameChat.text = "Rebeca";
                break;
        }
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
        chatScreen.gameObject.SetActive(false);
    }

}
