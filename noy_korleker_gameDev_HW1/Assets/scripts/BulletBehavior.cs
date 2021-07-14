using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {        
        if(collision.gameObject.name == "Sara" || collision.gameObject.name == "James")
        {
            Animator a = collision.gameObject.GetComponent<Animator>();
            a.SetInteger("state", 1);
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            //rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            NavMeshAgent agent = collision.gameObject.GetComponent<NavMeshAgent>();
            agent.enabled = false;
            BoxCollider bc = collision.gameObject.GetComponent<BoxCollider>();
            bc.enabled = false;
        }
        Destroy(this.gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
