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
    [SerializeField] private Dialogue defaultD;

    [SerializeField] private Canvas CanvaInteractableScreen;
    [SerializeField] private Canvas CanvaPasswordMinigame;
    [SerializeField] private Canvas CanvaPhoneScreen;

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // TO DEBUG THINGS (TEMPORAL)
        {
            DialoguePopUp.PlayDialogue(defaultD); //Debugging DialoguePopUp
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

    #region Minigames PopUp

    // Phone AND Passwordminigame:    

    public bool IsPasswordSuccess { get; private set; } = false;

    public void ActivePhone(bool Activate)
    {
        CanvaPhoneScreen.gameObject.SetActive(Activate);
        ActiveInteractableScreen(!Activate);
    }

    public void ActivePasswordMinigame(bool Activate)
    {
        CanvaPasswordMinigame.gameObject.SetActive(Activate);
        ActiveInteractableScreen(!Activate);
    }

    public void PasswordCheker(bool passwordSucceed)
    {
        IsPasswordSuccess = passwordSucceed;
        Debug.Log("ContraseñaCorrecta");
    }

    #endregion

}
