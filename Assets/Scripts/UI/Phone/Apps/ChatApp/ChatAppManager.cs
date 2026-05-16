using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatAppManager : MonoBehaviour
{
    [SerializeField] private Button butttonChat;
    [SerializeField] private GameObject chatScreen;
    [SerializeField] private Image scrollableChat;
    [SerializeField] private Button exitChat;
    [SerializeField] private List<Sprite> chatsPre;
    [SerializeField] private List<Sprite> chatsPost;

    private bool _isOpen = false;

    private void Start()
    {        
        chatScreen.gameObject.SetActive(false);
        exitChat.onClick.AddListener(CloseChat);
    }

    private void CloseChat()
    {
        _isOpen = false;
        chatScreen.gameObject.SetActive(_isOpen);
    }

    public void OpenChat(int chat)
    {
        _isOpen = !_isOpen;
        chatScreen.SetActive(_isOpen);

        if (!GameManager.Get()._isPhoneUpdate)
        {
            scrollableChat.sprite = chatsPre[chat];
        }
        if (GameManager.Get()._isPhoneUpdate)
        {
            scrollableChat.sprite = chatsPost[chat];
        }        
    }
}   
