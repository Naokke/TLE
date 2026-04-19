using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInteractable : MonoBehaviour
{
    private Button button;
    private PhonePasswordMinigame minigame;
    [SerializeField] private int buttonValue;
             
    private void Start()
    {
        button = GetComponent<Button>();
        minigame = GetComponentInParent<PhonePasswordMinigame>();
        button.onClick.AddListener(OnButtonClicked);
    }
    private void OnButtonClicked()
    {
        Debug.Log($"Se ha presionado: {buttonValue}");
        minigame.buttonPasswordPressed(buttonValue);
    }

}
