using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocoodile : Enemy , IShootAble
{

    [SerializeField] private float attackRange;
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }
    [field: SerializeField] public float BulletSpawnTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }

    private void Update()
    {
        BulletTimer -= Time.deltaTime;

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

    public void Shoot()
    {
        if (BulletTimer <= 0)
        {
            Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);

            BulletTimer = BulletSpawnTime;
        } 
    }

}
