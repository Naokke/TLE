using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaleryManager : MonoBehaviour
{
    [SerializeField] private List<ButtonImagesGalery> buttonPictures;
    [SerializeField] private Image zoomedPicture;

    private void Start()
    {
        buttonPictures = new List<ButtonImagesGalery>();
        this.gameObject.SetActive(false);
    }

    public void ZoomPicture(Sprite picture)
    {
        zoomedPicture.gameObject.SetActive(true);
        zoomedPicture.sprite = picture;
    }


}
