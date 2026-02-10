using UnityEngine;
using UnityEngine.SceneManagement; 

public class ScenesManager : MonoBehaviour 
{
    public void LoadGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainGame"); 
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}