using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float damageEnemy = 50.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SystemHealthPlayer>() != null)
        {
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<SystemHealthPlayer>().subtractHealthPlayer(damageEnemy);
            }

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<SystemHealthPlayer>() != null)
        {
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<SystemHealthPlayer>().subtractHealthPlayer(damageEnemy);
            }
        }
    }
}
