using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager instance;

    public static GameManager Get()
    {
        if (instance == null)
        {
            instance = FindFirstObjectByType<GameManager>();
        }
        return instance;
    }
    #endregion

    #region Variables and Objects

    [SerializeField] private DialogueController DialoguePopUp;
    [SerializeField] private Dialogue defaultDialogue;

    [SerializeField] private Canvas CanvaInteractableScreen;
    [SerializeField] private Canvas CanvaPasswordMinigame;
    [SerializeField] private Canvas CanvaPhoneScreen;
    [SerializeField] private Canvas OptionDialogueScreen;

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
