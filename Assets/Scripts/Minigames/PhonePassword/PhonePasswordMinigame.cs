using UnityEngine;

public class PhonePasswordMinigame : MonoBehaviour
{
    private string password = "1234";
    private string currentTry = "";

    private void Start()
    {
        // ACTIVATION IN: GameManager Script
        this.gameObject.SetActive(false); //Set GameObject Invisible, to use just when needed. 
    }

    public void buttonPasswordPressed(int number)
    {
        Debug.Log($"Contraseña Actual: {password}, intento actual: {currentTry}");

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
    }

    private void CheckPassword()
    {
        if (currentTry.Length > 4)
        {
            DeleteTry();
            return;
        }
        if (currentTry.Length <= 4 && currentTry == password)
        {
            GameManager.Get().PasswordCheker(true);
            this.gameObject.SetActive(false);
        }
    }

    private void DeleteTry()
    {
        currentTry = "";
    }
}
