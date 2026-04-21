using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private const string VolumeKey = "MasterVolume";
    private const string GraphicsKey = "GraphicsQuality";
    
    void Start()
    {
        MenuEvents.OnVolumeChanged += ApplyVolume;      
        MenuEvents.OnGraphicsChanged += ApplyGraphics;  

        LoadSettings();
    }


    void OnDestroy()
    {
        MenuEvents.OnVolumeChanged -= ApplyVolume;        
        MenuEvents.OnGraphicsChanged -= ApplyGraphics;  
        
    }
    void Update()
    {
        
    }

    private void ApplyVolume(float volume)
    {
        AudioListener.volume = volume;

        PlayerPrefs.SetFloat(VolumeKey,volume);
    }

    private void ApplyGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        PlayerPrefs.SetInt(GraphicsKey,qualityIndex);
        Debug.Log($"Graphics set to level: {qualityIndex}");
    }

    private void LoadSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey,1.0f);
        ApplyVolume(savedVolume);

        MenuEvents.OnSettingsLoaded?.Invoke(savedVolume);
    
        int savedGraphics = PlayerPrefs.GetInt(GraphicsKey,2);
        ApplyGraphics(savedGraphics);
    }
}
