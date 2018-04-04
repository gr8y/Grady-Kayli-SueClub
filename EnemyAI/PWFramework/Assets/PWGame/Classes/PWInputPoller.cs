using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PW Test Application's Input. 
/// 4 Players Currently Setup. 
/// </summary>
public class PWInputPoller : InputPoller {

    public override InputState GetPlayer1Input()
    {
        InputState IS = InputState.GetBlankState();
        IS.AddAxis("Horizontal", Input.GetAxis("Horizontal"));
        IS.AddAxis("Vertical", Input.GetAxis("Vertical"));
        IS.AddButton("Fire1", Input.GetButtonDown("Fire1"));
        IS.AddButton("Fire2", Input.GetButtonDown("Fire2"));
        IS.AddButton("Fire3", Input.GetButtonDown("Fire3"));
        IS.AddButton("Fire4", Input.GetButtonDown("Fire4"));
        return IS;
    }

    public override InputState GetPlayer2Input()
    {
        InputState IS = InputState.GetBlankState();
        IS.AddAxis("Horizontal", Input.GetAxis("P2Horizontal"));
        IS.AddAxis("Vertical", Input.GetAxis("P2Vertical"));
        IS.AddButton("Fire1", Input.GetButtonDown("P2Fire1"));
        IS.AddButton("Fire2", Input.GetButtonDown("P2Fire2"));
        IS.AddButton("Fire3", Input.GetButtonDown("P2Fire3"));
        IS.AddButton("Fire4", Input.GetButtonDown("P2Fire4"));
        return IS;
    }

    public override InputState GetPlayer3Input()
    {
        InputState IS = InputState.GetBlankState();
        IS.AddAxis("Horizontal", Input.GetAxis("P3Horizontal"));
        IS.AddAxis("Vertical", Input.GetAxis("P3Vertical"));
        IS.AddButton("Fire1", Input.GetButtonDown("P3Fire1"));
        IS.AddButton("Fire2", Input.GetButtonDown("P3Fire2"));
        IS.AddButton("Fire3", Input.GetButtonDown("P3Fire3"));
        IS.AddButton("Fire4", Input.GetButtonDown("P3Fire4"));
        return IS;
    }

    public override InputState GetPlayer4Input()
    {
        InputState IS = InputState.GetBlankState();
        IS.AddAxis("Horizontal", Input.GetAxis("P4Horizontal"));
        IS.AddAxis("Vertical", Input.GetAxis("P4Vertical"));
        IS.AddButton("Fire1", Input.GetButtonDown("P4Fire1"));
        IS.AddButton("Fire2", Input.GetButtonDown("P4Fire2"));
        IS.AddButton("Fire3", Input.GetButtonDown("P4Fire3"));
        IS.AddButton("Fire4", Input.GetButtonDown("P4Fire4"));
        return IS;
    }
}
