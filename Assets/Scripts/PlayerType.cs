using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Char
{
    CARROT
}

[CreateAssetMenu(fileName = "New Player", menuName = "Player/Empty Player")]
public class PlayerType : ScriptableObject
{
    public int health;
    public Char charType;
    public float xforce;
    public float yforce;
    public float jumpBuffer;
    public float dampSpeed;
    public float damage;

    public virtual void MainSkill(Char charType)
    {
        switch (charType)
        {
            case Char.CARROT: Debug.Log("Laser Eyes!"); break;
            default: break;
        }
    }

    public virtual void MoveSkill()
    {
        xforce = xforce + 5;
    }

    public virtual void InheritedSkill()
    {
        yforce = yforce + 4;
    }
}
