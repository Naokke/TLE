using System;
using UnityEngine;
using UnityEngine.UI;

public class ExampleButton : MonoBehaviour
{
    private Button button;
    [SerializeField] private Dialogue dialogue;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Debug.Log("Clicked successfully");
        GameManager.Get().ActiveDialogue(dialogue,true);
    }
}
