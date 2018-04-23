using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePhysics : PWPlayerPawn
{

    // https://answers.unity.com/questions/240557/icyslippery-floor.html

    //private Vector3 moveDir = Vector3.zero;
    //private Vector3 lastMoveDir = Vector3.zero;
    //private float slide = 1.75f;
    //public bool icy = false;

    /*public void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //moveDir = v * camera.forward + h * camera.right;
        float inputMag = Mathf.Min(new Vector3(h, 0, v).sqrMagnitude, 1f);

        if(inputMag > 0.225f)
        {
            lastMoveDir = moveDir;
        }

        if (icy)
        {
            moveDir = lastMoveDir * slide;
        }
        else
        {
            moveDir *= MoveSpeed;
        }

        //controller.Move(moveDir * Time.deltaTime);
    }*/

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ice")
        {
            GetComponent<Collider>().material.dynamicFriction = 0;
        }
    }

}
