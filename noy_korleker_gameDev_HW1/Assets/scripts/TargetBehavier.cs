using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavier : MonoBehaviour
{
    private int[] height = new int[2]; 

    public GameObject NPC;
    // Start is called before the first frame update
    void Start()
    {
        height[0] = 4;
        height[1] = 14;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            float x, y, z;
            x = Random.Range(-17, 34);
            z = Random.Range(-31, 17);
            if(z < -7 && x > 10)
            {
                y = height[0];
            }
            else
            {
                y = height[Random.Range(0, 2)];
            }            
            this.transform.position = new Vector3(x, y, z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
