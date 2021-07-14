using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject anim;
    public GameObject part1;
    public GameObject part2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);
        part1.SetActive(false);
        part2.SetActive(false);
        anim.SetActive(true);

    }
}
