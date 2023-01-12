using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shot : MonoBehaviour
{
    [SerializeField] public AudioSource shotSound;
    public static Shot Instance;

    public GameObject bullet;
    public Transform spawnPoint;

    public float shotForce = 1500;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void StartFiring()
    {
        if (Time.time > shotRateTime)
        {
            shotSound.Play();
            GameObject newBullet;
            newBullet = GameObject.Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
            shotRateTime = Time.time + shotRate;
            SimpleShoot.Instance.InitAnimation();
            Destroy(newBullet, 2);
        }
    }
}
