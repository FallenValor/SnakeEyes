using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GameObject img;
    [SerializeField] GameObject parts;
    [SerializeField] float delay;
    [SerializeField] float rotMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img.transform.Rotate(0,0,Random.Range(0, rotMax));
        GameObject particls = Instantiate(parts,this.transform.position, Quaternion.identity);
        StartCoroutine(End());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
