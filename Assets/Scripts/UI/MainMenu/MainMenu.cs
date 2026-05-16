using System;
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

    private bool videoFinished = false;

    private void Start()
    {
        buttonStart.onClick.AddListener(GameStart);
        buttonQuit.onClick.AddListener(GameQuit);
        buttonSettings.onClick.AddListener(GameSettings);

        videoPlayer.loopPointReached += VideoFinished;

        videoPlayer.gameObject.SetActive(false);
    }

    private void VideoFinished(VideoPlayer source)
    {
        if (videoFinished) return;
        videoFinished = true;

        videoPlayer.gameObject.SetActive(false);


        SceneManager.LoadScene(gameScene);
        GameManager.Get().StartGame();        
    }

    public void SkipVideo()
    {
        if (videoFinished) return;
        videoPlayer.Stop();

        VideoFinished(videoPlayer);
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
        videoPlayer.gameObject.SetActive(true);
        videoFinished = false;
        videoPlayer.Play();
        buttonStart.interactable = false;
    }
}
