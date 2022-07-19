using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

  public bool interactable;
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
    canvas = GetComponentInParent<Canvas>();
  }

  public void OnBeginDrag(PointerEventData eventData){
    //Debug.Log("OnDrag");
    if(interactable){
      canvasGroup.alpha = .6f;
      canvasGroup.blocksRaycasts = false;
    }
  }

  public void OnDrag(PointerEventData eventData){
    //Debug.Log("OnDrag");
    if(interactable){
      rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
      RemovingDie();
    }
  }

  public void OnEndDrag(PointerEventData eventData){
    //Debug.Log("OnEndDrag");
    if(interactable){
      canvasGroup.alpha = 1f;
      canvasGroup.blocksRaycasts = true;
    }
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
      slot.OnDiceRemoved.Invoke(this.GetComponent<DiceCard>());
      SetItemSlot(null);
    }
  }

}
