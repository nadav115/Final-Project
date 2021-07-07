using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerShooting : MonoBehaviour
{
    public GameObject gun;
    public GameObject aCamera;
    public GameObject target;
    private LineRenderer lr;
    public GameObject MuzzleEnd;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && gun.activeSelf)
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                StartCoroutine(ShowLine());
                //if (hit.transform.gameObject.name == enemy.gameObject.name)
                //{
                //    Animator a = enemy.GetComponent<Animator>();
                //    a.SetInteger("NPCState", 2);
                //    NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                //    agent.enabled = false;
                //    enemy.GetComponent<LineRenderer>().enabled = false;
                //}
            }
        }
    }
    IEnumerator ShowLine()
    {
        lr.SetPosition(0, MuzzleEnd.transform.position);
        lr.SetPosition(1, target.transform.position);
        lr.enabled = true;
        target.SetActive(true);
        //sound.Play();
        //muzzleFlash.Play();
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
        target.SetActive(false);
    }

}

