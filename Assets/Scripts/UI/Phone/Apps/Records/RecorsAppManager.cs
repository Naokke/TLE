using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecorsAppManager : MonoBehaviour
{
    [SerializeField] private Button buttonLockedRecords;
    [SerializeField] private Button buttonCheckTryUnlcokRecords;
    [SerializeField] private GameObject passwordScreen;
    [SerializeField] private GameObject recordsScreen;
    [SerializeField] private TMP_InputField inputFieldPassoword;
    [SerializeField] private List<GameObject> privateRecords;

    private string password = "DoReLa3";

    private void Start()
    {
        buttonLockedRecords.onClick.AddListener(TryUnlock);
        buttonCheckTryUnlcokRecords.onClick.AddListener(CheckPassword);
        passwordScreen.gameObject.SetActive(false);

        foreach (GameObject record in privateRecords)
        {
            record.gameObject.SetActive(false);
        }
    }

    private void CheckPassword()
    {
        if (inputFieldPassoword.text == password)
        {
            foreach (GameObject record in privateRecords)
            {
                record.gameObject.SetActive(true);
            }
            buttonLockedRecords.gameObject.SetActive(false);

            buttonLockedRecords.onClick.RemoveListener(TryUnlock);
            buttonCheckTryUnlcokRecords.onClick.RemoveListener(CheckPassword);
            
            TryUnlock();
        }
    }

    private void TryUnlock()
    {
        bool isPasswordActive = passwordScreen.activeSelf;

        passwordScreen.SetActive(!isPasswordActive);
        recordsScreen.SetActive(isPasswordActive);
    }



}
