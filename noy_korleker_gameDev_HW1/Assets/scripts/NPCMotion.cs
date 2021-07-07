using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCMotion : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    //public GameObject[] targets;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
       // target = targets[Random.Range(0, 6)];
    }

    public void changeTarget()
    {
       // target = targets[Random.Range(0, 6)];
    }
    // Update is called once per frame
    void Update()
    {
       
        agent.SetDestination(target.transform.position);
    }
}
