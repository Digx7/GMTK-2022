using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

  [SerializeField] private Canvas canvas;

  private RectTransform rectTransform;
  private CanvasGroup canvasGroup;

  private ItemSlot slot;

  public void SetItemSlot (ItemSlot input){
    slot = input;
  }

  private void Awake(){
    rectTransform = GetComponent<RectTransform>();
    canvasGroup = GetComponent<CanvasGroup>();
  }

  public void OnBeginDrag(PointerEventData eventData){
    //Debug.Log("OnDrag");
    canvasGroup.alpha = .6f;
    canvasGroup.blocksRaycasts = false;
  }

  public void OnDrag(PointerEventData eventData){
    //Debug.Log("OnDrag");
    rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    RemovingDie();
  }

  public void OnEndDrag(PointerEventData eventData){
    //Debug.Log("OnEndDrag");
    canvasGroup.alpha = 1f;
    canvasGroup.blocksRaycasts = true;
  }

  public void OnPointerDown(PointerEventData eventData){
    //Debug.Log("OnPointerDown");
  }

  public void OnDrop(PointerEventData eventData){
    //Debug.Log("OnDrop");
  }

  private void RemovingDie(){
    if(slot == null) return;
    if(slot.GetComponent<RectTransform>().anchoredPosition != this.GetComponent<RectTransform>().anchoredPosition){
      slot.OnDiceRemoved.Invoke(this.GetComponent<DiceCard>().die);
      SetItemSlot(null);
    }
  }

}
