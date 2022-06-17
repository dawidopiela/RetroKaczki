using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public Audioclip clip;
    public AudioSource audioSource;

    public Transform gunBarrelTransform;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<audioSource>();
        audioSource.clip = clip;


    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            audioSource.Play();
            RaycastGun();
        }
        

    }

    private void RayCastGun()
    {

        RaycastHit hit;

        if(Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("DuckWhite"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

    }

}
