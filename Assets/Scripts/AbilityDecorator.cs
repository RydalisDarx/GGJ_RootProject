using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDecorator : PlayerType
{
    public AbilityDecorator(IAbilities abilities) : base(abilities) => _abilities = abilities;

    public override void MoveSkill()
    {
        xforce = xforce + 5;
    }

    public override void InheritedSkill()
    {
        yforce = yforce + 5;
    }

}
