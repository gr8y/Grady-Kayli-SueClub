using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SimpleAgent : Pawn {
    
    public GameObject[] PathPoints;
    int PathPointIndex = 0; 
    NavMeshAgent agent;

    public ParticleSystem Explosion;
    float time = 2;
    public int damageAmount = 10;
    public Transform EnemySpawn;
    public int EnemyHealth = 100;

    void Start ()
    {

        if (!EnemyPathPointHolder.Self)
        {
            Debug.LogError("No Path Point Holder in Scene! BAD! BAD! BAD! BAD!"); 
        }
        PathPoints = EnemyPathPointHolder.Self.PathPoints; 

        Explosion.Stop();
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
        if (PathPointIndex >= PathPoints.Length)
        {
            Explosion.gameObject.SetActive(true);
            Invoke("OnDeath", 0.5f);
        }
        else
        {
            agent.SetDestination(PathPoints[PathPointIndex].transform.position);
        }
    }

    void OnDeath()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            Actor OtherActor = other.gameObject.GetComponentInParent<Actor>();
            if (OtherActor)
            {
                OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(EnemyDamageType)), Owner);
            }
        }

        if(other.gameObject.tag == "TargetWall")
        {
            Actor OtherActor = other.gameObject.GetComponentInParent<Actor>();
            if (OtherActor)
            {
                OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(EnemyDamageType)), Owner);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Actor OtherActor = other.gameObject.GetComponentInParent<Actor>();
            if (OtherActor)
            {
                OtherActor.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(EnemyDamageType)), Owner);
            }
        }
    }
}
