using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool interactable = true;
    public DiceCardEvent OnDiceAdded;
    public DiceCardEvent OnDiceRemoved;

    public void OnDrop(PointerEventData eventData){
      if(interactable){
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
          eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform> ().anchoredPosition;
          eventData.pointerDrag.GetComponent<DragDrop>().SetItemSlot(this);
          DiceCard dieCard = eventData.pointerDrag.GetComponent<DiceCard>();
          OnDiceAdded.Invoke(dieCard);
        }
      }
    }

    public void TurnOffInteractable(){
      interactable = false;
    }

    public void TurnOnInteractable(){
      interactable = true;
    }


}
