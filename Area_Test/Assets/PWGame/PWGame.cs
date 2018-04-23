using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PWGame : Game {

    public List<PWPlayerController> PlayerList;
    public List<PWPlayerController> ActivePlayerList;
    public Camera GameCamera;

    public Button JoinButton;

    //Game Mode Variable
    bool IsInGameMap = false;

    Transform SpawnLocation;

    public void Start()
    {
        DontDestroyOnLoad(gameObject); 
    }
     

    public void ToggleJoinP1()
    {
        PlayerList[0].ToggleJoinButton(); 
    }

    public void ToggleJoinP2()
    {
        PlayerList[1].ToggleJoinButton();
    }

    public void ToggleJoinP3()
    {
        PlayerList[2].ToggleJoinButton();
    }

    public void ToggleJoinP4()
    {
        PlayerList[3].ToggleJoinButton();
    }

    public void StartGameButton()
    {
        //LOG("player count " + ActivePlayerList.Count); 
       if (ActivePlayerList.Count > 0)
        {
            SceneManager.LoadScene("Test_Area_Attempt1");
        }
        
        
    }
    protected void FixedUpdate()
    {
        // Game Mode controls getting player input. 
        if (IsInGameMap) {   FixedUpdate_GameMap(); }
        else { FixedUpdate_MainMenu(); }    
    }

    protected void FixedUpdate_MainMenu()
    {
        foreach (PlayerController pc in PlayerList)
        {
            pc.GetInput();
        }
    }

    protected void FixedUpdate_GameMap()
    {
        foreach (PlayerController pc in ActivePlayerList)
        {
            pc.GetInput();
        }
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
        //LOG("MAIN MENU START!");

        IsInGameMap = false;
        // Clear the Active Player List, They need to all rejoin. 
        ActivePlayerList.Clear();

        

    }

    public void OnEnterGameMap()
    {
       // LOG("GAME START!");
        IsInGameMap = true;

        SpawnPoint SP = GameObject.FindObjectOfType<SpawnPoint>();
        if (!SP)
        {
            LOG_ERROR("NO SPAWN POINT IN MAP! BAD BAD BAD");
            return;
        }
        SpawnLocation = SP.Transform;
        //LOG("Found SpawnPoint!");

        // go though Active Player List and Spawn their Player. 
        // call Request spawn on the Controller.

        // set up you need when your game map is loaded. 
        // forexample telling each player controller to find it's pawn. 
    }
    public void ToggleJoinButton(bool enabled)
    {

        JoinButton.gameObject.SetActive(false);

    }

    public void ToggleStartButton()
    {

    }
    // manage gamecam here :: find center between active players --> then draw out as player branches
    // find 2 farthest apart players then get midpoint
}
