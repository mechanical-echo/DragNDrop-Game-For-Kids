using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SnapPlace : MonoBehaviour, IDropHandler
{
    private float vietasZrot, velkObjZrot, rotacijasStarpiba, xIzmeruStarp, yIzmeruStarp;
    private Vector2 vietasIzm, velkObjIzm;
    
    public Objects objektuSkripts;

    
    public void OnDrop(PointerEventData notikums)
    {
        
        if (notikums.pointerDrag != null)
        {
            
            if (notikums.pointerDrag.tag.Equals(tag))
            {
                vietasZrot = notikums.pointerDrag.GetComponent<RectTransform>().eulerAngles.z;
                velkObjZrot = GetComponent<RectTransform>().eulerAngles.z;
                rotacijasStarpiba = Mathf.Abs(vietasZrot - velkObjZrot);
                vietasIzm = notikums.pointerDrag.GetComponent<RectTransform>().localScale;
                velkObjIzm = GetComponent<RectTransform>().localScale;
                xIzmeruStarp = Mathf.Abs(vietasIzm.x - velkObjIzm.x);
                yIzmeruStarp = Mathf.Abs(vietasIzm.y - velkObjIzm.y);


                if ((rotacijasStarpiba <= 6 || (rotacijasStarpiba >= 354 && rotacijasStarpiba <= 360))
                   && (xIzmeruStarp <= 0.1 && yIzmeruStarp <= 0.1))
                {
                    objektuSkripts.rightPlace = true;
                    notikums.pointerDrag.GetComponent<RectTransform>().anchoredPosition
                                = GetComponent<RectTransform>().anchoredPosition;
                    notikums.pointerDrag.GetComponent<RectTransform>().localRotation
                                = GetComponent<RectTransform>().localRotation;
                    notikums.pointerDrag.GetComponent<RectTransform>().localScale
                    = GetComponent<RectTransform>().localScale;

                    switch (notikums.pointerDrag.tag)
                    {
                        case "Garbage":
                            objektuSkripts.audioSource.PlayOneShot(objektuSkripts.audioClips[1]);
                            break;

                        case "Ambulance":
                            objektuSkripts.audioSource.PlayOneShot(objektuSkripts.audioClips[2]);
                            break;

                        case "Bus":
                            objektuSkripts.audioSource.PlayOneShot(objektuSkripts.audioClips[3]);
                            break;

                        default:
                            Debug.Log("Nedefinēts tags!");
                            break;
                    }

                }

            }
            else
            {
                objektuSkripts.rightPlace = false;
                objektuSkripts.audioSource.PlayOneShot(objektuSkripts.audioClips[0]);

                switch (notikums.pointerDrag.tag)
                {
                    case "Garbage":
                        objektuSkripts.garbage.GetComponent<RectTransform>().localPosition
                                = objektuSkripts.garbCoords;
                        break;

                    case "Ambulance":
                        objektuSkripts.ambulance.GetComponent<RectTransform>().localPosition
                        = objektuSkripts.ambCoords;
                        break;

                    case "Bus":
                        objektuSkripts.bus.GetComponent<RectTransform>().localPosition
                        = objektuSkripts.busCoords;
                        break;

                    default:
                        Debug.Log("Nedefinēts tags!");
                        break;
                }

            }
        }
    }
}