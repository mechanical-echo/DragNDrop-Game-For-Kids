using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*----------------------------------------------------------------------------------------------------
                        Skripts iespējai maiīt objekta izmēru un rotāciju
 ----------------------------------------------------------------------------------------------------*/
public class ObjectTransformation : MonoBehaviour
{
    public Objects _objects;                          //objekts, kas satur Objects skriptu
    public float scale = 0.0005f;                     //mainīgais, kas ļauj kontrolēt izmēra maiņas ātrumu
    public float rotate = 9f;                         //mainīgais, kas ļauj kontrolēt rotācijas maiņas ātrumu
    
    void Update()                                     //pēc katra kadra tiek pārbaudīts, vai ir nospiesta kāda poga
    {
        if (_objects.lastDraggableObject != null)     //ja kāds objekts jau bija velkts
        {
            if (Input.GetKey(KeyCode.Z))//------------//ja nospiesta Z - rotējam pretpulksteņradītāja virzienā 
            {
                _objects.lastDraggableObject.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * rotate);
            }

            if (Input.GetKey(KeyCode.X))//------------//ja nospiesta X - rotējam pulksteņradītāja virzienā 
            {
                _objects.lastDraggableObject.GetComponent<RectTransform>().transform.Rotate(0, 0, -Time.deltaTime * rotate);
            }   

            if (Input.GetKey(KeyCode.UpArrow))//------//ja nospiesta bultiņa uz augšu - palielinām augstumu
            {
                if (_objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y < 1.5f)
                {
                    _objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(_objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x,
                        _objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y + scale);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))//----//ja nospiesta bultiņa uz apakšu - samazinām augstumu
            {
                if (_objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y > 0.3f)
                {
                    _objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(_objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x,
                        _objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y - scale);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))//----//ja nospiesta bultiņa pa kreisi - samazinām garumu
            {
                if (_objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x > 0.3f)
                {
                    _objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(_objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x - scale,
                        _objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))//---//ja nospiesta bultiņa pa labi - palielinām garumu
            {
                if (_objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x < 1.5f)
                {
                    _objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale
                    = new Vector2(_objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.x + scale,
                        _objects.lastDraggableObject.GetComponent<RectTransform>().transform.localScale.y);
                }
            }
        }
    }
}