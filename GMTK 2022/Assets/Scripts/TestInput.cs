using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestInput : MonoBehaviour
{
    public UnityEvent SpaceBar;

    public void Update(){
      if(Input.GetKeyDown("space")) SpaceBar.Invoke();
    }
}
