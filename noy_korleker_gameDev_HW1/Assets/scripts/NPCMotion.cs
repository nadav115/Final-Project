using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCMotion : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject point;
    public GameObject MuzzleEnd;
    public List<GameObject> spwan;
    public GameObject bullet;
    private bool waiting = false;
    private RaycastHit hit;
    private List<GameObject> bullets = new List<GameObject>();

    


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
        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position);
            if (gun1.activeSelf == true || gun2.activeSelf == true)
            {
                if(gun1.activeSelf == true)
                {
                    Animator a = this.GetComponent<Animator>();
                    a.SetInteger("state", 2);
                }
                
                if (Physics.Raycast(point.transform.position, point.transform.right, out hit))
                {
                    //ball.transform.position = hit.point;
                    //StartCoroutine(ShowLine());
                    if (hit.transform.gameObject.tag == "Player" || hit.transform.gameObject.name == "Hana")
                    {
                        target = hit.transform.gameObject;
                        if(!waiting)
                            StartCoroutine(isThere());
                    }
                }
            }
        }
        else
        {
            gun1.SetActive(false);
            gun2.SetActive(false);
        }        
    }

    IEnumerator isThere()
    {
        waiting = true;
        
        if(hit.collider != null && (hit.transform.gameObject.tag == "Player" || hit.transform.gameObject.name == "Hana"))
        {
            bullets.Clear();
            for (int i = 0; i < spwan.Count; i++)
            {
                if (spwan[i])
                {
                    GameObject proj = Instantiate(bullet, spwan[i].transform.position, Quaternion.Euler(spwan[i].transform.forward)) as GameObject;
                    //proj.SetActive(true);
                    Rigidbody rb1 = proj.GetComponent<Rigidbody>();
                    Vector3 direction = this.transform.forward * 10;
                    rb1.AddForce(direction, ForceMode.Impulse);
                    bullets.Add(proj);
                    //StartCoroutine(Waiting());
                }
            }
            yield return new WaitForSeconds(1f);
            //bullet.transform.position = hit.point;
            //lr.SetPosition(0, MuzzleEnd.transform.position);
            //lr.SetPosition(1, bullet.transform.position);
            //lr.enabled = true;
            //target.SetActive(true);
            ////sound.Play();
            ////muzzleFlash.Play();
            //yield return new WaitForSeconds(0.2f);
            //lr.enabled = false;
            //target.SetActive(false);
        }
        waiting = false;
    }

}
