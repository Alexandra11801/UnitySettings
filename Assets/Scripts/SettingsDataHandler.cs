using System.IO;
using UnityEngine;

public class SettingsDataHandler
{

    private static readonly string path = Application.dataPath + "/StreamingAssets/settings.json";

    public SettingsContainer LoadSettingsData()
    {
        string jsonString = File.ReadAllText(path);
        SettingsContainer settings = JsonUtility.FromJson<SettingsContainer>(jsonString);
        return settings;
    }

    public void SaveSettingsData(SettingsContainer settings)
    {
        string jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(path, jsonString);
    }

}
