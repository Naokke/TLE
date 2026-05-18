using System;
using UnityEngine;
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
    [SerializeField] private Canvas canvaoptionDialogueScreen;
    [SerializeField] private Canvas canvasettingsScreen;
    [SerializeField] private Canvas canvasMap;

    [Header("Scenes")]
    [SerializeField] private string sceneSettings;



    // Settings Variables
    private bool _isSettingsOpen = false;
    private bool _isMapOpen = false;
    public bool IsPasswordSuccess { get; private set; } = false;

    #endregion

    #region LevelManager

    // Levels

    public bool _isPhoneUpdate = false;

    [SerializeField] private Levels _currentLevel;

    public Levels CurrentLevel
    {
        get => _currentLevel;
        private set
        {
            if (_currentLevel != value)
            {
                _currentLevel = value;
            }
        }
    }

    public enum Levels
    {
        Level1, Level2, Level3, Level4, Final
    }

    public enum Phases
    {
        First, Second, Third, Final
    }

    public void StartGame()
    {
        canvaInteractableScreen.gameObject.SetActive(true);        
        CurrentLevel = Levels.Level1;  
    }

    public void NextLevel()
    {
        if (CurrentLevel == Levels.Final) return;
        CurrentLevel = CurrentLevel + 1;
    }

    #endregion

    #region Level 1
    // Level 1 variables.

    private bool respuesta1 = false;
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
        canvaoptionDialogueScreen.gameObject.SetActive(Activate);
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
            SceneManager.UnloadSceneAsync(sceneSettings);
            _isSettingsOpen = false;
            //QUITAR ESCENA DE AJUSTES
        }        
    }

    public void OpenMap()
    {
        if (!_isMapOpen)
        {
            canvasMap.gameObject.SetActive(true);
            _isMapOpen = true;
            MapManager.Get().CurrentOptions(CurrentLevel);
        }
        else
        {
            canvasMap.gameObject.SetActive(false); 
            _isMapOpen = false;
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
            Debug.Log("Contrase�aCorrecta");
            ActivePasswordMinigame(false);
        }
    }

    
    #endregion

}
