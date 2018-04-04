using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pawn, Can be Possesed by Controller.
/// BY DESIGN, this implementation does not have any default Input methods.
/// Inherit from Pawn into your own class to implement those functions. 
/// </summary>
public class Pawn : Actor {

    public bool IsSpectator = true; 

    /// <summary>
    /// Controler who is in charge of this object. 
    /// </summary>
    protected Controller _controller;

    /// <summary>
    /// READY ONLY, access to the Controller (Player or AI) for this pawn
    /// </summary>
    public Controller controller
    {
        get { return _controller;  }
    }

    /// <summary>
    /// Method access to the Controller (Player or AI) for this pawn
    /// </summary>
    public Controller GetController()
    {
        return _controller; 
    }

    /// <summary>
    /// Sets controller and Owner Variables 
    /// </summary>
    /// <param name="c">Controller to take control of this pawn</param>
    /// <returns></returns>
    public bool Possesed (Controller c)
    {
        _controller = c;
        Owner = c; 
        OnPossession(); 
        return true;
    }

    /// <summary>
    /// Pawn is no longer possessed. Owner is Unchanged. 
    /// Calls OnUnPossession  
    /// </summary>
    public void BecomeUnPossesed()
    {
        OnUnPossession();
        _controller = null;
    }

    /// <summary>
    /// Pawn is no longer possessed. This version resets Owner to null as well.
    /// Calls OnUnPossession
    /// </summary>
    /// <returns>Previous Controller</returns>
    public Controller ForceUnPosses()
    {
        OnUnPossession();
        Controller c = _controller; 
        _controller = null;
        Owner = null; 
     
        return c;
    }

    public virtual void OnPossession()
    {

    }

    public virtual void OnUnPossession()
    {

    }
}
