using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWPlayerPawn : PWPawn {

    Rigidbody rb;
    public float MoveSpeed = 10f;
    public float RotateSpeed = 180f;
    public float MinVelocity = .01f;

    //public Transform ProjectileSpawn;
    //public GameObject Projectile1;
    //public GameObject Projectile2;
    //GameObject currentProjectile;

    public virtual void Start()
    {
        IsSpectator = false;

        // Add and Set up Rigid Body
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
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
        if (rb.velocity.magnitude < MinVelocity)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public override void Horizontal(float value)
    {
        if (value != 0)
        {
            gameObject.transform.Rotate(0, (RotateSpeed * value * Time.fixedDeltaTime), 0);
        }
    }

    public override void Vertical(float value)
    {
        if (value != 0)
        {
            rb.velocity = gameObject.transform.forward * MoveSpeed * value;
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
