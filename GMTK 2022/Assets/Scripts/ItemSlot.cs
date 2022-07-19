using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public Dice_SO_Event OnDiceAdded;
    public Dice_SO_Event OnDiceRemoved;

    public void OnDrop(PointerEventData eventData){
      Debug.Log("OnDrop");
      if (eventData.pointerDrag != null) {
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform> ().anchoredPosition;
        eventData.pointerDrag.GetComponent<DragDrop>().SetItemSlot(this);
        Dice_SO die = eventData.pointerDrag.GetComponent<DiceCard>().die;
        OnDiceAdded.Invoke(die);
      }
    }


}
