using UnityEngine;
using UnityEngine.SceneManagement;

public class UImmanager : MonoBehaviour
{
    // Cargar una escena específica
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Volver al menú principal
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Cargar la escena del juego
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Cargar la escena de pausa
    public void LoadPauseScene()
    {
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
    }

    // Salir del juego
    public void QuitGame()
    {
        Application.Quit();
    }
}
