using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Char
{
    CARROT, POTATO, TURNIP
}

public enum Trait
{
    QUICK, JUMPY, FORGIVING, LIGHT, HEAVY, BRUTAL, HEALTHY, FRAGILE, PACIFIST 
}

[CreateAssetMenu(fileName = "New Player", menuName = "Player/Empty Player")]
public class PlayerType : ScriptableObject
{
    public int health;
    [HideInInspector] public Char charType;
    public float xforce;
    public float yforce;
    public float jumpBuffer;
    public float dampSpeed;
    public float damage;
    [HideInInspector] public Trait trait;
    [HideInInspector] public List<Trait> Inheritable = new List<Trait>();


    
    public void setCharType()
    {
        int num = UnityEngine.Random.Range(0, 2);
        switch(num)
        {
            case 0: charType = Char.CARROT; Debug.Log(charType); break;
            case 1: charType = Char.POTATO; Debug.Log(charType); break;
            case 2: charType = Char.TURNIP; Debug.Log(charType); break;
            default: break;
        }
    }

    public virtual void MainSkill(Char charType)
    {
        
        switch (charType)
        {
            case Char.CARROT: Debug.Log("Laser Eyes!"); break;
            case Char.POTATO: Debug.Log("Invulnurability!"); break;
            case Char.TURNIP: Debug.Log("Tax Evasion!"); break;
            default: break;
        }
    }

    public virtual void MoveSkill()
    {
        int num = UnityEngine.Random.Range(0, 9);
        switch((Trait) num)
        {
            case Trait.QUICK: trait = Trait.QUICK; Debug.Log(trait); xforce = xforce + 3; break;
            case Trait.JUMPY: trait = Trait.JUMPY; Debug.Log(trait); yforce = yforce + 3; break;
            case Trait.FORGIVING: trait = Trait.FORGIVING; Debug.Log(trait); jumpBuffer = jumpBuffer + 0.2f; break;
            case Trait.LIGHT: trait = Trait.LIGHT; Debug.Log(trait); dampSpeed = dampSpeed - 0.2f; break;
            case Trait.HEAVY: trait = Trait.HEAVY; Debug.Log(trait); dampSpeed = dampSpeed * -1; break;
            case Trait.BRUTAL: trait = Trait.BRUTAL; Debug.Log(trait); damage = damage * 2; break;
            case Trait.HEALTHY: trait = Trait.HEALTHY; Debug.Log(trait); health = health + 100; break;
            case Trait.FRAGILE: trait = Trait.FRAGILE; Debug.Log(trait); health = health - 50; break;
            case Trait.PACIFIST: trait = Trait.PACIFIST; Debug.Log(trait); damage = damage * 0; break;
            default: break;
        }
    }

    public virtual void InheritedSkill()
    {
        if(Inheritable.Count > 0)
        {
            int num = UnityEngine.Random.Range(0, Inheritable.Count);
            switch (Inheritable[num])
            {
                case Trait.QUICK: trait = Trait.QUICK; Debug.Log(trait); xforce = xforce + 3; break;
                case Trait.JUMPY: trait = Trait.JUMPY; Debug.Log(trait); yforce = yforce + 3; break;
                case Trait.FORGIVING: trait = Trait.FORGIVING; Debug.Log(trait); jumpBuffer = jumpBuffer + 1f; break;
                case Trait.LIGHT: trait = Trait.LIGHT; Debug.Log(trait); dampSpeed = 1; break;
                case Trait.HEAVY: trait = Trait.HEAVY; Debug.Log(trait); dampSpeed = 0; break;
                case Trait.BRUTAL: trait = Trait.BRUTAL; Debug.Log(trait); damage = damage * 2; break;
                case Trait.HEALTHY: trait = Trait.HEALTHY; Debug.Log(trait); health = health + 100; break;
                case Trait.FRAGILE: trait = Trait.FRAGILE; Debug.Log(trait); health = health - 50; break;
                case Trait.PACIFIST: trait = Trait.PACIFIST; Debug.Log(trait); damage = damage * 0; break;
                default: break;
            }
        }
    }
}
