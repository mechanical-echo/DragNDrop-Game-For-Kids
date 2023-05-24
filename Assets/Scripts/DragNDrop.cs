using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Objects objectScript;			//Script Manager that has Objects script
    CanvasGroup canvasGroup;                //Object's component that will help to change it's appearance
    RectTransform objectRT;                 //location of each object
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();  //get canvasgroup from an object
        objectRT = GetComponent<RectTransform>();   //get recttransform from an object
    }
    public void OnBeginDrag(PointerEventData eventData) 
    {
        objectScript.lastDraggableObject= null;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        objectRT.anchoredPosition += eventData.delta / objectScript.canva.scaleFactor;
    }
    public void OnPointerDown(PointerEventData eventData) { }
    public void OnEndDrag(PointerEventData eventData) {
        objectScript.lastDraggableObject = eventData.pointerDrag;
        canvasGroup.alpha = 1f;
        if (objectScript.rightPlace == false)
        {
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            objectScript.lastDraggableObject = null;
        }
        objectScript.rightPlace = false;
    }
}
