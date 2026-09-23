using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUITest : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
