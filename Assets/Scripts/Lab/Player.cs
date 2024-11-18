using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character , IShootAble
{
    [field: SerializeField]
    Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint { get { return bulletSpawnPoint; } set { bulletSpawnPoint = value; } }

    [field: SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    public float BulletSpawnTime { get; set; }
    public float BulletTimer { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && BulletTimer >= BulletSpawnTime)
        {
            GameObject obj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            Banana banana = obj.GetComponent<Banana>();
            banana.Init(10, this);
            BulletTimer = 0;
        }
    }
    void Start()
    {
        InitHealthBar(100);
        Init(100);
        BulletTimer = 0.0f;
        BulletSpawnTime = 1.0f;

    }
    void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        BulletTimer += Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collistion)
    {
        Enemy enemy = collistion.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
        }
    }

    void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
}
