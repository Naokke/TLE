using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<GameObject> Levels;
    [SerializeField] List<GameObject> Phases;

    private int currentLevel = 0;
    private int currentPhase = 0;

    void Start()
    {
        ClearScreens();
        this.gameObject.SetActive(false);
    }

    private void ClearScreens()
    {
        foreach (GameObject level in Levels)
        {
            level.gameObject.SetActive(false);
        }

        foreach (GameObject phases in Phases)
        {
            phases.gameObject.SetActive(false);
        }

    }

    public void SetLevel(int level)
    {

    }

    public void SetPhase()
    {

    }

}
