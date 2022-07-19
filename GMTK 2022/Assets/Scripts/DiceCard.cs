using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceCard : MonoBehaviour
{
    public Dice_SO die;
    public DragDrop dragDrop;
    public Animator animator;
    public TextMeshProUGUI rollResult;

    public int lastRoll;

    public void OnChangeInState(){
      if(GlobalEnums.currentStepState == StepState.Start) OnStepStart();
      if(GlobalEnums.currentStepState == StepState.Rolling) OnStepRolling();
      if(GlobalEnums.currentStepState == StepState.End) OnStepEnd();
    }

    public void OnStepStart(){
      dragDrop.interactable = true;
      animator.speed = 0;

      rollResult.text = "";
    }

    public void OnStepRolling(){
      dragDrop.interactable = false;
      //play roll animation
      animator.speed = 1;
      lastRoll = die.Role();
      rollResult.text = "";
    }

    public void OnRollingStopped(){
      float desired_frame = (lastRoll * 10) - 10;
      float total_frames_in_animation = die.numberOfSides * 10;
      string name = "" + die.numberOfSides;
      animator.Play (name, 0, ( 1f / total_frames_in_animation ) * desired_frame);
      animator.speed = 0.0f;

      rollResult.text = "" + lastRoll;
    }

    public void OnStepEnd(){
      dragDrop.interactable = false;
      Destroy(this);
    }
}
