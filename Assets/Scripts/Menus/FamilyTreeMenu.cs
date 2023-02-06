using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FamilyTreeMenu : MonoBehaviour
{
    [SerializeField] public PlayerType playerProperties;
    
    [HideInInspector] private GameObject[] portraitLocations;
    [HideInInspector] private Transform ancestorPortrait;

    [SerializeField] private GameObject[] portraits;
    [SerializeField] private GameObject familyParent;

    public Action OnPassive;

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckFirstDeath()
    {
        if (GameObject.FindWithTag("Ancestor") == null)
        {
            return false;
        }

        return true;
        
    }

    public void FillVacantGrave()
    {
        if (CheckFirstDeath())
        {
            ancestorPortrait = GameObject.FindWithTag("Ancestor").transform;

            Destroy(GameObject.FindWithTag("Ancestor")); //Removes the Object for future checks
        } else
        {
            ancestorPortrait = GameObject.FindWithTag("Eulogy").transform;

            Destroy(GameObject.FindWithTag("Eulogy")); //Removes the Object for future checks
        }

        switch (playerProperties.charType)
        {
            case Char.CARROT:
                Instantiate(portraits[0], ancestorPortrait.transform.position, ancestorPortrait.transform.rotation, familyParent.transform);
                break;
            case Char.POTATO:
                Instantiate(portraits[1], ancestorPortrait.transform.position, ancestorPortrait.transform.rotation, familyParent.transform);
                break;
            case Char.TURNIP:
                Instantiate(portraits[2], ancestorPortrait.transform.position, ancestorPortrait.transform.rotation, familyParent.transform);
                break;
        }

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
