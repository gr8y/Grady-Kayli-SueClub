using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HUD Script Class is attached to a Pannel in a Prefab
/// </summary>
public class FrameworkHUD : Actor
{
    public Controller controller;
    public Pawn pawn; 

    /// <summary>
    /// Player Controller Calls this Method to update the Player's HUD
    /// </summary>
    public virtual void UpdateHUD()
    {

    }

    private void LateUpdate()
    {
        UpdateHUD();
    }
}
