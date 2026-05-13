using UnityEngine;

[CreateAssetMenu(fileName = "DialogueOptions", menuName = "Scriptable Objects/DialogueOptions")]
[System.Serializable]
public class DialogueOptions : ScriptableObject
{
    [Header("InfoButtonA")]
    public string textOptionA;
    public Dialogue dialogueAnswerA;
    public bool _isACorrect;
    public string keyInfoA;

    [Header("InfoButtonB")]
    public string textOptionB;
    public Dialogue dialogueAnswerB;
    public bool _isBCorrect;
    public string keyInfoB;

    [Header("Generic Answer")]
    public bool _isGeneric;
    public Dialogue dialogueAnswerGeneric;
}
