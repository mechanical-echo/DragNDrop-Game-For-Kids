using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI; 
public class Timer : MonoBehaviour {
	public float timeStart;
	public Text textBox;
	private int sec, min, h;

	private string t;
	void Start () {
		t = getTime();
		textBox.text = t;	
	}
	private string getTime()
	{
        sec = Mathf.RoundToInt(timeStart);
        h = sec / 3600;
        sec -= h * 3600;
        min = sec / 60;
        sec -= min * 60;
		string a, b, c;
		if (sec < 10)
		{
			c = ":0" + sec;
		} else
			c = ":" + sec;
		if (min < 10)
		{
			b = ":0" + min;
		}
		else
			b = ":" + min;
		if (h < 10)
		{
			a = "0" + h;
		}
		else
			a = ""+ h;
        t = a+b+c;

		return t;
    }
	void Update () {
		timeStart += Time.deltaTime;
		t= getTime();
        textBox.text = t;
    }
}
