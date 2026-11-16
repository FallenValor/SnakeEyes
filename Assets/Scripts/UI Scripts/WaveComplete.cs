using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveComplete : MonoBehaviour
{
    
    public void Quit()
    {
        FindAnyObjectByType<DontDestroy>().Move();
        FindAnyObjectByType<CardRealizer>().UpgradeShopEnd();
        Destroy(gameObject);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
