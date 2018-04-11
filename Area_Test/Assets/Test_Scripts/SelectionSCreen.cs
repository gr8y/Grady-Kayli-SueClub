using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;



public class SelectionSCreen : MonoBehaviour {

    public GameObject currentObj; //K

    public Sprite[] Gallery;
    public Image DisplayImage;
    public Button NextButton;
    public Button PrevButton;
    public int Index = 0;

    public int CharIndex = 0; //K
    public GameObject[] CharacterSelect;



    public void NextImage()
    {

        Index++;
        CharIndex++; // K
        if (Index >= Gallery.Length)
        {
            Index = 0;

            CharIndex = 0; // K
        }

    }

    public void PrevImage()
    {

        Index--;
        CharIndex--; // K
        if (Index <= -1)
        {
            Index = (Gallery.Length - 1);

            CharIndex = (Gallery.Length - 1); // K
        }

    }

    private void Update()
    {
        DisplayImage.sprite = Gallery[Index];

        currentObj = CharacterSelect[CharIndex];
    }

}
