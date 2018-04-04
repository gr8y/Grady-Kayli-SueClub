using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Class manages Game Rules in child classes. 
/// Inherits from Info
/// Spawn Point Management are implemented in this class
/// </summary>
public class Game : Info {

    protected  SpawnPoint[] SpawnPointList;
    protected  int SpawnPointIndex = 0;
    public  GameObject SpawnPointPrefab;
    public GameObject EnemySpawnPrefab;
    public static Game Self;

    public bool UseRandomSpawnPoint = false;


    public virtual void Awake()
    {
        Self = this; 
    }

    public virtual GameObject RequestSpawn(Controller c, GameObject SpawnPreFab)
    {
        if (!SpawnPreFab || !c)
        {
            LOG_ERROR("GAME: Request Spawn: Missing Controller or Spawn Prefab"); 
            return null; 
        }
        
        Transform SpawnLocation; 
         if (UseRandomSpawnPoint)    { SpawnLocation = GetRandomSpawnPoint(); }
         else                        { SpawnLocation = GetNextSpawnPoint(); }

        GameObject NewPawn = Factory(SpawnPreFab, SpawnLocation.position, SpawnLocation.rotation, c); 
        if (!NewPawn)
        {
            LOG_ERROR("GAME: Request Spawn: Could not Spawn New Pawn");
            return null;
        }

        c.PossesPawn(NewPawn); 

        return NewPawn; 
    }

   /* public virtual GameObject RequestEnemySpawn(Controller c, GameObject EnemySpawnPreFab)
    {
        if (!EnemySpawnPreFab || !c)
        {
            LOG_ERROR("GAME: Request Spawn: Missing Controller or Spawn Prefab");
            return null;
        }

        Transform SpawnLocation;
        if (UseRandomSpawnPoint) { SpawnLocation = GetRandomSpawnPoint(); }
        else { SpawnLocation = GetNextSpawnPoint(); }

        GameObject NewPawn = Factory(EnemySpawnPreFab, SpawnLocation.position, SpawnLocation.rotation, c);
        if (!NewPawn)
        {
            LOG_ERROR("GAME: Request Spawn: Could not Spawn New Pawn");
            return null;
        }

        c.PossesPawn(NewPawn);

        return NewPawn;
    }*/



    /// <summary>
    /// Public Access to the Spawn Points Information
    /// Initalizes Spawn points if needed. 
    /// </summary>
    public SpawnPoint[] SpawnPoints
    {
        get
        {
            // Make sure we have spawn points to work with. 
            if (SpawnPointList == null) { RefreshSpawnPoints(); }
            return SpawnPointList;
        }
    }

    /// <summary>
    /// Utility Method for Getting Spawn Point
    /// Provides Spawn Points in order
    /// Initalizes Spawn points if needed. 
    /// </summary>
    /// <returns>Spawn Point Transform</returns>
    public Transform GetNextSpawnPoint()
    {
        // Make sure we have spawn points to work with. 
        if (SpawnPointList == null) { RefreshSpawnPoints(); }

        Transform Spawn = SpawnPointList[SpawnPointIndex].Transform;

        SpawnPointIndex++; 
        if (SpawnPointIndex >= SpawnPointList.Length) { SpawnPointIndex = 0;  }

        return Spawn; 
    }

    /// <summary>
    /// Utility Method for Getting Spawn Point
    /// Provides Spawn Points in random order using Unity's Random Class
    /// Initalizes Spawn points if needed.
    /// </summary>
    /// <returns>Spawn Point Transform</returns>
    public Transform GetRandomSpawnPoint()
    {
        // Make sure we have spawn points to work with. 
        if (SpawnPointList == null) { RefreshSpawnPoints(); }
       
        int index = (int)(Random.value * SpawnPointList.Length);
        // Unity's Random is 0.0 to 1.0, inclusive on both ends. 
        // So if value returned is 1, we should set it to zero... 
        if (SpawnPointList.Length == index) { index = 0;   }
       
       
        return SpawnPointList[index].Transform;
    }
    
    /// <summary>
    /// Resets the Spawn Point list. 
    /// Called by other functions if spawn point list hadn't been initalized. 
    /// </summary>
    public void RefreshSpawnPoints()
    {
        SpawnPointList = GetSpawnPoints();
    }

    /// <summary>
    /// Gets Spawn Points, Creates one at Origin If none exists. 
    /// Used by other functions to initalize spawn point list. 
    /// DOES NOT initalize spawn point list by itself.
    /// </summary>
    /// <returns>Array of Spawn Points</returns>
    public SpawnPoint[] GetSpawnPoints()
    {
        
        SpawnPoint[] SP = GameObject.FindObjectsOfType<SpawnPoint>();
        
        if ( SP.Length == 0)
        {
            
            if (SpawnPointPrefab)
            {
                LOG("GENERATED SPAWN POINT AT ORIGIN");
                
                Factory(SpawnPointPrefab, Vector3.zero, new Quaternion());
                SP = GetSpawnPoints(); 
            } else
            {
                LOG("Could not Generate Spawn Point.");
            }

        }
        return SP; 
    }
}
