using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dice_Manager StepDice;
    public Dice_Manager StableDice;

    public int relationship_Stability;
    public int step_DC;

    public Step_SO currentStep;
    public UI_Manager uiManager;
    public Event_SO stepStateEventSO;
    public UISpawner diceCardSpawner;

    public void Role(){
      GlobalEnums.currentStepState = StepState.Rolling;
      stepStateEventSO.Raise();

      int StepRole = StepDice.Role();
      int StableRole = StableDice.Role();

      if(StepRole >= step_DC) Debug.Log("Step passed");
      else Debug.Log("Step failed");

      relationship_Stability += StableRole;

      uiManager.SetStepRollResult(StepRole);
      uiManager.SetStableRollResult(StableRole);
      uiManager.SetStableValue(relationship_Stability);
    }


    public void LoadNewStep(){
      //update UI
      //-- set title
      //-- set image
      uiManager.LoadNewStep(currentStep);

      //Make new dice cards
      //-- need to clear old ones
      //-- need to generate random amount of new ones
      diceCardSpawner.Spawn();
      GlobalEnums.currentStepState = StepState.Start;
      stepStateEventSO.Raise();

      //Set DC
      //-- Should be random but influenced by relationship_Stability
      step_DC = Random.Range(5,20);
      step_DC -=relationship_Stability;
    }
}
