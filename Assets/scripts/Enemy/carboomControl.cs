using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carboomControl : MonoBehaviour {

    public float speed;
    public float rad;
    public float stopDistance;
    public float retreatDistance;

    public GameObject shellPrefab;
    public Transform shootPos;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform player1, player2;

    


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


        if (Vector3.Distance(transform.position, player1.position) < rad )
        {
            transform.LookAt(player1);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);            

        }
        //else if (Vector3.Distance(transform.position, player1.position) < stopDistance && Vector3.Distance(transform.position, player1.position) < retreatDistance)
        //{

        //    transform.position = this.transform.position;
            
        //}
        //else if (Vector3.Distance(transform.position, player1.position) > retreatDistance)
        //{
        //    transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        //}

        if (Vector3.Distance(transform.position, player2.position) < rad )
        {
            transform.LookAt(player2);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
        //else if (Vector3.Distance(transform.position, player2.position) < stopDistance && Vector3.Distance(transform.position, player2.position) < retreatDistance)
        //{
        //    transform.position = this.transform.position;
            
        //}
        //else if (Vector3.Distance(transform.position, player2.position) < retreatDistance)
        //{
        //    transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            collision.gameObject.GetComponent<playerHearth>().TakeDamage(8);
        }
        if (collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<playerHearth>().TakeDamage(8);
        }

        enemyDestoy();
    }

    void enemyDestoy()
    {
        Destroy(this.gameObject);
    }
}
