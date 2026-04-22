using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    #region Starting variables and objects
    
    //Info boxes
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueNameLeft;
    [SerializeField] private TextMeshProUGUI dialogueNameRight;

    //Sprites Speakers
    [SerializeField] private Image dialogueSpeakerLeft;
    [SerializeField] private Image dialogueSpeakerRight;
    [SerializeField] private Speakers defaultSpeaker;
    
    //color info boxes
    [SerializeField] private Image boxNameLeft;
    [SerializeField] private Image boxNameRight;

    //SentenceIndex -1 to avoid errors and start dialogues at click
    private int sentenceIndex = -1;

    //Current Dialogue
    [SerializeField] private Dialogue currentDialogue;
    [SerializeField] private Dialogue defaultDialogue;

    //initial state finished to avoid errors
    private State state = State.finished;

    #endregion

    #region States

    private enum State
    {
        playing, //active when in middle of a sentence
        finished //after finishing a sentence
    }

    #endregion

    #region Start and Update

    private void Start()
    {
        // ACTIVATION IN: GameManager Script
        this.gameObject.SetActive(false); //Set GameObject Invisible, to use just when needed. 
    }

    private void Update()
    {
        //When a sentence is finished, allow to see the next one
        NextSentence();
        ClosePopUp(); //Close the PopUp Dialogue window
    }

    #endregion

    #region Dialogue Functions

    //Function to start dialogue
    public void PlayDialogue(Dialogue clickedDialogue)
    {
        currentDialogue = clickedDialogue; // Set the new Dialogue
        sentenceIndex = -1; // To reset the SetneceIndex of the past Dialogue
        ClearCharacters(); // To reset the characters sprites of the past Dialogue
        PlaySentence(); 
    }

    private void NextSentence() //When a sentence is finished, allow to see the next one
    {
        if (state == State.finished)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Use Space or click to advance
            {
                //Play the next sentence
                PlaySentence();
            }
        }
    }

    // Play the "next" sentence (Always start sentence at -1 to work)
    private void PlaySentence()
    {       
        //Type dialogue text by Coroutine, time between letters is .05 seconds
        StartCoroutine(TypeText(currentDialogue.Sentences[++sentenceIndex].text));

        if (currentDialogue.Sentences[sentenceIndex].isLeft)
        {
            //Makes visible only the LEFT SIDE INFORMATION BOXES
            SwitchSides(true);

            //Display the information on the left boxes
            dialogueNameLeft.text = currentDialogue.Sentences[sentenceIndex].speaker.speakerName;            
            boxNameLeft.color = currentDialogue.Sentences[sentenceIndex].speaker.boxNameColor;
            dialogueSpeakerLeft.sprite = currentDialogue.Sentences[sentenceIndex].speaker.speakerSprite;            
        }else
        {
            //Makes visible only the RIGHT SIDE INFORMATION BOXES
            SwitchSides(false);

            //Display the information on the left boxes
            dialogueNameRight.text = currentDialogue.Sentences[sentenceIndex].speaker.speakerName;
            boxNameRight.color = currentDialogue.Sentences[sentenceIndex].speaker.boxNameColor;
            dialogueSpeakerRight.sprite = currentDialogue.Sentences[sentenceIndex].speaker.speakerSprite;
        }        
    }

    #endregion

    #region Utility Functions

    private void ClearCharacters() // Clear the characters sprites of the dialogue.
    {
        dialogueSpeakerLeft.sprite = defaultSpeaker.speakerSprite;
        dialogueSpeakerRight.sprite = defaultSpeaker.speakerSprite;
    }

    private void ChangeVisivility() // Switchoff all boxes and names. To switch sides of speakers
    {
        //SetActive off ALL side information boxes
        dialogueNameLeft.gameObject.SetActive(false);
        dialogueNameRight.gameObject.SetActive(false);
        boxNameLeft.gameObject.SetActive(false);
        boxNameRight.gameObject.SetActive(false);
    }

    private void SwitchSides(bool Left)
    {
        //Makes all side information boxes invisible.
        ChangeVisivility();
        
        if (Left)
        {
            dialogueNameLeft.gameObject.SetActive(true);
            boxNameLeft.gameObject.SetActive(true);
        }
        if (!Left)
        {
            dialogueNameRight.gameObject.SetActive(true);
            boxNameRight.gameObject.SetActive(true);
        }
    }

    private IEnumerator TypeText(string text) // Makes the Corutine display letter to letter.
    {
        dialogueText.text = "";
        state = State.playing;
        int wordIndex = 0;

        while (state != State.finished)
        {
            dialogueText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state = State.finished;
                break;
            }
        }
    }

    private void ClosePopUp() // Close the Canva when finished the last Sentence of the dialogue. (with click)
    {
        //When the dialogue is finished (all the sentences) close de PopUp Dialogue Window
        if (state == State.finished && sentenceIndex == currentDialogue.Sentences.Count)
        {
            if (currentDialogue.dialogueOption)
            {
                GameManager.Get().ActiveOptionScreen(true);
                
            }else
            {
                GameManager.Get().ActiveDialogue(defaultDialogue, false);
            }
        }
    }
    #endregion

}
