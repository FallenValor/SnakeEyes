using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] GameObject objs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(FindAnyObjectByType<CardRealizer>() == null)
        {
            Instantiate(objs);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
