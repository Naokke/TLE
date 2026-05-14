using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button buttonStart;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private string gameScene;
    [SerializeField] private VideoPlayer videoPlayer;

    private void Start()
    {
        buttonStart.onClick.AddListener(GameStart);
        buttonQuit.onClick.AddListener(GameQuit);
        buttonSettings.onClick.AddListener(GameSettings);

        
    }

    private void GameSettings()
    {
        GameManager.Get().OpenSettings();
    }

    private void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    private void GameStart()
    {
        videoPlayer.Play();
        
        SceneManager.LoadScene(gameScene);
        GameManager.Get().StartGame();
    }
}
