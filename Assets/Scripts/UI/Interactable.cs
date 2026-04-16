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
        if (dialogue != null)
        {
            Debug.Log("Clicked successfully");
            GameManager.Get().ActiveDialogue(dialogue, true);
        }
        else
        {
            switch (interfaceName.ToUpper())
            {
                case "TELEFONO":
                    GameManager.Get();
                    break;
            }
        }

    }
}
