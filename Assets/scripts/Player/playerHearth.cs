using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHearth : MonoBehaviour {

    public float maxHp;
    public Image hpBar;
    public Transform spaw;

    public AudioClip suy1;
    public AudioSource Sound;
    public float currentHp;
	// Use this for initialization
	void Start () {
        currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
        showHpBar();
	}

    
    public void TakeDamage(float amount)
    {
        Debug.Log("hit!" + currentHp);
        currentHp -= amount;

        showHpBar();
        if (currentHp <= 0)
        {           
            Invoke("Dead", 0.5f);
            Sound.clip = suy1;
            Sound.Play();
        }
    }

    void showHpBar()
    {
        hpBar.fillAmount = currentHp / maxHp;
    }

    void Dead()
    {
        
        transform.position = spaw.position;
        currentHp = maxHp;
    }
}
