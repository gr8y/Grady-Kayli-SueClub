﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Actor {

    public float damageAmount = 10.0f;
    public float movementSpeed = 20f;
    public float lifetime = 5.0f;
    Rigidbody rb; 
    
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        rb.velocity = transform.forward * movementSpeed;
       
    }



    void OnTriggerEnter(Collider other)
    {
        Actor OtherActor = other.gameObject.GetComponentInParent<Actor>();
        if (OtherActor)
        {
            OtherActor.TakeDamage( this, damageAmount, new DamageEventInfo(typeof(ProjectileDamageType)), Owner);
        }
        OnDeath(); 
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }

}
