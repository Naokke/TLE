using TMPro;
using UnityEngine;

public class PhonePasswordMinigame : MonoBehaviour
{
    [SerializeField] TMP_Text displayPassword;

    private string password = "2950";
    private string currentTry = "";

    private void Start()
    {
        // ACTIVATION IN: GameManager Script
        this.gameObject.SetActive(false); //Set GameObject Invisible, to use just when needed. 
    }

    public void buttonPasswordPressed(int number)
    {
        
        if (number <= 10) // 0 - 9 numbers aviable.
        {
            AddDigit(number);
            CheckPassword();
        }
        else
        {
            switch (number)
            {
                case 11:
                    DeleteTry();
                    break;
                case 12:
                    CheckPassword();
                    break;
            }
        }
    }

    private void AddDigit(int number)
    {
        currentTry += number.ToString();
        Debug.Log($"Contraseña Actual: {password}, intento actual: {currentTry}");
        displayPassword.text = currentTry;
    }

    private void CheckPassword()
    {
        if (currentTry.Length <= 4 && currentTry == password)
        {
            GameManager.Get().PasswordCheker(true);
            this.gameObject.SetActive(false);
        }
        if (currentTry.Length >= 4)
        {
            DeleteTry();
            return;
        }
        
    }

    private void DeleteTry()
    {
        currentTry = "";
        displayPassword.text = currentTry;
    }
}
