using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCard : MonoBehaviour
{
    public Dice_SO die;
    public DragDrop dragDrop;

    public void OnChangeInState(){
      if(GlobalEnums.currentStepState == StepState.Start) OnStepStart();
      if(GlobalEnums.currentStepState == StepState.Rolling) OnStepRolling();
      if(GlobalEnums.currentStepState == StepState.End) OnStepEnd();
    }

    public void OnStepStart(){
      dragDrop.interactable = true;
    }

    public void OnStepRolling(){
      dragDrop.interactable = false;
      //play roll animation
    }

    public void OnStepEnd(){
      dragDrop.interactable = false;
      Destroy(this);
    }
}
