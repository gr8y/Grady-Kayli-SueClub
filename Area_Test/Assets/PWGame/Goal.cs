using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Info {

    public GameObject enemySpawner;
    public GameObject youWinPanel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            Debug.Log("You win!");
            youWinPanel.SetActive(true);
           // DestroyObject(enemySpawner);
        }
    }
}
