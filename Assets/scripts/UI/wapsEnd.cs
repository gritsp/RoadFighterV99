using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class wapsEnd : MonoBehaviour {


    public float maxHp;
    public Image hpBar;
    public float currentHp;

    public AudioClip suy1;
    public AudioSource Sound;
    // Use this for initialization
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        showHpBar();
    }


    public void TakeDamage(float amount)
    {
        Debug.Log("hit!" + currentHp);
        currentHp -= amount;

        showHpBar();
        if (currentHp <= 0)
        {
            Destroy(this.gameObject);
            Sound.clip = suy1;
            Sound.Play();
            SceneManager.LoadScene("END");
            
        }
    }

    void showHpBar()
    {
        hpBar.fillAmount = currentHp / maxHp;
    }

   
}
