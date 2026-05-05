using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionsButtons : MonoBehaviour
{
    private Button button;
    [SerializeField] private bool correctAnswer;
    [SerializeField] private Dialogue dialogueAnswer;
    [SerializeField] private string keyInfo;

    private void Start()
    {
        button = GetComponent<Button>();        
    }

    public bool IsCorrect()
    {
        return correctAnswer;
    }

    public Dialogue dialogueSelected()
    {
        return dialogueAnswer;
    }

    public string Clue()
    {
        return keyInfo;
    }

}
