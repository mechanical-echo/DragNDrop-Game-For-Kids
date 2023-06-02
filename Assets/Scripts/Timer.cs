using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI; 
public class Timer : MonoBehaviour {
	public float timeStart;			//ar ko sakas laika atskaite (0)
	public Text textBox;			//teksta elements, kura tiek izvadits rezultats
	private int sec, min, h;		//mainigie, nepieciesamie aprekinasanai

	private string t;				//mainigais, kas uzglabs rezultejoso vertibu

	void Start () {
		t = getTime();
		textBox.text = t;	
	}
	private string getTime()
	{
        sec = Mathf.RoundToInt(timeStart);			//noapalojam laiku
        h = sec / 3600;								//aprekinam stundas
        sec -= h * 3600;							//cik sekundes paliek
        min = sec / 60;								//ta pat ar minutem
        sec -= min * 60;
		string a, b, c;								//sadalam String uz trim dalam, lai parbaudit, kad ir jaieraksta nulles pirms skaitliem
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

		return t;									//atgriezam vertibu
    }
	void Update () {
		timeStart += Time.deltaTime;				//cik ir pagajus laika
		t= getTime();								//dabunam to vertibu pareizaja formata
        textBox.text = t;							//izvadam ekranaa
    }
}
