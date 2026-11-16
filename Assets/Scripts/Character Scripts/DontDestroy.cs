using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] List<Vector3> positions;
    int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Move()
    {
        transform.position = positions[counter];
        counter += 1;
    }
}
