using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PWHUD : FrameworkHUD
{
    public int PlayerNumber = 0;
    public int Shields = 0;
    public int Energy = 0;

   

    public Text PlayerNumberField;
    public Text ShieldsField;
    public Slider ShieldSlider;
    public Text EnergyField;

    public GameObject ActivePanel;
    public GameObject SpectatePanel;

    // Update is called once per frame
    public override void UpdateHUD()
    {
        if (PlayerNumberField)
        {
            PlayerNumberField.text = "Player " + PlayerNumber; 
        }
        if (ShieldsField)
        {
            ShieldsField.text = "Shields: " + Shields;
        }
        if (EnergyField)
        {
            EnergyField.text = "Energy: " + Energy;
        }
        if (ShieldSlider)
        {
            ShieldSlider.value = Shields; 
        }

    }
}
