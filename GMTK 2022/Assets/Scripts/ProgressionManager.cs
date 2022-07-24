using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public List<ProgessionNode_SO> progression;

    public GameManager gameManager;
    public Card_Manager cardManager;

    public AudioSource goodSFX;
    public AudioSource badSFX;
    public AudioSource neutralSFX;

    private int index = -1;
    private ProgessionNode_SO currentNode;

    public void NextNode(int input = 0){
      index++;
      if(index < progression.Count){
        currentNode = progression[index];
        if(currentNode.type == NodeType.Step) NewStepNode();
        else if(currentNode.type == NodeType.Result) NewResultNode(input);
        else if(currentNode.type == NodeType.Random) NewRandomNode(Random.Range(0,currentNode.cards_data.Count));
      }
    }

    public void Start(){
      NextNode();
    }

    private void NewStepNode(){
      gameManager.currentStep = currentNode.step_data;
      gameManager.LoadNewStep();
      PlaySFX(3);
    }

    private void NewResultNode(int input){
      cardManager.data = currentNode.cards_data[input];
      cardManager.LoadNewCard();
      PlaySFX(input);
    }

    private void NewRandomNode(int input){
      cardManager.data = currentNode.cards_data[input];
      cardManager.LoadNewCard();
      PlaySFX(input);
    }

    private void PlaySFX(int input){
      if(input == 0) goodSFX.Play();
      else if(input == 1) badSFX.Play();
      else neutralSFX.Play();
    }
}
