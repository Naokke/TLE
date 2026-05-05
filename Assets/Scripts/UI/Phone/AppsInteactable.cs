using UnityEngine;
using UnityEngine.UI;

public class AppsInteactable : MonoBehaviour
{
    private Button appButton;
    private PhoneAppManager phone;
    [SerializeField] private int buttonValue;

    private void Start()
    {
        appButton = GetComponent<Button>();
        phone = GetComponentInParent<PhoneAppManager>();
        appButton.onClick.AddListener(OnButtonClicked);
    }
    private void OnButtonClicked()
    {
        Debug.Log($"Se ha presionado: {buttonValue}");
        phone.ActiveApp(buttonValue);
        
    }
}
