using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages player input on a per player basis. 
/// This class is used by the PlayerControler class to provide Input information. 
/// Inherit this class to define player inputs. Support for all 16 players in Unity Supported. 
/// An Example for Player 1 is provided in this class. 
/// </summary>
public class InputPoller : Info {

    /// <summary>
    /// Internal Static Reference 
    /// </summary>
    protected static InputPoller _Self;

    /// <summary>
    /// Public Interface to Applications's Single Reference of this class. 
    /// </summary>
    public static InputPoller Self
    {
        get { return _Self; } 
    }

    /// <summary>
    /// Initalizes the Sington Reference. 
    /// </summary>
    private void Awake()
    {
        if (_Self)
        {
            Debug.LogError("Multiple Input Poller Classes Exist. This is a singleton object and only one should exist EVER.");
            return; 
        }
        _Self = this; 
    }

    public virtual InputState GetPlayerInput(int PlayerNumber)
    {
        if (PlayerNumber == 0) { return GetPlayer1Input(); }
        if (PlayerNumber == 1) { return GetPlayer2Input(); }
        if (PlayerNumber == 2) { return GetPlayer3Input(); }
        if (PlayerNumber == 3) { return GetPlayer4Input(); }

        if (PlayerNumber == 4) { return GetPlayer5Input(); }
        if (PlayerNumber == 5) { return GetPlayer6Input(); }
        if (PlayerNumber == 6) { return GetPlayer7Input(); }
        if (PlayerNumber == 7) { return GetPlayer8Input(); }

        if (PlayerNumber == 8) { return GetPlayer9Input(); }
        if (PlayerNumber == 9) { return GetPlayer10Input(); }
        if (PlayerNumber == 10) { return GetPlayer11Input(); }
        if (PlayerNumber == 11) { return GetPlayer12Input(); }

        if (PlayerNumber == 12) { return GetPlayer13Input(); }
        if (PlayerNumber == 13) { return GetPlayer14Input(); }
        if (PlayerNumber == 14) { return GetPlayer15Input(); }
        if (PlayerNumber == 15) { return GetPlayer16Input(); }


        // Error Check... What the heck player did you give me?

        return new InputState();
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer1Input()
    {
        // Example Input binding. 
        InputState IS = InputState.GetBlankState();
        IS.AddAxis("Horizontal", Input.GetAxis("Horizontal"));
        IS.AddAxis("Vertical", Input.GetAxis("Vertical"));
        IS.AddButton("Fire1", Input.GetButton("Fire1"));
        IS.AddButton("Fire2", Input.GetButton("Fire2"));
        IS.AddButton("Fire3", Input.GetButton("Fire3"));
        IS.AddButton("Fire4", Input.GetButton("Fire4"));
        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer2Input()
    {
        InputState IS = InputState.GetBlankState();
        
        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer3Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer4Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer5Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer6Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer7Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer8Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer9Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer10Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer11Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer12Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer13Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer14Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer15Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputState GetPlayer16Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

}

