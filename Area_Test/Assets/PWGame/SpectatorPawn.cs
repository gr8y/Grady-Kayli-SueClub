using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorPawn : PWPawn {

    public override void Fire1(bool value)
    {
        if (value)
        {
            controller.RequestSpawn(); 
        
        }
    }
}
