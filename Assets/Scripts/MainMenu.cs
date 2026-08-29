using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void StartNewGame()
    {
        Settings.fromSave = false;
        SceneManager.LoadScene("Loading");
    }

    public void LoadSaveGame()
    {
        Settings.fromSave = true;
        SceneManager.LoadScene("Loading");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}