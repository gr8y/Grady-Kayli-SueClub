using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PWPlayerController : PlayerController {

    public bool IgnoreHudError = false; 
    public GameObject ExitPanel;
    

    // Use this for initialization
    protected override void Start () {
        base.Start();
        LogInputStateInfo = false; 
       
	}

    protected override void UpdateHUD()
    {
        if (!HUD && !PossesedPawn)
        {
            if (!IgnoreHudError)
            {
                LOG_ERROR("No Hud or Pawn!");
            }
            return; 
        }

        PWHUD hud = HUD.GetComponent<PWHUD>(); 
        if (!hud)
        {
            if (!IgnoreHudError)
            {
                LOG_ERROR("No Hud Class found");
            }
            return;
        }

        PWPawn pawn = (PWPawn)PossesedPawn; 
        if (!pawn)
        {
            if (!IgnoreHudError)
            {
                LOG_ERROR("Controller doesn't have a PWPawn");
            }
            return; 
        }

        if (PossesedPawn.IsSpectator)
        {
            hud.ActivePanel.SetActive(false);
            hud.SpectatePanel.SetActive(true);
            hud.PlayerNumber = (this.InputPlayerNumber + 1);

        }
        else
        {
            hud.ActivePanel.SetActive(true);
            hud.SpectatePanel.SetActive(false);
            hud.PlayerNumber = (this.InputPlayerNumber + 1);
            hud.Shields = (int)pawn.Shields;
            hud.Energy = (int)pawn.Energy;
        }
        
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
        if (value)
        {
            ExitPanel.SetActive(!ExitPanel.activeSelf);
        }   
    }

}
