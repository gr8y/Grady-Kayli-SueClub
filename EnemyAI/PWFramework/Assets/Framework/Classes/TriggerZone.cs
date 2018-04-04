using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : Info {

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            LOG("The enemy is here");
            Destroy(other.gameObject);
        }
    }
}
