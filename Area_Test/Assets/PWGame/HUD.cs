using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : FrameworkHUD {

    public int PlayerNumer = 0;
    public int Shields = 0;
    public int Health = 0;

    public Text playerNumberField;
    public Slider healthBar;

    //public GameObject ActivePanel;
    //public GameObject SpectatePanel;

    public override void UpdateHUD()
    {
        if(playerNumberField)
        {
            playerNumberField.text = "Player " + PlayerNumer;
        }
        if(healthBar)
        {
            healthBar.value = Health;
        }
    }
}
