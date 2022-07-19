using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Manager : MonoBehaviour
{
    public List<DiceCard> Dice;
    public int roleTotal;

    public int Role(){
      roleTotal = 0;
      for(int i=0; i< Dice.Count; ++i){
        roleTotal += Dice[i].lastRoll;
      }
      return roleTotal;
    }

    public int GetRoleTotal(){
      return roleTotal;
    }

    public void AddDice(DiceCard newDie){
      Dice.Add(newDie);
    }

    public void RemoveDice(DiceCard die){
      Dice.Remove(die);
    }
}
