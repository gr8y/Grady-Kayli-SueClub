﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWPlayerPawn : PWPawn {

    bool PuzzleZone = false;

    Rigidbody rb;
    public float MoveSpeed = 10f;
    public float RotateSpeed = 180f;
    public float MinVelocity = .01f;
    public float SlipSpeed = 15f;

    public float Deadzone = .1f; 
    //public Transform ProjectileSpawn;
    //public GameObject Projectile1;
    //public GameObject Projectile2;
    //GameObject currentProjectile;

    public virtual void Start()
    {
        IsSpectator = false;

        // Add and Set up Rigid Body
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        //currentProjectile = Projectile1;

    }

    protected override bool ProcessDamage(Actor Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        HP -= Value;
        LOG(ActorName + " HP: " + HP);

        if (HP <= 0)
        {
            controller.RequestSpectate();
            Destroy(gameObject);
        }

        return base.ProcessDamage(Source, Value, EventInfo, Instigator);

    }

    public override void OnUnPossession()
    {
        IgnoresDamage = true;
    }

    public virtual void FixedUpdate()
    {
        if (rb.velocity.magnitude < Deadzone)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public override void Horizontal(float value)
    {
        if (value != 0)
        {
            if (PuzzleZone != true)
            {
                Vector3 speed = rb.velocity; 
                speed.x = MoveSpeed * value;
                rb.velocity = speed; 
               
            }
        }
    }

    public override void Vertical(float value)
    {
        if (value != 0)
        {
            if (PuzzleZone != true)
            {
                Vector3 speed = rb.velocity;
                speed.z = -MoveSpeed * value;
                rb.velocity = speed;

            }
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "MovePlane")
        {
            PuzzleZone = true;
            if (Input.GetKeyDown("d"))
            {
                rb.velocity = transform.right * SlipSpeed;
            }
            else if (Input.GetKeyDown("a"))
            {
                rb.velocity = transform.right * -SlipSpeed;
            }
            else if (Input.GetKeyDown("w"))
            {
                rb.velocity = transform.forward * SlipSpeed;
            }
            else if (Input.GetKeyDown("s"))
            {
                rb.velocity = transform.forward * -SlipSpeed;
            }
        }
    }

    /*public override void Fire1(bool value)
    {
        if (value)
        {
            // Fire Projectile
            //  Factory(currentProjectile, ProjectileSpawn.position, ProjectileSpawn.rotation, controller);

        }
    }

    public override void Fire2(bool value)
    {
        if (value)
        {
            // Set Current Projectile to Prijectile 1
            currentProjectile = Projectile1;
        }
    }

    public override void Fire3(bool value)
    {
        if (value)
        {
            // Set Current Projectile to Prijectile 2
            currentProjectile = Projectile2;
        }
    }*/
}
