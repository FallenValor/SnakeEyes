using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveComplete : MonoBehaviour
{
    
    public void Quit()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "AlphaEnvironment1":
            SceneManager.LoadScene("Scenes/AlphaEnvironment2");
            break;
            case "AlphaEnvironment2":
            SceneManager.LoadScene("Scenes/AlphaEnvironment3");
            break;
            case "AlphaEnvironment3":
            SceneManager.LoadScene("Scenes/AlphaMainMenu");
            break;
        }
        FindAnyObjectByType<CardRealizer>().UpgradeShopEnd();
        Destroy(gameObject);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
