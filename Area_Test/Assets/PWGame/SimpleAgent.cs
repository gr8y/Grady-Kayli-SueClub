using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class SimpleAgent : Pawn {
    
    public GameObject[] PathPoints;
    int PathPointIndex = 0; 
    NavMeshAgent agent;

    public Transform EnemySpawn;

    void Start ()
    {
        agent = gameObject.GetComponent<NavMeshAgent>(); 
        if (!agent)
        {
            Debug.LogError("NO NAV MESH AGENT!"); 
        }

        agent.SetDestination(PathPoints[0].transform.position); 
        
	}
	
	// Update is called once per frame
	void Update () {

        if ( agent.remainingDistance <= 1.0 )
        {
            NextPathPoint(); 
        }	
	}

    void NextPathPoint()
    {
        PathPointIndex++;
       /* if (PathPointIndex == 2)
        {
            
        }*/
        agent.SetDestination(PathPoints[PathPointIndex].transform.position);
    }
}
