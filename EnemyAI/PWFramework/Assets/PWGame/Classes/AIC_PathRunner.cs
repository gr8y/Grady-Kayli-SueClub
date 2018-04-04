using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIC_PathRunner : AIController {

    public GameObject MyPawn;

    public GameObject[] PathPoints;
    int PathPointIndex = 0;

    protected override void DefaultState_Enter()
    {
        Pawn p = MyPawn.GetComponent<Pawn>(); 
        if (!p)
        { return;  }

        PossesPawn(p); 

        agent.SetDestination(PathPoints[0].transform.position);
    }

    protected override void DefaultState_Think()
    {
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

}
