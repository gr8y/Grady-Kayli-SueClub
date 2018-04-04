using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWPlayerController : PlayerController {

    public bool HasJoinedGame = false; 
    public GameObject PlayerPawn; 


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        LogInputStateInfo = false;


        if (!PlayerPawn)
        {
            LOG_ERROR("No PlayerPawn Assigned!");
        }
        PossesPawn(PlayerPawn); 

    }

    protected override void UpdateHUD()
    {
      
    }

    public override void Horizontal(float value)
    {
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Horizontal(value);
        }
    }

    public override void Vertical(float value)
    {
        //LOG(GetPossesedPawn().ToString()); 
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Vertical(value);
        }
    }

    public override void Fire1(bool value)
    {
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Fire1(value);
        }
    }

    public override void Fire2(bool value)
    {
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Fire2(value);
        }
    }

    public override void Fire3(bool value)
    {
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Fire3(value);
        }
    }

    public override void Fire4(bool value)
    {
        
    }

}
