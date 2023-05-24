using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransformation : MonoBehaviour
{
    public Objects objektuSkripts;

    // Update is called once per frame
    void Update()
    {
        if (objektuSkripts.lastDraggableObject != null)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * 9f);
            }

            if (Input.GetKey(KeyCode.X))
            {
                objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.Rotate(0, 0, -Time.deltaTime * 9f);
            }   

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y < 0.8f)
                {
                    objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y + 0.001f);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y > 0.3f)
                {
                    objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y - 0.001f);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x > 0.3f)
                {
                    objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x - 0.001f,
                        objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x < 0.8f)
                {
                    objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x + 0.001f,
                        objektuSkripts.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y);
                }
            }
        }
    }
}