using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PWPlayerController : PlayerController {

    public bool HasJoinedGame = false; 
    public GameObject PlayerPawn;
    public GameObject JoinButton;
    public GameObject SelectButtons;
    public GameObject HPBar;
    Text ButtonText;
    SelectionSCreen Buttons; 


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        LogInputStateInfo = false;

        if (!SelectButtons)
        {
            LOG_ERROR("No Select Button Assigned!");
        }
        Buttons = SelectButtons.GetComponent<SelectionSCreen>();
        Buttons.PC = this; 

        if (!JoinButton)
        {
            LOG_ERROR("No Join Button Assigned!");
        }
        ButtonText = JoinButton.GetComponentInChildren<Text>();

        ButtonText.text = "Join"; 

        if (!PlayerPawn)
        {
            LOG_ERROR("No PlayerPawn Assigned!");
        }
        PossesPawn(PlayerPawn); 

    }

    public void ToggleJoinButton()
    {
        // Get our GAme Objrct 
        PWGame pwg = (PWGame)Game.Self;
        if (!pwg)
        {
            Debug.LogError("No Game Object!");
            return;
        }

        // Is Player in Active List already 
        if ( pwg.ActivePlayerList.Contains(this)) 
        {
            // if true, remove them.... 
            pwg.ActivePlayerList.Remove(this);
            ButtonText.text = "Join";
        } else
        {
            // if flase, adds them
            pwg.ActivePlayerList.Add(this);
            ButtonText.text = "Leave";
        }

        //JoinButton.SetActive(false);

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
