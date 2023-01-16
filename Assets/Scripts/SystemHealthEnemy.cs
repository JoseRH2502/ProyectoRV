using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SystemHealthEnemy : MonoBehaviour
{
   
    public float health_MaxEnemy = 200.0f;
    public float currentHealthEnemy;



    public bool immortal = false;
    public float timeImmortal = 1.0f;

    public void Start()
    {
        currentHealthEnemy = health_MaxEnemy;
      
    }
    public void Update()
    {
        if (currentHealthEnemy <= 0) {
           deadEnemy();
        }

    }
    public void subtractHealthEnemy(float amount)
    {
        if (immortal) return;
        currentHealthEnemy -= amount;
        StartCoroutine(TimeImmortal());
    }


    public void deadEnemy() {
        Destroy(this.gameObject);
    }

    IEnumerator TimeImmortal()
    {
        immortal= true;
        yield return new WaitForSeconds(timeImmortal);
        immortal= false;
    }
    
}
