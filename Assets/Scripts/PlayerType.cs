using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Char
{
    CARROT
}

[CreateAssetMenu(fileName = "New Player", menuName = "Player/Empty Player")]
public class PlayerType : ScriptableObject, IAbilities
{
    public int health;
    public Char charType;
    public float xforce;
    public float yforce;
    public float jumpBuffer;
    public float dampSpeed;
    public float damage;

    protected IAbilities _abilities;

    public PlayerType(IAbilities abilities) => _abilities = abilities;

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
        Debug.Log("b");
        AbilityDecorator a = new AbilityDecorator(this);
        a.MoveSkill();
    }

    public virtual void InheritedSkill()
    {
        Debug.Log("c");
        AbilityDecorator a = new AbilityDecorator(this);
        a.InheritedSkill();
    }
}
