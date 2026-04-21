using System;
using UnityEngine;

public static class MenuEvents
{

    public static Action<float> OnVolumeChanged;
    public static Action<int> OnGraphicsChanged;

    public static Action OnPlayRequested;
    public static Action OnSettingsOpenRequested;
    public static Action OnSettingsClosed;
    public static Action OnQuitRequested;
    public static Action<float> OnSettingsLoaded;
}
