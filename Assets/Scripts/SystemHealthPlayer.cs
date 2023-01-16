using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemHealthPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float health_MaxPlayer = 100.0f;
    public float currentHealthPlayer;
    public bool immortal = false;
    public float timeImmortal = 1.0f;

    void Start()
    {
        currentHealthPlayer = health_MaxPlayer;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealthPlayer > health_MaxPlayer)
        {
            currentHealthPlayer = health_MaxPlayer;
        }

    }

    public void subtractHealthPlayer(float amount)
    {
        if (immortal) return;
        currentHealthPlayer -= amount;
        StartCoroutine(TimeImmortal());
    }
    public void addHealthPlayer(float amount)
    {
        currentHealthPlayer += amount;
    }

    public void deadPlayer()
    {
        Destroy(this.gameObject);
    }

    IEnumerator TimeImmortal()
    {
        immortal = true;
        yield return new WaitForSeconds(timeImmortal);
        immortal = false;
    }
}
