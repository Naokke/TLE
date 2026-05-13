using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionManager : Singleton<DialogueOptionManager>
{
    [SerializeField] private Button AOption;
    [SerializeField] private Button BOption;

    [SerializeField] private TMP_Text textOptionA;
    [SerializeField] private TMP_Text textOptionB;

    private DialogueOptions currentOptions;

    private void Start()
    {
        // ACTIVATION IN: GameManager Script
        this.gameObject.SetActive(false); //Set GameObject Invisible, to use just when needed.

    }

    public void SetUpOptions(DialogueOptions options)
    {
        currentOptions = options;
        textOptionA.text = currentOptions.textOptionA;
        textOptionB.text = currentOptions.textOptionB;

        AOption.onClick.RemoveAllListeners();
        BOption.onClick.RemoveAllListeners();

        AOption.onClick.AddListener(() => 
        {
            CheckAnswer(
            currentOptions._isACorrect,
            currentOptions.dialogueAnswerA,
            currentOptions.keyInfoA); 
        });

        BOption.onClick.AddListener(() =>
        {
            CheckAnswer(
            currentOptions._isBCorrect,
            currentOptions.dialogueAnswerB,
            currentOptions.keyInfoB);
        });
    }

    private void CheckAnswer(
        bool Answer, Dialogue dialogueAnswer, string clue)
    {
        GameManager.Get().GetClue(clue,Answer);
        if (currentOptions._isGeneric)
        {
            GameManager.Get().ActiveDialogue(currentOptions.dialogueAnswerGeneric,true);
        }else
        {
            GameManager.Get().ActiveDialogue(dialogueAnswer, true);
        }            
        this.gameObject.SetActive(false);
    }
}
