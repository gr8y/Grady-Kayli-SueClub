using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathPointHolder : MonoBehaviour {

    public static EnemyPathPointHolder Self;
    public GameObject[] PathPoints;

    void Awake () {
        Self = this; 

    }
	
	
}
