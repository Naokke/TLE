using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public DialogueController DialoguePopUp;

    public static GameManager Get()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            ActiveDialogue();           
        }
    }

    public void ActiveDialogue() // To Set Active DialoguePopUp "window"
    {
        DialoguePopUp.gameObject.SetActive(true);
        DialoguePopUp.PlayDialogue();
    }

    

}
