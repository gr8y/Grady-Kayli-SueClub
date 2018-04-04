using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyPawn : PWPawn {
    
    public GameObject[] PathPoints;
    int PathPointIndex = 0;
    int damageAmount = 10;
    NavMeshAgent agent;

    //public GameObject player;

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

        if (agent.remainingDistance <= 1.0)
        {
            NextPathPoint(); 
        }	
	}

    void NextPathPoint()
    {
        PathPointIndex++;
        if (PathPointIndex >= PathPoints.Length)
        {
            agent.isStopped = true;
            PathPointIndex = 0;
        }
        agent.SetDestination(PathPoints[PathPointIndex].transform.position);
    }

    protected override bool ProcessDamage(Actor Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        Shields -= Value;
        LOG(ActorName + " HP: " + Shields);

        if (Shields <= 0)
        {
            controller.RequestSpawnAt(EnemySpawn);
            Destroy(gameObject);
        }

        return base.ProcessDamage(Source, Value, EventInfo, Instigator);

    }
}
