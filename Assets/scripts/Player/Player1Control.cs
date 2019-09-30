using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour {

    public float movementSpeed;
    public float rotateSpeed;

    public GameObject bullet;
    public Transform shootPos;
    public float delayTime;

    public AudioSource Sound;
    public AudioClip  tag1; 
    private bool isReadyShot;

	// Use this for initialization
	void Start () {
        isReadyShot = true;

	}
	
	// Update is called once per frame
	void Update () {

        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.up, -rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.up, rotateSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * movementSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.up, rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.up, -rotateSpeed * Time.deltaTime);
            }
        }

        //Shot bullet
        if (Input.GetKey(KeyCode.Space) && isReadyShot)
        {
            Instantiate(bullet, shootPos.position, shootPos.rotation);
            Sound.clip = tag1;
            Sound.Play();
            isReadyShot = false;
            Invoke("OnReadyShot", delayTime);
        }
    }



    void OnReadyShot()
    {
        isReadyShot = true;
    }

   
}
