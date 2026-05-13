using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatAppManager : MonoBehaviour
{
    [SerializeField] Button butttonChat;
    [SerializeField] GameObject chatScreen;
    [SerializeField] Sprite ExampleChat;

    private bool _isOpen = false;

    private void Start()
    {
        chatScreen.gameObject.SetActive(false);

        butttonChat.onClick.AddListener(OpenChat);
    }

    private void OpenChat()
    {
        _isOpen = !_isOpen;
        chatScreen.SetActive(_isOpen);
    }
}   
