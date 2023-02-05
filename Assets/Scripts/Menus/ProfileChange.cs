using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ProfileChange : MonoBehaviour
{
    [SerializeField] public PlayerType playerProperties;

    [SerializeField] public TextMeshPro traitsText;

    public Action OnPassive;

    void Awake()
    {
        traitsText.text = playerProperties.trait.ToString();
    }

    //Instantiates PlayerType for the sake of testing 
    public void GetCharacterStatistics(PlayerType playerProperties)
    {
        PlayerType type = Instantiate(playerProperties);
        OnPassive += playerProperties.setCharType;
        OnPassive += type.MoveSkill;
        OnPassive += type.InheritedSkill;
        OnPassive.Invoke();
        OnPassive -= playerProperties.setCharType;
        OnPassive -= type.MoveSkill;
        OnPassive -= type.InheritedSkill;
    }

}
