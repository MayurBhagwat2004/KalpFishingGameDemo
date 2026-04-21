using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("State Prompts")]
    [SerializeField] private TextMeshProUGUI promptText;
    
    [SerializeField] private GameObject miniGamePanel;
    [SerializeField] private Slider catchProgressBar;
    [SerializeField] private Slider lineTensionBar;
    
    void Start()
    {
        ShowMiniGameUI(false);
    }

    void Update()
    {
        
    }

    public void SetPromptText(string mesasge)
    {
        if(promptText != null)
        {
            promptText.text = mesasge;
        }
    }

    public void ShowMiniGameUI(bool show)
    {
        if(miniGamePanel != null)
        {
            miniGamePanel.SetActive(show);
        }
    }

    public void UpdateMiniGameUI(float progress, float tension)
    {
        if(catchProgressBar != null) catchProgressBar.value = progress/100f;
        if(lineTensionBar != null) lineTensionBar.value = tension/100f;
    }
}
