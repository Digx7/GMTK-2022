using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNode", menuName = "ScriptableObjects/Node", order = 1)]
public class ProgessionNode_SO : ScriptableObject
{
  public NodeType type;

  public Step_SO step_data;

  public List<Card_SO> cards_data;
}
