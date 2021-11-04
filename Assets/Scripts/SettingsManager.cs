using System;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private SettingsDataHandler dataHandler;
    private SettingsContainer settings;

    public void Awake()
    {
        dataHandler = new SettingsDataHandler();
        SettingsContainer settings = dataHandler.LoadSettingsData();
        this.settings = settings;
        ApplyNewSettings();
    }

    private void ApplyNewSettings()
    {
        string[] screenParams = settings.screenResolution.Split('x');
        Screen.SetResolution(Int32.Parse(screenParams[0]), Int32.Parse(screenParams[1]), 
            true);
        Application.targetFrameRate = settings.fps;
        QualitySettings.masterTextureLimit = (int) settings.texturesResolution;
    }

    public void SaveSettings()
    {
        dataHandler.SaveSettingsData(settings);
    }
}
