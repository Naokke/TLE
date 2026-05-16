using UnityEngine;
using UnityEngine.UI;

public class ChatsInteractable : MonoBehaviour
{
    private Button chatButton;
    [SerializeField] private ChatAppManager chatsApp;
    [SerializeField] private int buttonValue;

    private void Start()
    {
        chatButton = GetComponent<Button>();
        chatButton.onClick.AddListener(OnButtonClicked);
    }
    private void OnButtonClicked()
    {
        Debug.Log($"Se ha presionado: {buttonValue}");
        chatsApp.OpenChat(buttonValue);
    }
}
