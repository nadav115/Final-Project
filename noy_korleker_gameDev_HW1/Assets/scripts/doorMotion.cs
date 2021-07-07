using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMotion : MonoBehaviour
{
    private Animator anim;
    private AudioSource doorSound;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("isOpen", true);
        doorSound.PlayDelayed(0.2f);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("isOpen", false);
        doorSound.PlayDelayed(1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
