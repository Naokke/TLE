using UnityEngine;
using UnityEngine.UI;

public class ButtonNotesApp : MonoBehaviour
{
    private Button button;
    private Image selfSprite;
    [SerializeField] private Sprite NotePre;
    [SerializeField] private Sprite NotePost;
    private NotesAppManager manager;

    private void Start()
    {
        button = GetComponent<Button>();
        selfSprite = GetComponent<Image>();
        manager = GetComponentInParent<NotesAppManager>();

        button.onClick.AddListener(ZoomPiture);

        //if (!GameManager.Get()._isPhoneUpdate){}
        selfSprite.sprite = NotePre;
    }

    private void ZoomPiture()
    {
        Debug.Log("Zoomed Succesfully");

        // if (!GameManager.Get()._isPhoneUpdate){}
        manager.ZoomNote(NotePre);
    }
}
