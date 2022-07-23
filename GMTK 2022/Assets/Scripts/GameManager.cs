using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ProgressionManager progressionManager;

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

    //private bool end;
    private bool passed;

    private bool rollIsGoing=false;

    public void Role(){
      if(!rollIsGoing){
        rollIsGoing = true;

        GlobalEnums.currentStepState = StepState.Rolling;
        stepStateEventSO.Raise();
        rollingStarted.Raise();

        StepRoll = StepDice.Role();
        StableRoll = StableDice.Role();

        if(StepRoll >= step_DC) {
          Debug.Log("Step passed");
          passed = true;
        }
        else {
           Debug.Log("Step failed");
           passed = false;
        }

        relationship_Stability += StableRoll;
        StartCoroutine("Rolling");
      }
    }

    private void RollStopped(){
      rollIsGoing=false;

      rollingStopped.Raise();

      uiManager.SetStepRollResult(StepRoll);
      uiManager.SetStableRollResult(StableRoll);
      uiManager.SetStableValue(relationship_Stability);

      StartCoroutine("Ending");
    }

    private void End(){
      Debug.Log("Starting End Function");
      GlobalEnums.currentStepState = StepState.End;

      if(passed){
        // you passed
        Debug.Log("Triggereing Passed Node");
        progressionManager.NextNode(0);
      }else{
        // you failed
        Debug.Log("Triggereing Failed Node");
        progressionManager.NextNode(1);
      }

    }

    IEnumerator Rolling(){
      //Debug.Log("Starting Coroutine");
      yield return new WaitForSeconds(3);
      //Debug.Log("Ending Coroutine");
      RollStopped();
    }

    IEnumerator Ending(){
      Debug.Log("starting Ending coroutine");
      yield return new WaitForSeconds(3);
      Debug.Log("ending Ending coroutine");
      End();
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
      int minRange = currentStep.median - currentStep.range;
      int maxRange = currentStep.median + currentStep.range - relationship_Stability;
      if(maxRange < minRange) maxRange = minRange;

      step_DC = Random.Range(minRange,maxRange);
    }
}
