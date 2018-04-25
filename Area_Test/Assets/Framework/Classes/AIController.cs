using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    /// <summary>
    /// Assigned NavMeshAgent to Pawn
    /// </summary>
    protected NavMeshAgent agent;
    public Transform EnemySpawn;
    int enemyCount = 1;

    protected override void Start()
    {
        base.Start();
        IsAI = true;
        LogPossessionFailures = true;
        DefaultState_Enter();
        Invoke("Spawn", 2);
    }

    protected virtual void FixedUpdate()
    {
        DefaultState_Think();
        
    }

    void Spawn()
    {
        RequestSpawnAt(EnemySpawn);
        enemyCount++;
        Invoke("Spawn", 2);
        
    }

    public override bool PossesPawn(Pawn p)
    {
        if (!base.PossesPawn(p))
        {
            // Posession failure 
            return false;
        }

        /*agent = p.gameObject.AddComponent<NavMeshAgent>();
        if (!agent)
        {
            LOG_ERROR("Could not Add NavMeshAgent to Pawn");
            return false;
        }*/

        return true;
    }

    public override bool UnPossesPawn(Pawn p)
    {
        if (agent)
        {
            agent.enabled = false;
        }

        return base.UnPossesPawn(p);

    }

    protected virtual void DefaultState_Enter()
    {

    }

    protected virtual void DefaultState_Think()
    {
        
    }


}
