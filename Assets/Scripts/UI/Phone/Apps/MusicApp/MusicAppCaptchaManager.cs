using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MusicAppCaptchaManager : MonoBehaviour
{
    [SerializeField] private Button buttonContinue;

    [SerializeField] private List<Toggle> OrangeToggles;
    [SerializeField] private List<Toggle> OthersToggles;

    private bool _isOrangeOn = false;
    private bool _isOthersOff = false;
    

    private void Start()
    {
        buttonContinue.onClick.AddListener(CheckCaptcha);
    }

    private void CheckCaptcha()
    {
        bool checkOranges = true;
        foreach (Toggle toggle in OrangeToggles)
        {
            if (!toggle.isOn)
            {
                checkOranges = false;
            }
        }

        bool checkOthers = true;
        foreach (Toggle toggle in OthersToggles)
        {
            if (toggle.isOn)
            {
                checkOthers = false;
            }
        }

        _isOrangeOn = checkOranges;
        _isOthersOff = checkOthers;

        if (_isOrangeOn && _isOthersOff)
        {
            PhoneAppManager.Get().CaptChaSuccess(true);
        }

    }
}
