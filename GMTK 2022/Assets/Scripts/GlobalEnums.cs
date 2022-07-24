using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StepState {Start,Rolling,End}

public enum CardType {ToTitle,ToNext,ToRestart}

public enum NodeType {Step,Result,Random}

public static class GlobalEnums
{
  public static StepState currentStepState;
}
