using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveComplete : MonoBehaviour
{
    
    public void Quit()
    {
        FindAnyObjectByType<CardRealizer>().UpgradeShopEnd();
        Destroy(gameObject);
        switch(SceneManager.GetActiveScene().name)
        {
            case "AlphaEnvironment1":
            SceneManager.LoadScene("Scenes/AlphaEnvironment2");
            break;
            case "AlphaEnvironment2":
            SceneManager.LoadScene("Scenes/AlphaEnvironment3");
            break;
            case "AlphaEnvironment3":
            SceneManager.LoadScene("Scenes/MainMenu");
            break;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
