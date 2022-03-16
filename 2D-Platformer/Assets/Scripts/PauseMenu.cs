using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        // Set Time in Game to 0
        Time.timeScale = 0f;
    }
    public static void Resume()
    {
        // Set Time to normal again and close Pause Menu
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("PauseMenu"), UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        Time.timeScale = 1f;
    }

    public void SaveGame()
    {
        GetPlayer().GetComponent<PlayerHealth>().SaveGame();
    }

    public void LoadGame()
    {
        GetPlayer().GetComponent<PlayerHealth>().LoadGame();
    }

    public void ResetGame()
    {
        GetPlayer().GetComponent<PlayerHealth>().ResetGame();
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        PlayerPrefs.DeleteKey("player");
    }

    public static GameObject GetPlayer()
    {
        if (PlayerPrefs.GetInt("player") == 0)
            return GameObject.Find("Player");
        if (PlayerPrefs.GetInt("player") == 1)
            return GameObject.Find("Archer");
        else
            return null;
    }
}
