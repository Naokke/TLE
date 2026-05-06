using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImagesGalery : MonoBehaviour
{
    private Button button;
    private Image selfPicure;
    [SerializeField] private Sprite Picture;
    private GaleryManager manager;

    private void Start()
    {
        button = GetComponent<Button>();
        selfPicure = GetComponent<Image>();
        manager = GetComponentInParent<GaleryManager>();

        button.onClick.AddListener(ZoomPiture);
        selfPicure.sprite = Picture;
    }

    private void ZoomPiture()
    {
        manager.ZoomPicture(Picture);
    }
}
