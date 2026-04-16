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

    [SerializeField] private Canvas InteractableScreen;
    [SerializeField] private Canvas PasswordMinigameCanva;

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // TO DEBUG THINGS (TEMPORAL)
        {
            DialoguePopUp.PlayDialogue(defaultD); //Debugging DialoguePopUp
        }
    }

    public void ActiveDialogue(Dialogue clickedDialogue, bool Activate) 
    {
        if (Activate)
        {
            // To SetActive() DialoguePopUp "window" and makes dialogue appear            
            DialoguePopUp.PlayDialogue(clickedDialogue);
            InteractableScreen.gameObject.SetActive(false);
            DialoguePopUp.gameObject.SetActive(true);

        } else if (!Activate)
        {
            DialoguePopUp.gameObject.SetActive(false);
            InteractableScreen.gameObject.SetActive(true);
        }
    }



}
