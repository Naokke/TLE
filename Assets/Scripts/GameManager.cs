using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    #region Variables and Objects

    [SerializeField] private DialogueController DialoguePopUp;
    [SerializeField] private Dialogue defaultDialogue;

    [SerializeField] private Canvas CanvaInteractableScreen;
    [SerializeField] private Canvas CanvaPasswordMinigame;
    [SerializeField] private Canvas CanvaPhoneScreen;
    [SerializeField] private Canvas OptionDialogueScreen;
    [SerializeField] private Canvas SettingsScreen;

    // Settings Variables
    private bool _isSettingsOpen = false;

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

    #region Update and Actives

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // TO DEBUG THINGS (TEMPORAL)
        {
            DialoguePopUp.PlayDialogue(defaultDialogue); //Debugging DialoguePopUp
        }
    }

    public void ActiveInteractableScreen(bool Active)
    { 
        CanvaInteractableScreen.gameObject.SetActive(Active);
    }

    public void ActiveDialogue(Dialogue clickedDialogue, bool Activate)
    {
        DialoguePopUp.gameObject.SetActive(Activate);
        DialoguePopUp.PlayDialogue(clickedDialogue);
        ActiveInteractableScreen(!Activate);
    }

    public void ActiveOptionScreen(bool Activate)
    {
        OptionDialogueScreen.gameObject.SetActive(Activate);
        ActiveDialogue(defaultDialogue,!Activate);
        ActiveInteractableScreen(!Activate);
    }

    public void ActivePhone(bool Activate)
    {
        CanvaPhoneScreen.gameObject.SetActive(Activate);
        ActiveInteractableScreen(!Activate);
    }

    public void OpenSettings()
    {
        if (!_isSettingsOpen)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
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

    public bool IsPasswordSuccess { get; private set; } = false;

    public void ActivePasswordMinigame(bool Activate)
    {
        CanvaPasswordMinigame.gameObject.SetActive(Activate);
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
