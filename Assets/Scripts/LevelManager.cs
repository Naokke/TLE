using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(false);
        
    }
}
