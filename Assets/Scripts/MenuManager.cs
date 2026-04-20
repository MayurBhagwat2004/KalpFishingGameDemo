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

    void Start()
    {
        playButton.onClick.AddListener(()=> MenuEvents.OnPlayRequested?.Invoke());
        settingsButton.onClick.AddListener(()=> MenuEvents.OnSettingsOpenRequested?.Invoke());
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
        if(settingsPanel.GetComponent<CanvasGroup>() != null)
        {
            settingsPanel.GetComponent<CanvasGroup>().interactable = false;
        }
        if(mainPanel.GetComponent<CanvasGroup>() != null)
        {
            mainPanel.GetComponent<CanvasGroup>().interactable = false;
        }

        
    }


}
