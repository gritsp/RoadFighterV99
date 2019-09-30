using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour {

    public float movementSpeed;
    public float bulletDamage;

    
    //public GameObject player1;
    //public GameObject player2;
    //public Transform[] player;
    
    // Use this for initialization
    void Start () {

        Update();
        
        //player1 = GameObject.FindGameObjectWithTag("Player1");
        //player2 = GameObject.FindGameObjectWithTag("Player2");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
	}

    void OnCollisionEnter(Collision collision)
    {
      

        if (collision.gameObject.tag == "Player1")
        {
           
            collision.gameObject.GetComponent<playerHearth>().TakeDamage(bulletDamage);
        }
        if (collision.gameObject.tag == "Player2")
        {
           
            collision.gameObject.GetComponent<playerHearth>().TakeDamage(bulletDamage);
        }
        if (collision.gameObject.tag == "Enemy")
        {
           
            collision.gameObject.GetComponent<enemyHearth>().TakeDamage(bulletDamage);
        }
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<wapsEnd>().TakeDamage(bulletDamage);
        }

        Destroy(gameObject);
        
    }

    

    //private void OnTriggerEnter(Collider other)
    //{
    //    // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

    //    // Go through all the colliders...
    //    for (int i = 0; i < colliders.Length; i++)
    //    {
    //        // ... and find their rigidbody.
    //        Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

    //        // If they don't have a rigidbody, go on to the next collider.
    //        if (!targetRigidbody)
    //            continue;

    //        // Add an explosion force.
    //        targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

    //        // Find the TankHealth script associated with the rigidbody.
    //        playerHearth targetHealth = targetRigidbody.GetComponent<playerHearth>();

    //        // If there is no TankHealth script attached to the gameobject, go on to the next collider.
    //        if (!targetHealth)
    //            continue;

    //        // Calculate the amount of damage the target should take based on it's distance from the shell.
    //        float damage = 2f;

    //        // Deal this damage to the tank.
    //        targetHealth.TakeDamage(damage);
    //    }

     

    //    // Destroy the shell.
    //    Destroy(gameObject);
    //}


}
