using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    private int mainMenuSceneIndex = 0;

    [Header("Loading UI")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider progressBar;
    void Start()
    {
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(mainMenuSceneIndex);
    }

    private IEnumerator LoadSceneAsync()
    {
        if(loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(mainMenuSceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if(progressBar != null)
            {
                progressBar.value = progress;
            }

            yield return null;
        }
    }
}
