using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStep", menuName = "ScriptableObjects/Step", order = 1)]
public class Step_SO : ScriptableObject
{
  public string title;
  public Sprite artWork;
}
