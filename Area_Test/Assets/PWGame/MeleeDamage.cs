using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : Actor
{
    public float damageAmount = 10.0f;
    void OnTriggerEnter(Collider other)
    {
        Actor OtherActor = other.gameObject.GetComponentInParent<Actor>();
        if (OtherActor)
        {
            OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(MeleeDamageType)), Owner);
        }
       
    }
}
