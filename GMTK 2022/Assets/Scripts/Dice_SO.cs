using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDice", menuName = "ScriptableObjects/Dice", order = 1)]
public class Dice_SO : ScriptableObject
{
  public int numberOfSides;

  private int lastRole;
  public int LastRole {get{return lastRole;}}

  public int Role(){
    lastRole = Random.Range(1,numberOfSides);
    return LastRole;
  }

  public int GetLastRole(){
    return LastRole;
  }
}
