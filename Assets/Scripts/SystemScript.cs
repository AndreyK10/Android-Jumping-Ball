using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemScript : MonoBehaviour
{
    public static bool isPaused { get; private set; }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        isPaused = false;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;

    }

    public void Continue()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void DeleteHighscore()
    {
        PlayerPrefs.DeleteAll();
        SkinManager.instance.EquipDefaultSkin();
    }
}
