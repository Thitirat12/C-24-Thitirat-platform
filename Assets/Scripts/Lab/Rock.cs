using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{

    private Rigidbody2D rb2d;
    private Vector2 force;

    public override void OnHitWith(Character a)
    {
        
    }

    public override void Move()
    {
        Debug.Log("Rock move with RigidBody: Force");
    }

    private void Start()
    {
        Move();
        Damage = 40;
    }
}
