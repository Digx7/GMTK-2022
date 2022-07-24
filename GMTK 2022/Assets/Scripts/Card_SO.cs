using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Card", order = 1)]
public class Card_SO : ScriptableObject
{
  public CardType type;
  public Sprite artWork;

  [TextArea]
  public string text;

  public int value;
}
