using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Enemy
{

    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoint;

    private void Start()
    {
        Init(20);
        InitHealthBar(20);
        velocity = new Vector2(-1.0f, 0.0f);
        DamageHit = 20;
    }
    /*public void Init(int newHealth)
    {
        Health = newHealth;
    }*/

    private void FixedUpdate()
    {
        Behavior();
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x <= movePoint[0].position.x && velocity.x < 0)
        {
            FlipCharacter();
        }
        else if (rb.position.x >= movePoint[1].position.x && velocity.x > 0)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        velocity *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
