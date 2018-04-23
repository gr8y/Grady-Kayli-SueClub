using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PWGame : Game {

    public List<PWPlayerController> PlayerList;
    public List<PWPlayerController> ActivePlayerList;
    public Camera GameCamera;
    public GameObject GameCameraObject;

    public List<Vector3> PawnLocations; 

    public GameObject Testing;

    public float OFD = 15f; // Off Set Distance  

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

    protected void Update()
    {
        // Game Mode controls getting player input. 
        if (IsInGameMap) { Update_GameMap(); }
        else { Update_MainMenu(); }
    }

    protected void Update_MainMenu()
    {
        // Likely not doing anythign here right now... 
    }

    protected void Update_GameMap()
    {
        // Loop through ActivePlayerList and get each PC's Pawn location. Store Location in a list
        PawnLocations.Clear();
        foreach (PWPlayerController pc in ActivePlayerList)
        {
            PawnLocations.Add(pc.PossesedPawn.Location);
        }

        CenterCamera();
        // Then Process where the camera's postion is based on location of the pawns.  
    }


    protected void CenterCamera()
    {

    }

    protected void FixedUpdate_MainMenu()
    {
        foreach (PWPlayerController pc in PlayerList)
        {
            pc.GetInput();
        }
    }

    protected void FixedUpdate_GameMap()
    {
        foreach (PWPlayerController pc in ActivePlayerList)
        {
            pc.GetInput();
        }
    }

    public override GameObject RequestSpawn(Controller CR, GameObject SpawnPreFab)
    {

        if (!SpawnPreFab || !CR)
        {
            LOG_ERROR("GAME: Request Spawn: Missing Controller or Spawn Prefab");
            return null;
        }

        Vector3 SpawnOffset = Vector3.zero;
        // Based on Player number, figure out a spawn offset. 
       
        if (CR.PlayerNumber == 0 ) { SpawnOffset = new Vector3(OFD,  0, OFD); }
        if (CR.PlayerNumber == 1 ) { SpawnOffset = new Vector3(-OFD, 0, OFD); }
        if (CR.PlayerNumber == 2 ) { SpawnOffset = new Vector3(OFD,  0, -OFD); }
        if (CR.PlayerNumber == 3 ) { SpawnOffset = new Vector3(-OFD, 0, -OFD); }


        GameObject NewPawn = Factory(SpawnPreFab, ( SpawnLocation.position + SpawnOffset) , SpawnLocation.rotation, CR);
        if (!NewPawn)
        {
            LOG_ERROR("GAME: Request Spawn: Could not Spawn New Pawn");
            return null;
        }

        CR.PossesPawn(NewPawn);

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

        GameCamera = Camera.main;
        GameCameraObject = GameCamera.gameObject; 

        if (!EnemyPathPointHolder.Self)
        {
            Debug.LogError("No Player Spawn Point!"); 
            return; 
        }

        SpawnLocation = EnemyPathPointHolder.Self.PlayerSpawnPoint.transform;
        //LOG("Found SpawnPoint!");

        foreach(PWPlayerController pc in ActivePlayerList)
        {
            GameObject newpawn =  RequestSpawn(pc, pc.SpawnPreFab);
            if (!newpawn)
            {
                Debug.LogError("Bad PC Spawn Spawn");
                return; 
            }
            //pc.PossesPawn(newpawn);
        }
        // go though Active Player List and Spawn their Player. 
        // call Request spawn on the Controller.

        // set up you need when your game map is loaded. 
        // forexample telling each player controller to find it's pawn. 
    }
       // manage gamecam here :: find center between active players --> then draw out as player branches
    // find 2 farthest apart players then get midpoint
}
