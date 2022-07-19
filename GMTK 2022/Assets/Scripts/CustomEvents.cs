using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomEvents : MonoBehaviour
{
}

[System.Serializable]
public class Dice_SO_Event : UnityEvent<Dice_SO>
{}

[System.Serializable]
public class DiceCardEvent : UnityEvent<DiceCard>
{}

[System.Serializable]
public class IntEvent : UnityEvent<int>
{}
