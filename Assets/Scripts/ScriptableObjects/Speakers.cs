using UnityEngine;

[CreateAssetMenu(fileName = "Speakers", menuName = "Scriptable Objects/Speakers")]
[System.Serializable]
public class Speakers : ScriptableObject
{
    public string speakerName; //Name of the Character (Speaker)
    public Color boxNameColor; // Temporal - Color of the Characther (Speaker) name box
    public Sprite speakerSprite; // Temporal(? - Sprite of the Characther (Speaker) 
    //Could be change to an animation or similar.
}
