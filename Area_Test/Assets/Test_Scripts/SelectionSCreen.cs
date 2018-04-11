using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;



public class SelectionSCreen : MonoBehaviour {


    public Sprite[] Gallery;
    public Image DisplayImage;
    public Button NextButton;
    public Button PrevButton;
    public int Index = 0;

    public GameObject[] CharacterSelect;



    public void NextImage()
    {
        // if (Index + 1 < Gallery.Length)
        // {
        //     Index++;
        //  }
        Index++;
        if (Index >= Gallery.Length)
        {
            Index = 0;
        }

    }

    public void PrevImage()
    {
        // if (Index - 1 < 0)
        // {
        //   Index--;
        // }
        Index--;
        if (Index <= -1)
        {
            Index = (Gallery.Length - 1);
        }

    }

    private void Update()
    {
        DisplayImage.sprite = Gallery[Index];
    }

}
