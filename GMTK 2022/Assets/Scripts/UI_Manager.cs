using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public GameObject artWorkSlot;
    private Image artWork;

    public TextMeshProUGUI stepRollResult;
    public TextMeshProUGUI stableRollResult;
    public TextMeshProUGUI stableValue;

    public void Awake(){
      artWork = artWorkSlot.GetComponent<Image>();
    }

    public void LoadNewStep(Step_SO newStep){
      title.text = newStep.title;
      artWork.sprite = newStep.artWork;
    }
}
