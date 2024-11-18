using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] float speed;
    public void Start()
    {
        Init(10, this.shooter);
        speed = 4.0f * GetShootDirection();
        Move();
    }
    public override void Move()
    {
        //s = speed * time
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
        //Debug.Log("Banana เคลื่อนที่ด้วย Tranform ด้วยความเร็วคงที่");
    }

    private void FixedUpdate()
    {
        Move();
    }
    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(this.Damage);
        }

    }
}
