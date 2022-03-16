using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private bool isArcher;
    public void SetPlayer(bool isArcherButton)
    {
        isArcher = isArcherButton;
    }
    public void PlayGame()
    {
        if (!isArcher)
            PlayerPrefs.SetInt("player", 0);
        if (isArcher)
            PlayerPrefs.SetInt("player", 1);
        PlayerPrefs.Save();
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
