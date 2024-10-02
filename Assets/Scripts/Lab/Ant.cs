using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Enemy
{

    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;


    private void Start()
    {
        //Initialize(10);
        Debug.Log($"{Health}");
        Behavior();
    }

    private void FixedUpdate()
    {
        Behavior();  
    }

    /*public void Initialize(int newHealth)
    {
        Health = newHealth;
    }*/

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FlipCharacter();
        }

        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
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
