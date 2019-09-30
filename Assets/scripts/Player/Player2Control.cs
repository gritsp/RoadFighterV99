using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour {
    public float movementSpeed;
    public float rotateSpeed;

    public GameObject bullet;
    public Transform shootPos;
    public float delayTime;

    public AudioSource Sound;
    public AudioClip tag1;


    private bool isReadyShot;

    // Use this for initialization
    void Start()
    {
        isReadyShot = true;

    }

    // Update is called once per frame
    void Update()
    {

        //Movement
        if (Input.GetKey(KeyCode.Keypad8))
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Rotate(transform.up, -rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Rotate(transform.up, rotateSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            transform.position -= transform.forward * movementSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Rotate(transform.up, rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Rotate(transform.up, -rotateSpeed * Time.deltaTime);
            }
        }

        //Shot bullet
        if (Input.GetKey(KeyCode.RightArrow) && isReadyShot)
        {
            Sound.clip = tag1;
            Sound.Play();
            Instantiate(bullet, shootPos.position, shootPos.rotation);
            isReadyShot = false;
            Invoke("OnReadyShot", delayTime);
        }
    }
    
    void OnReadyShot()
    {
        isReadyShot = true;
    }
}
