using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathPointHolder : MonoBehaviour {

    public static EnemyPathPointHolder Self;
    public GameObject[] PathPoints;
    public GameObject PlayerSpawnPoint; 

    void Awake () {
        Self = this; 
    }
	
	
}
