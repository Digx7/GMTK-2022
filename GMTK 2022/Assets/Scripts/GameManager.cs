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

    public Event_SO rollingStarted;
    public Event_SO rollingStopped;

    private int StepRoll;
    private int StableRoll;

    public void Role(){
      GlobalEnums.currentStepState = StepState.Rolling;
      stepStateEventSO.Raise();
      rollingStarted.Raise();

      StepRoll = StepDice.Role();
      StableRoll = StableDice.Role();

      if(StepRoll >= step_DC) Debug.Log("Step passed");
      else Debug.Log("Step failed");

      relationship_Stability += StableRoll;
      StartCoroutine("Rolling");
    }

    private void RollStopped(){
      rollingStopped.Raise();

      uiManager.SetStepRollResult(StepRoll);
      uiManager.SetStableRollResult(StableRoll);
      uiManager.SetStableValue(relationship_Stability);
    }

    IEnumerator Rolling(){
      Debug.Log("Starting Coroutine");
      yield return new WaitForSeconds(3);
      Debug.Log("Ending Coroutine");
      RollStopped();
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
