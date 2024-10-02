using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocoodile : Enemy
{

    [SerializeField] private float attackRange;
    public Player player;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;


    [SerializeField] private float bulletSpawnTime;
    [SerializeField] private float bulletTimer;


    private void Update()
    {
        bulletTimer -= Time.deltaTime;

        Behavior();
    }

    public override void Behavior()
    {
        Vector3 dicrection = player.transform.position - transform.position;
        float distance = dicrection.magnitude;

        if (distance < attackRange)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bulletTimer <= 0)
        {
            Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            bulletTimer = bulletSpawnTime;
        } 
    }

}
