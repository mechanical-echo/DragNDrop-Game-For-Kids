using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Objects : MonoBehaviour{
    public GameObject garbage;
    public GameObject ambulance;
    public GameObject bus;

    [HideInInspector]
    public Vector2 garbCoords;
    [HideInInspector]
    public Vector2 busCoords;
    [HideInInspector]
    public Vector2 ambCoords;

    public Canvas canva;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    [HideInInspector]
    public bool rightPlace = false;

    public GameObject lastDraggableObject;

    void Start()
    {
        garbCoords = garbage.GetComponent<RectTransform>().localPosition;
        ambCoords = ambulance.GetComponent<RectTransform>().localPosition;
        busCoords = bus.GetComponent<RectTransform>().localPosition;
        
    }
}
