using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] GameObject music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(FindAnyObjectByType<MusicPlayer>() == null)
        {
            Instantiate(music);
        }
    }
}
