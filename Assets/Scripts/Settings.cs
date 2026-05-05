using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private Resolution selectedRes;
    private Resolution[] resolutions;

    private bool _isFullScreen;

    [SerializeField] Toggle fullScreenToggle;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] Slider Music;
    [SerializeField] Slider Effects;
    [SerializeField] Button QuitButton;

    private void Start()
    {
        QuitButton.onClick.AddListener(AppQuit);
        resolutionDropdown.onValueChanged.AddListener(ResChange);
        fullScreenToggle.onValueChanged.AddListener(ActivateFullScreen);

        CheckRes();
    }

    private void ActivateFullScreen(bool activate)
    {
        _isFullScreen = activate;
        ApplyRes();
    }

    private void ResChange(int selecRes)
    {
        selectedRes = resolutions[selecRes];
        ApplyRes();
    }

    private void ApplyRes()
    {
        Screen.SetResolution(selectedRes.width, selectedRes.height, _isFullScreen);
    }

    private void CheckRes()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> possibleRes = new List<string>();

        int counter = 0;
        int selected = 0;

        foreach (Resolution res in resolutions)
        {
            string option = $"{res.width} x {res.height}";
            possibleRes.Add(option);

            if (res.width == Screen.width && res.height == Screen.height)
            {
                selected = counter;
            }
            counter++;
        }

        resolutionDropdown.AddOptions(possibleRes);
        resolutionDropdown.value = selected;
        resolutionDropdown.RefreshShownValue();

        fullScreenToggle.isOn = Screen.fullScreen;
    }

    private void AppQuit()
    {
# if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
