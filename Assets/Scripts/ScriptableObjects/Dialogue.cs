using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Objects/Dialogue")]
[System.Serializable]
public class Dialogue : ScriptableObject
{
    public List<Sentence> Sentences;
    public bool dialogueOption;
    public DialogueOptions options;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speakers speaker;
        public bool isLeft;
            
    }
}
