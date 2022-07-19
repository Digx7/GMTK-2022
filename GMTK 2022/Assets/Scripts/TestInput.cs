using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestInput : MonoBehaviour
{
    public UnityEvent SpaceBar;
    public UnityEvent W;
    public UnityEvent A;
    public UnityEvent D;
    public UnityEvent S;

    public void Update(){
      if(Input.GetKeyDown("space")) SpaceBar.Invoke();
      if(Input.GetKeyDown("w")) W.Invoke();
      if(Input.GetKeyDown("a"))A.Invoke();
      if(Input.GetKeyDown("d"))D.Invoke();
      if(Input.GetKeyDown("s"))S.Invoke();

      if(Input.GetKeyDown("p")) PrintCurrentStepState();
    }

    private void PrintCurrentStepState(){
      Debug.Log(GlobalEnums.currentStepState);
    }
}
