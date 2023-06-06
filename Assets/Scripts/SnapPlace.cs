using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*----------------------------------------------------------------------------------------------------
                Šīs skripts ļauj spēlētājam nomest mašīnu pareizajā vieta vai nepareizājā vietā
 ----------------------------------------------------------------------------------------------------*/
public class SnapPlace : MonoBehaviour, IDropHandler
{
    private float z_rot_place, z_rot_obj, rot_diff, x_scale_diff, y_scale_diff;         //pozicijas un rotacijas mainīgie
    private Vector2 scale_place, scale_obj;                                             //izmēra mainīgie
    public Win _win;                                                                    //objekts, kas satur skriptu Win
    public Objects _object;                                                             //objekts, kas satur skriptu Objects

    public void OnDrop(PointerEventData _event)         //kad objekts ir nomests
    {

        if (_event.pointerDrag != null)                 //ja velkamais objekts nav null
        {

            if (_event.pointerDrag.tag.Equals(tag))     //ja tā tags sakrīt ar vietas tagu
            {
                z_rot_place = _event.pointerDrag.GetComponent<RectTransform>().eulerAngles.z;       //vietas rotācija
                z_rot_obj = GetComponent<RectTransform>().eulerAngles.z;                            //mašīnas rotācija

                rot_diff = Mathf.Abs(z_rot_place - z_rot_obj);                                      //cik ir liela rotācijas strapība 
                
                scale_place = _event.pointerDrag.GetComponent<RectTransform>().localScale;          //vietas izmērs
                scale_obj = GetComponent<RectTransform>().localScale;                               //mašīnas izmērs
                
                x_scale_diff = Mathf.Abs(scale_place.x - scale_obj.x);                              //garuma starpība
                y_scale_diff = Mathf.Abs(scale_place.y - scale_obj.y);                              //platuma starpība

                
                
                if ((rot_diff <= 6 || (rot_diff >= 354 && rot_diff <= 360)) 
                    && 
                    (x_scale_diff <= 0.1 && y_scale_diff <= 0.1))                                   //ja starpības nav kritiski lielas
                {                                                                                   

                    _object.rightPlace = true;                                                      //mašīna ir nolikta pareizājā vietā

                    _event.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;//mašīna kļūst tāda paša izmērā un rotācijā kā tā vietā
                    _event.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;
                    _event.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;

                    Debug.Log("LOG : Snapping Object");

                    _win.amount_obj++;                                                               //atzimējam to, ka vēl viena mašīna ir ielikta pareizajā vietā
                    if (_win.amount_obj == 12)                                                       //ja skaits ir vienāds ar kopējo mašīnu skaitu, beidzām spēli
                    {
                        _win.endGame();
                    }
                    
                    Debug.Log("LOG : Object Amount = " + _win.amount_obj);                           
                    
                    int which = -1;                                                                  //skaņas kārtas numurs
                    switch (_event.pointerDrag.tag)                                                  //salīdzinām tagu un startējam atbilstošo skaņu
                    {
                        case "Ambulance":
                            which = 0;
                            break;
                        case "B2":
                            which = 1;
                            break;
                        case "Bus":
                            which = 2;
                            break;
                        case "Cement truck":
                            which = 3;
                            break;
                        case "E46":
                            which = 4;
                            break;
                        case "Escavator":
                            which = 5;
                            break;
                        case "Firefighters":
                            which = 6;
                            break;
                        case "Garbage truck":
                            which = 7;
                            break;
                        case "Police":
                            which = 8;
                            break;
                        case "Tractor G":
                            which = 9;
                            break;
                        case "Tractor Y":
                            which = 10;
                            break;
                        case "Toyota Corolla":
                            which = 11;
                            break;
                        default:
                            Debug.Log("ERR : Unknown tag : Start Audio");
                            break;
                    }
                    if (which != -1)    
                        _object.audioSource.PlayOneShot(_object.audioClips[which]);                     //ja tads tags bija atrasts, ieslēdzam skaņu

                }
                else
                {
                    Debug.Log("LOG : Correct Placement, Invalid Rot/Scale");
                    Debug.Log("LOG : x_sc_diff = " + x_scale_diff + ", y_sc_diff = " + y_scale_diff + ", rot_diff = " + rot_diff);
                }

            }
            else//--------------------------------------------------------------------------------------//Tāda gadījumā, ja tagi nesakrīt (objekts nolikts nepareizajā vietā) 
            {
                _object.rightPlace = false;
                _object.audioSource.PlayOneShot(_object.audioClips[12]);

                switch (_event.pointerDrag.tag)                                                         //atgriežām mašīnu savā vietā
                {
                    case "Ambulance":
                        _object.obj_amb.GetComponent<RectTransform>().localPosition = _object.crd_amb;
                        break;
                    case "B2":
                        _object.obj_b2.GetComponent<RectTransform> ().localPosition =  _object.crd_b2;
                        break;
                    case "Bus":
                        _object.obj_bus.GetComponent<RectTransform>().localPosition = _object.crd_bus;
                        break;
                    case "Cement truck":
                        _object.obj_cem.GetComponent<RectTransform>().localPosition = _object.crd_cem;
                        break;
                    case "E46":
                        _object.obj_e46.GetComponent<RectTransform>().localPosition = _object.crd_e46;
                        break;
                    case "Escavator":
                        _object.obj_esc.GetComponent<RectTransform>().localPosition = _object.crd_esc;
                        break;
                    case "Firefighters":
                        _object.obj_fir.GetComponent<RectTransform>().localPosition = _object.crd_fir;
                        break;
                    case "Garbage truck":
                        _object.obj_gar.GetComponent<RectTransform>().localPosition = _object.crd_gar;
                        break;
                    case "Police":
                        _object.obj_pol.GetComponent<RectTransform>().localPosition = _object.crd_pol;
                        break;
                    case "Tractor G":
                        _object.obj_trg.GetComponent<RectTransform>().localPosition = _object.crd_trg;
                        break;
                    case "Tractor Y":
                        _object.obj_try.GetComponent<RectTransform>().localPosition = _object.crd_try;
                        break;
                    case "Toyota Corolla":
                        _object.obj_toy.GetComponent<RectTransform>().localPosition = _object.crd_toy;
                        break;
                    default:
                        Debug.Log("ERR : Unknown tag : Return Object To Start Position");
                        break;

                } //switch end

            }
        }
    }
}