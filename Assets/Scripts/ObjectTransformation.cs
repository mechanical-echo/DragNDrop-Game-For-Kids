using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransformation : MonoBehaviour
{
    public Objects objektuSkripts;
    public float scale = 0.0005f;
    public float rotate = 9f;
    // Update is called once per frame
    void Update()
    {
        if (objektuSkripts.lastDraggableObject != null)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * rotate);
            }

            if (Input.GetKey(KeyCode.X))
            {
                objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.Rotate(0, 0, -Time.deltaTime * rotate);
            }   

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y < 1.5f)
                {
                    objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y + scale);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y > 0.3f)
                {
                    objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y - scale);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x > 0.3f)
                {
                    objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x - scale,
                        objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x < 1.5f)
                {
                    objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x + scale,
                        objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y);
                }
            }
        }
    }
}