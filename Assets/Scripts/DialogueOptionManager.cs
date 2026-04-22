using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionManager : MonoBehaviour
{
    [SerializeField] private Button AOption;
    [SerializeField] private Button BOption;

    private DialogueOptionsButtons optionAData;
    private DialogueOptionsButtons optionBData;

    private void Start()
    {
        // ACTIVATION IN: GameManager Script
        this.gameObject.SetActive(false); //Set GameObject Invisible, to use just when needed.
        optionAData = AOption.GetComponent<DialogueOptionsButtons>();
        optionBData = BOption.GetComponent<DialogueOptionsButtons>();
                                          
    }

    private void OnEnable()
    {
        AOption.onClick.AddListener(() => CheckAnswer(
            optionAData.IsCorrect(),
            optionAData.dialogueSelected(),
            optionAData.Clue()
            ));
        BOption.onClick.AddListener(() => CheckAnswer(
            optionBData.IsCorrect(),
            optionBData.dialogueSelected(),
            optionBData.Clue()
            ));
    }

    private void CheckAnswer(bool Answer, Dialogue dialogueAnswer, string clue)
    {
        GameManager.Get().GetClue(clue,Answer);
        GameManager.Get().ActiveDialogue(dialogueAnswer, true);
        this.gameObject.SetActive(false);
    }
}
