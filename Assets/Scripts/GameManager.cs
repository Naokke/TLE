using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    #region Variables and Objects

    [Header("Dialogues")]
    [SerializeField] private DialogueController dialoguePopUp;
    [SerializeField] private Dialogue defaultDialogue;

    [Header("Canvas")]
    [SerializeField] private Canvas canvaInteractableScreen;
    [SerializeField] private Canvas canvaPasswordMinigame;
    [SerializeField] private Canvas canvaPhoneScreen;
    [SerializeField] private Canvas optionDialogueScreen;
    [SerializeField] private Canvas settingsScreen;

    [Header("Scenes")]
    [SerializeField] private string sceneMainMenu;
    [SerializeField] private string sceneGame;
    [SerializeField] private string sceneSettings;   

    // Settings Variables
    private bool _isSettingsOpen = false;

    public bool IsPasswordSuccess { get; private set; } = false;


    // Level 1 variables.

    private bool respuesta1 = false;
    private bool respuesta2 = false;

    #endregion

    #region Options Functions

    public void GetClue(string answer, bool get)
    {
        if (get)
        {
            switch (answer.ToUpper())
            {
                case "SALCHIPAPA":
                    respuesta1 = true;
                    Debug.Log(respuesta1);
                    break;
            }
        }
    }

    #endregion

    #region Start, Update and Actives

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // TO DEBUG THINGS (TEMPORAL)
        {
            dialoguePopUp.PlayDialogue(defaultDialogue); //Debugging DialoguePopUp
        }
    }

    public void ActiveInteractableScreen(bool Active)
    { 
        canvaInteractableScreen.gameObject.SetActive(Active);
    }

    public void ActiveDialogue(Dialogue clickedDialogue, bool Activate)
    {
        dialoguePopUp.gameObject.SetActive(Activate);
        dialoguePopUp.PlayDialogue(clickedDialogue);
        ActiveInteractableScreen(!Activate);
    }

    public void ActiveOptionScreen(bool Activate)
    {
        optionDialogueScreen.gameObject.SetActive(Activate);
        ActiveDialogue(defaultDialogue,!Activate);
        ActiveInteractableScreen(!Activate);
    }

    public void ActivePhone(bool Activate)
    {
        canvaPhoneScreen.gameObject.SetActive(Activate);
        ActiveInteractableScreen(!Activate);
    }

    public void OpenSettings()
    {
        if (!_isSettingsOpen)
        {
            SceneManager.LoadScene(sceneSettings, LoadSceneMode.Additive);
            _isSettingsOpen = true;
        }else
        {
            SceneManager.UnloadSceneAsync(2);
            _isSettingsOpen = false;
            //QUITAR ESCENA DE AJUSTES
        }
        
    }

    #endregion

    #region Minigames PopUp

    // Phone AND Passwordminigame:    

    

    public void ActivePasswordMinigame(bool Activate)
    {
        canvaPasswordMinigame.gameObject.SetActive(Activate);
        ActiveInteractableScreen(!Activate);
    }

    public void PasswordCheker(bool passwordSucceed)
    {
        if (passwordSucceed == true)
        {
            IsPasswordSuccess = passwordSucceed;
            Debug.Log("ContraseñaCorrecta");
            ActivePasswordMinigame(false);
        }
    }
    #endregion

}
