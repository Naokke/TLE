using UnityEngine;
using UnityEngine.EventSystems;

public class SkipVideo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private MainMenu _mainMenu;

    public void OnPointerClick(PointerEventData eventData)
    {
        _mainMenu.SkipVideo();
    }
}
