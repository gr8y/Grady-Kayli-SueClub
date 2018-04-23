using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsGameMap : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        PWGame pwg = (PWGame)Game.Self;
        if (!pwg)
        {
            Debug.LogError("No Game Object!");
            return;
        }
        pwg.OnEnterGameMap(); 
    }
}

