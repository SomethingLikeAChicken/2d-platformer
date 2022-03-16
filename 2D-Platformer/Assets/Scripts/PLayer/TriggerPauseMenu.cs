using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    // Update is called once per frame
    void Update()
    {
        // Check if Escape Button got pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If Scene is not loaded open Pause Menu
            if (!SceneManager.GetSceneByName("Pausemenu").isLoaded)
                SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
            // If Scene is loaded and User presses Escape again close Pause Menu
            else
                PauseMenu.Resume();
        }
    }
}
