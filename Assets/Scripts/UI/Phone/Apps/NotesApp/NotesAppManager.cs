using UnityEngine;
using UnityEngine.UI;

public class NotesAppManager : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup notesGrid;

    [Header("ZoomNotes Button and Image")]
    [SerializeField] private Image zoomedNote;
    [SerializeField] private Button buttonZoomedNote;

    private void Start()
    {
        buttonZoomedNote.onClick.AddListener(ExitZoom);


        zoomedNote.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void ZoomNote(Sprite currentNote)
    {
        zoomedNote.gameObject.SetActive(true);
        zoomedNote.sprite = currentNote;
        zoomedNote.preserveAspect = true;
        notesGrid.gameObject.SetActive(false);
    }

    public void ExitZoom()
    {
        notesGrid.gameObject.SetActive(true);
        zoomedNote.gameObject.SetActive(false);
    }
}
