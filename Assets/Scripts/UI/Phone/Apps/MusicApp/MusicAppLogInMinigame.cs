using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicAppLogInMinigame : MonoBehaviour
{
    // Minigame
    [SerializeField] TMP_InputField inputUser;
    [SerializeField] TMP_InputField inputPassword;
    [SerializeField] Button buttonLogIn;

    private string username = "Lanna";
    private string password = "michito123*";


    private void Start()
    {
        buttonLogIn.onClick.AddListener(TryLogIn);
    }

    private void TryLogIn()
    {        
        PhoneAppManager.Get().LogIn(CheckLogIn());
    }

    private bool CheckLogIn()
    {
        if (username == inputUser.text && password == inputPassword.text)
        {
            return true;
        }
        return false;
    }
}
