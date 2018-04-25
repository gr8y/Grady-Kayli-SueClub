using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Info {

    public GameObject Wall;
    public ParticleSystem Mist;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            Destroy(Wall);
            Destroy(Mist);
        }
    }
}
