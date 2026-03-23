using UnityEngine;

[CreateAssetMenu(fileName = "Speakers", menuName = "Scriptable Objects/Speakers")]
[System.Serializable]
public class Speakers : ScriptableObject
{
    public string speakerName;
    public Color boxNameColor;
    public Sprite speakerSprite;
}
