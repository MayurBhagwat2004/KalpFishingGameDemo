using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button closeSettingsButton;

    [Header("Settings UI")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button lowGraphicsButton;
    [SerializeField] private Button medGraphicsButton;
    [SerializeField] private Button highGraphicsButton;
    void Start()
    {

        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener((value) => MenuEvents.OnVolumeChanged?.Invoke(value));
        }

        if (lowGraphicsButton != null) lowGraphicsButton.onClick.AddListener(() => MenuEvents.OnGraphicsChanged?.Invoke(0));
        if (medGraphicsButton != null) lowGraphicsButton.onClick.AddListener(() => MenuEvents.OnGraphicsChanged?.Invoke(1));
        if (highGraphicsButton != null) lowGraphicsButton.onClick.AddListener(() => MenuEvents.OnGraphicsChanged?.Invoke(2));

        MenuEvents.OnSettingsLoaded += UpdateSliderVisual;



        playButton.onClick.AddListener(() => MenuEvents.OnPlayRequested?.Invoke());
        settingsButton.onClick.AddListener(() => MenuEvents.OnSettingsOpenRequested?.Invoke());
        closeSettingsButton.onClick.AddListener(() => MenuEvents.OnSettingsClosed?.Invoke());
        quitButton.onClick.AddListener(() => MenuEvents.OnQuitRequested?.Invoke());

        MenuEvents.OnSettingsOpenRequested += ShowSettings;
        MenuEvents.OnSettingsClosed += ShowMainMenu;
        MenuEvents.OnQuitRequested += DisableMenu;


    }

    void OnDestroy()
    {
        MenuEvents.OnSettingsOpenRequested -= ShowSettings;
        MenuEvents.OnSettingsClosed -= ShowMainMenu;
        MenuEvents.OnQuitRequested -= DisableMenu;
    }
    private void UpdateSliderVisual(float savedVolume)
    {
        if (volumeSlider != null)
        {
            volumeSlider.SetValueWithoutNotify(savedVolume);
        }
    }
    private void ShowSettings()
    {
        settingsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    private void ShowMainMenu()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    private void DisableMenu()
    {
        if (settingsPanel.GetComponent<CanvasGroup>() != null)
        {
            settingsPanel.GetComponent<CanvasGroup>().interactable = false;
        }
        if (mainPanel.GetComponent<CanvasGroup>() != null)
        {
            mainPanel.GetComponent<CanvasGroup>().interactable = false;
        }


    }


}
