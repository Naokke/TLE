using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaleryManager : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup galeryGrid;

    [Header ("ZoomPicture Button and Image")]
    [SerializeField] private Image zoomedPicture;
    [SerializeField] private Button buttonZoomedPicture;

    private void Start()
    {
        buttonZoomedPicture.onClick.AddListener(ExitZoom);


        zoomedPicture.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void ZoomPicture(Sprite picture)
    {
        zoomedPicture.gameObject.SetActive(true);        
        zoomedPicture.sprite = picture;
        zoomedPicture.preserveAspect = true;        
        galeryGrid.gameObject.SetActive(false);
    }    

    public void ExitZoom()
    {
        galeryGrid.gameObject.SetActive(true);
        zoomedPicture.gameObject.SetActive(false); 
    }
}
