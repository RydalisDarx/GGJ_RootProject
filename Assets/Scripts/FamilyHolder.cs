using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Death Record", menuName = "Record/Empty Record")]
public class FamilyHolder : ScriptableObject
{
    public List<PlayerType> players = new List<PlayerType>();
}
