using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*----------------------------------------------------------------------------------------------------
                Objektu klase, kas glābs informāciju par katras mašīnas sākuma pozīcju un stāvokli
 ----------------------------------------------------------------------------------------------------*/
public class Objects : MonoBehaviour{
    
    
    public GameObject obj_amb;    //visas mašīnas
    public GameObject obj_b2;
    public GameObject obj_bus;
    public GameObject obj_cem;
    public GameObject obj_e46;
    public GameObject obj_esc;
    public GameObject obj_fir;
    public GameObject obj_gar;
    public GameObject obj_pol;
    public GameObject obj_toy;
    public GameObject obj_trg;
    public GameObject obj_try;


    [HideInInspector]             //Mašīnu koordinātas
    public Vector2 crd_amb;
    [HideInInspector]
    public Vector2 crd_b2;
    [HideInInspector]
    public Vector2 crd_bus;
    [HideInInspector]
    public Vector2 crd_cem;
    [HideInInspector]
    public Vector2 crd_e46;
    [HideInInspector]
    public Vector2 crd_esc;
    [HideInInspector]
    public Vector2 crd_fir;
    [HideInInspector]
    public Vector2 crd_gar;
    [HideInInspector]
    public Vector2 crd_pol;
    [HideInInspector]
    public Vector2 crd_toy;
    [HideInInspector]
    public Vector2 crd_trg;
    [HideInInspector]
    public Vector2 crd_try;

    public Canvas canva;                    //kanva, kas satur visus UI elementus

    public AudioSource audioSource;         //fona mūzika
    public AudioClip[] audioClips;          //visas mašīnu skaņas

    [HideInInspector]
    public bool rightPlace = false;         //vai objekts ir nomests pareizajā vietā
    [HideInInspector]
    public GameObject lastDraggableObject;  //pēdējais vilktais objekts, vajadzīgs, lai noteikt kuram objektam ir jāmainā scale/rot

    void Start()
    {
        //saglabām katrai mašīnai savu sākuma pozīciju
        crd_amb = obj_amb.GetComponent<RectTransform>().localPosition;
        crd_b2  = obj_b2.GetComponent<RectTransform> ().localPosition;
        crd_bus = obj_bus.GetComponent<RectTransform>().localPosition;
        crd_cem = obj_cem.GetComponent<RectTransform>().localPosition;
        crd_e46 = obj_e46.GetComponent<RectTransform>().localPosition;
        crd_esc = obj_esc.GetComponent<RectTransform>().localPosition;
        crd_fir = obj_fir.GetComponent<RectTransform>().localPosition;
        crd_gar = obj_gar.GetComponent<RectTransform>().localPosition;
        crd_pol = obj_pol.GetComponent<RectTransform>().localPosition;
        crd_toy = obj_toy.GetComponent<RectTransform>().localPosition;
        crd_trg = obj_trg.GetComponent<RectTransform>().localPosition;
        crd_try = obj_try.GetComponent<RectTransform>().localPosition;
    }
}
