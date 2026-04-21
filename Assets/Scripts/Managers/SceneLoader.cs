using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private enum SceneNamesEnum
    {
        FishingLevel, HomeScene
    }

    [SerializeField] private string sceneName;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider progressBar;

    void Start()
    {
        MenuEvents.OnPlayRequested += LoadGameScene;
    }

    void OnDestroy()
    {
        MenuEvents.OnPlayRequested -= LoadGameScene;

    }

    private void LoadGameScene()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic(AudioManager.Instance.fishingMusic);
        }
        if (sceneName == nameof(SceneNamesEnum.FishingLevel))
        {
            StartCoroutine(LoadSceneAsync());
        }
    }

    private IEnumerator LoadSceneAsync()
    {
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (progressBar != null)
            {
                progressBar.value = progress;
            }

            yield return null;
        }
    }


}
