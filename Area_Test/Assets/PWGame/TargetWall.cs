using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetWall : Pawn {

    public int WallHealth = 100;
    public Slider SliderHealth;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            WallHealth -= 10;
            SliderHealth.value = WallHealth;
            Debug.Log("Wall Health = " + WallHealth);
        }
    }
}
