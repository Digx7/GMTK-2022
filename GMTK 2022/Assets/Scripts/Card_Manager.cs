using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card_Manager : MonoBehaviour
{
    public ProgressionManager progressionManager;
    public LoadAScene sceneLoader;

    public Card_SO data;
    public GameObject UI_Head;

    public Image artWork;
    public TextMeshProUGUI text;
    public Button button;

    public IntEvent CardValue;

    public void SetActive(){
      UI_Head.SetActive(true);
    }

    public void SetInActive(){
      UI_Head.SetActive(false);
    }

    public void LoadNewCard(){
      SetActive();

      artWork.sprite = data.artWork;
      text.text = data.text;
      button.onClick.RemoveAllListeners();

      if(data.type == CardType.ToTitle){
        button.onClick.AddListener(OnToTitle);
        button.GetComponentInChildren<TextMeshProUGUI>().text = "To Title";
      }else if(data.type == CardType.ToNext){
        button.onClick.AddListener(OnToNext);
        button.GetComponentInChildren<TextMeshProUGUI>().text = "To Next";
      }else if(data.type == CardType.ToRestart){
        button.onClick.AddListener(OnRestart);
        button.GetComponentInChildren<TextMeshProUGUI>().text = "Try Again";
      }

      if(data.value != 0) CardValue.Invoke(data.value);
    }

    public void OnToTitle(){
      Debug.Log("OnToTitle");
      sceneLoader.LoadScene("MainMenuScene");
    }

    public void OnRestart(){
      Debug.Log("OnToTitle");
      sceneLoader.LoadScene("GameScene");
    }

    public void OnToNext(){
      SetInActive();
      Debug.Log("OnToNext");
      progressionManager.NextNode(0);
    }
}
