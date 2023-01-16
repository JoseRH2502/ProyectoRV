using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageBullet : MonoBehaviour
{
    public float damageBullet = 50.0f;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SystemHealthEnemy>() != null) {
            if (other.tag == "Enemy") {
                other.gameObject.GetComponent<SystemHealthEnemy>().subtractHealthEnemy(damageBullet);
            }
   
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<SystemHealthEnemy>() != null)
        {
            if (other.tag == "Enemy")
            {
                other.gameObject.GetComponent<SystemHealthEnemy>().subtractHealthEnemy(damageBullet);
            }
        }
    }





}
