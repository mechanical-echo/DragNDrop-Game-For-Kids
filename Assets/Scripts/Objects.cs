using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Objects : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Objects objectScript;			//Save pointer uz Objects script
    CanvasGroup canvasGroup;				//
	RectTransform objectRT;					//location
	void Start()
	{
		canvasGroup = GetComponent<CanvasGroup>();	//get canvasgroup from an object
		objectRT = GetComponent<RectTransform>();	//get recttransform from an object
	}
	public void OnPointerDown(PointerEventData eventData) { }
	public void OnBeginDrag(PointerEventData eventData) { }
	public void OnDrag(PointerEventData eventData) { }
	public void OnEndDrag(PointerEventData eventData) { }
}
