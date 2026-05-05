using System;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    private Button button;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private bool interfaceDeployer;
    [SerializeField] private string interfaceName;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() //Different functions for the same button scrip
    {
        if (!interfaceDeployer)
        {
            Debug.Log("To Dialogue - Clicked successfully");
            GameManager.Get().ActiveDialogue(dialogue, true);
            button.interactable = false;
        }
        else
        {
            Debug.Log("To Interface - Clicked successfully");
            switch (interfaceName.ToUpper())
            {
                case "PHONE":
                    //If Password is already DONE, just Activate the phone Canva
                    GameManager.Get().ActivePhone(GameManager.Get().IsPasswordSuccess);
                    Debug.Log("Finished PhoneInterface");

                    //If password is NOT DONE YET, activate the minigame Canva
                    GameManager.Get().ActivePasswordMinigame(!GameManager.Get().IsPasswordSuccess);
                    break;
            }            
        }
    }
}
