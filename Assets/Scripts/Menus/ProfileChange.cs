using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ProfileChange : MonoBehaviour
{
    [SerializeField] public PlayerType player;

    [SerializeField] public TextMeshPro traitsText;

    void Awake()
    {
        traitsText.text = "";
        foreach(Trait t in player.traits)
        {
            traitsText.text += t.ToString() + " ";
        }
        
    }
}
