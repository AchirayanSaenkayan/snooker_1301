using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]    
    private GameObject adjustmentPanel;

    [SerializeField]
    private Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = AudioManager.instance.LoadCurrentMasterVol();
        AudioManager.instance.PlayBGM(0);
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

    public void ShowHideAdjustmentPanel(bool flag)
    {
        adjustmentPanel.SetActive(flag);
    }

    public void SetVolume(float valume)
    {
        AudioManager.instance.AdjustMasterVolume(valume);
    }
}