using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWPlayerPawn : PWPawn {

    Rigidbody rb;
    public float MoveSpeed = 10f;
    public float RotateSpeed = 180f;
    public float MinVel = .01f;
    public virtual void Start()
    {
        // Add and Set up Rigid Body
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        HP = StartingHP;
    }

    public virtual void FixedUpdate()
    {
        if (rb.velocity.magnitude < MinVel)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public override void Horizontal(float value)
    {
        if(value != 0)
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

    public override void Fire1(bool value)
    {
        // Nothing yet
    }

}
