using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocoodile : Enemy , IShootAble
{

    /*
    float attackRange;
    public Player player;
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }
    [field: SerializeField] public float BulletSpawnTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }
    */
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }
    public Player player;

    [field: SerializeField]
    Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint { get { return bulletSpawnPoint; } set { bulletSpawnPoint = value; } }

    [field: SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    public float BulletSpawnTime { get; set; }
    public float BulletTimer { get; set; }

    void Start()
    {
        InitHealthBar(30);
        Init(30);
        BulletTimer = 0.0f;
        BulletSpawnTime = 3.0f;
        DamageHit = 30;
        AttackRange = 8;
        player = GameObject.FindObjectOfType<Player>();
    }
    void FixedUpdate()
    {
        BulletTimer += Time.fixedDeltaTime;
        Behavior();
    }
    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        if (distance <= attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (BulletTimer >= BulletSpawnTime)
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            Rock rock = obj.gameObject.GetComponent<Rock>();
            rock.Init(20, this);

            BulletTimer = 0;
        }
    }
}
