using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*----------------------------------------------------------------------------------------------------
                            Skripts nodrošīnā objektu pārvietošanu
 ----------------------------------------------------------------------------------------------------*/
public class DragNDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Objects objectScript;			//objekts, kuram ir Objects skripts
    CanvasGroup canvasGroup;                //ļauj mainīt objekta izskatu
    RectTransform objectRT;                 //ļauj mainīt objekt pozīciju
    void Start()                            //sākumā ir jādabūt componentus, lai tos izmantot talāk
    {
        canvasGroup = GetComponent<CanvasGroup>();  
        objectRT = GetComponent<RectTransform>();   
    }
    public void OnBeginDrag(PointerEventData eventData) //kad tiek iesākta objekta pārvietošana mainām objekta alfu
    {
        objectScript.lastDraggableObject= null;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)      //kad objekts tiek pārvietots, mainām to pozīciju 
    {
        objectRT.anchoredPosition += eventData.delta / objectScript.canva.scaleFactor;  
    }
    public void OnEndDrag(PointerEventData eventData) { //kad objekts tiek nomests, pārbaudām, vai tas ir pareizā vietā
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
