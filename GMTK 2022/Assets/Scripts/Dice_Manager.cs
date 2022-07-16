using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Manager : MonoBehaviour
{
    public List<Dice_SO> Dice;
    public int roleTotal;

    public int Role(){
      roleTotal = 0;
      for(int i=0; i< Dice.Count; ++i){
        roleTotal += Dice[i].Role();
      }
      return roleTotal;
    }

    public int GetRoleTotal(){
      return roleTotal;
    }

    public void AddDice(Dice_SO newDie){
      Dice.Add(newDie);
    }

    public Dice_SO RemoveDice(int index){
      Dice_SO output = Dice[index];
      Dice.RemoveAt(index);
      return output;
    }
}
