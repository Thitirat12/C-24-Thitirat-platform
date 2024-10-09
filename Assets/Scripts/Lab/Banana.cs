using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;

    public override void OnHitWith(Character a)
    {
       
    }
    public override void Move()
    {
        Debug.Log("Banana move with tranfrom at constant speed");
    }

    private void Start()
    {
        Damage = 30;
        speed = 4f;
        Move();
    }
}
