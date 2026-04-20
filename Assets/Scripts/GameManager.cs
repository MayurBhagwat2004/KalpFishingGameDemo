using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        MenuEvents.OnQuitRequested += QuitGame;        
    }

    void OnDestroy()
    {
        MenuEvents.OnQuitRequested -= QuitGame;
    }

    private void QuitGame()
    {
        Debug.Log("Quitting Game!!!");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    
    }
}
