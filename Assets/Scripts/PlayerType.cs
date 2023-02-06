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
    public Char charType;
    public float xforce;
    public float yforce;
    public float jumpBuffer;
    public float dampSpeed;
    public float damage;
    public List<Trait> traits = new List<Trait>();
    public List<Trait> Inheritable = new List<Trait>();


    
    public void setCharType()
    {
        int num = UnityEngine.Random.Range(0, 2);
        switch(num)
        {
            case 0: charType = Char.CARROT; break;
            case 1: charType = Char.POTATO; break;
            case 2: charType = Char.TURNIP; break;
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

    public virtual void GenerateSkills()
    {
        MoveSkill();
        InheritedSkill();
    }

    public virtual void ApplyPassives()
    {
        for (int i = 0; i < traits.Count; i++)
        {
            switch(traits[i])
            {
                case Trait.QUICK: xforce = xforce + 3; break;
                case Trait.JUMPY: yforce = yforce + 3; break;
                case Trait.FORGIVING: jumpBuffer = jumpBuffer + 0.2f; break;
                case Trait.LIGHT: dampSpeed = dampSpeed - 0.2f; break;
                case Trait.HEAVY: dampSpeed = dampSpeed * -1; break;
                case Trait.BRUTAL: damage = damage * 2; break;
                case Trait.HEALTHY: health = health * 2; break;
                case Trait.FRAGILE: health = health / 2; break;
                case Trait.PACIFIST: damage = 1; break;
                default: break;
            }
        }
    }

    public virtual void MoveSkill()
    {
        int num = UnityEngine.Random.Range(0, 9);
        switch((Trait) num)
        {
            case Trait.QUICK: traits.Add(Trait.QUICK); break;
            case Trait.JUMPY: traits.Add(Trait.JUMPY); break;
            case Trait.FORGIVING: traits.Add(Trait.FORGIVING); break;
            case Trait.LIGHT: traits.Add(Trait.LIGHT); break;
            case Trait.HEAVY: traits.Add(Trait.HEAVY); break;
            case Trait.BRUTAL: traits.Add(Trait.BRUTAL); break;
            case Trait.HEALTHY: traits.Add(Trait.HEALTHY); break;
            case Trait.FRAGILE: traits.Add(Trait.FRAGILE); break;
            case Trait.PACIFIST: traits.Add(Trait.PACIFIST); break;
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
                case Trait.QUICK: traits.Add(Trait.QUICK); break;
                case Trait.JUMPY: traits.Add(Trait.JUMPY); break;
                case Trait.FORGIVING: traits.Add(Trait.FORGIVING); break;
                case Trait.LIGHT: traits.Add(Trait.LIGHT); break;
                case Trait.HEAVY: traits.Add(Trait.HEAVY); break;
                case Trait.BRUTAL: traits.Add(Trait.BRUTAL); break;
                case Trait.HEALTHY: traits.Add(Trait.HEALTHY); break;
                case Trait.FRAGILE: traits.Add(Trait.FRAGILE); break;
                case Trait.PACIFIST: traits.Add(Trait.PACIFIST); break;
                default: break;
            }
        }
    }

    public void DeathInherit(PlayerType type)
    {
        if (!Inheritable.Contains(type.traits[0]))
        {
            Inheritable.Add(type.traits[0]);
        }
    }
}
