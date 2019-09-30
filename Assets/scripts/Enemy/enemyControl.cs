using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour {
    public float speed;
    public float rad;
    public float stopDistance;
    public float retreatDistance;

    public GameObject shellPrefab;
    public Transform shootPos;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform player1, player2;

    public AudioClip tag1;
    public AudioSource Sound;


    // Use this for initialization
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        timeBtwShots = startTimeBtwShots;
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(transform.position, player1.position) < rad && Vector3.Distance(transform.position, player1.position) > stopDistance)
        {
            transform.LookAt(player1);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            shooting();

        }
        else if (Vector3.Distance(transform.position, player1.position) < stopDistance && Vector3.Distance(transform.position, player1.position) < retreatDistance)
        {

            transform.position = this.transform.position;
            shooting();
        }
        //else if (Vector3.Distance(transform.position, player1.position) > retreatDistance)
        //{
        //    transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        //}

        if (Vector3.Distance(transform.position, player2.position) < rad && Vector3.Distance(transform.position, player2.position) > stopDistance)
        {
            transform.LookAt(player2);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            shooting();
        }
        else if (Vector3.Distance(transform.position, player2.position) < stopDistance && Vector3.Distance(transform.position, player2.position) < retreatDistance)
        {
            transform.position = this.transform.position;
            shooting();
        }
        //else if (Vector3.Distance(transform.position, player2.position) < retreatDistance)
        //{
        //    transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        //}
                
    }

    void shooting()
    {
        if (timeBtwShots <= 0)
        {
            Sound.clip = tag1;
            Sound.Play();
            Instantiate(shellPrefab, shootPos.position, shootPos.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
