using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    public void Start()
    {
        Init(20, this.shooter);
        rb2d = GetComponent<Rigidbody2D>();
        force = new Vector2(GetShootDirection() * 10, 100);
        Move();
    }

    Rigidbody2D rb2d;
    Vector2 force;

    public override void Move()
    {
        rb2d.AddForce(force);
        //Debug.Log("Rock เคลื่อนที่ด้วย RigidBody: force");
    }
    public override void OnHitWith(Character character)
    {
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }
}
