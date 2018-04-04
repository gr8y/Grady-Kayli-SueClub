using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiningProjectile : Projectile {

    public Vector3 RotateSpeed = Vector3.zero; 

    void Update () {

        gameObject.transform.Rotate(RotateSpeed * Time.deltaTime); 
	}

    /*
    public override void OnDeath()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero; 
        Destroy(gameObject, 0.5f);
    }
    */
}
