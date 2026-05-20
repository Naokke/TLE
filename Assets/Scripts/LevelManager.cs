using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<GameObject> InteractableScreens;
    private GameManager gm;



    void Start()
    {
        gm = GameManager.Get();
        ClearScreens();
        this.gameObject.SetActive(false);
    }

    private void ClearScreens()
    {
        foreach (GameObject level in InteractableScreens)
        {
            level.gameObject.SetActive(false);
        }
    }

    public void SetLevel(int level)
    {
        InteractableScreens[level].gameObject.SetActive(true);

    }

    public void SetPhase()
    {

    }

}
