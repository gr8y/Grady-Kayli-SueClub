using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWGame : Game {

    public List<Controller> PlayerList;
    public List<Controller> ActivePlayerList;
    public Camera GameCamera;

    Transform SpawnLocation;

    public void Start()
    {
        // Temp for testing
        OnEnterGameMap(); 
    }

    public override GameObject RequestSpawn(Controller c, GameObject SpawnPreFab)
    {

        if (!SpawnPreFab || !c)
        {
            LOG_ERROR("GAME: Request Spawn: Missing Controller or Spawn Prefab");
            return null;
        }

        Vector3 SpawnOffset = Vector3.zero;
        // Based on Player number, figure out a spawn offset. 
        Controller CR = GameObject.FindObjectOfType<Controller>();
        if (CR.PlayerNumber == 1)
        {
            //Vector3 SpawnOffset == Vector3.
        }

        GameObject NewPawn = Factory(SpawnPreFab, SpawnLocation.position+ SpawnOffset, SpawnLocation.rotation, c);
        if (!NewPawn)
        {
            LOG_ERROR("GAME: Request Spawn: Could not Spawn New Pawn");
            return null;
        }

        c.PossesPawn(NewPawn);

        return NewPawn;
    }

    public void OnEnterMainMenu()
    {
        // Setup you need when your main menu is loaded

    }

    public void OnEnterGameMap()
    {
        SpawnPoint SP = GameObject.FindObjectOfType<SpawnPoint>();
        if (!SP)
        {
            LOG_ERROR("NO SPAWN POINT IN MAP! BAD BAD BAD");
            return;
        }
        SpawnLocation = SP.Transform;


        // go though Active Player List and Spawn their Player. 
        // call Request spawn on the Controller.

        // set up you need when your game map is loaded. 
        // forexample telling each player controller to find it's pawn. 
    }

    // manage gamecam here :: find center between active players --> then draw out as player branches
    // find 2 farthest apart players then get midpoint
}
