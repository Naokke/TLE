using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<GameObject> Levels;
    private GameManager gm;

    void Start()
    {
        gm = GameManager.Get();
        ClearScreens();
        this.gameObject.SetActive(false);
    }

    private void ClearScreens()
    {
        foreach (GameObject level in Levels)
        {
            level.gameObject.SetActive(false);
        }
    }

    public void SetLevel(int level)
    {
        Levels[level].gameObject.SetActive(true);

    }

    public void SetPhase()
    {

    }

}
