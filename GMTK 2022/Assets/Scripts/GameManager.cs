using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dice_Manager StepDice;
    public Dice_Manager StableDice;
    public Dice_Manager UnusedDice;

    public int relationship_Stability;
    public int step_DC;

    public void Role(){
      int StepRole = StepDice.Role();
      int StableRole = StableDice.Role();

      if(StepRole >= step_DC) Debug.Log("Step passed");
      else Debug.Log("Step failed");

      relationship_Stability += StableRole;
    }
}
