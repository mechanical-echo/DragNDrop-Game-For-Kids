using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
/*----------------------------------------------------------------------------------------------------
									Skripts patērēta laika aprēķināšanai
 ----------------------------------------------------------------------------------------------------*/
public class Timer : MonoBehaviour {
	public static float timeStart;			//ar ko sākas laika atskaite (0)
	public GameObject textBox;				//teksta elements, kurā tiek izvadīts rezultāts

	private static string t;				//mainigais, kas uzglabs rezultējošo vērtību

	void Start () {
		timeStart = 0;
		t = getTime(false);
		textBox.GetComponent<Text>().text = t;	
	}
	
    public static string getTime(bool asSeconds)
	{
        int sec, min, h;							//mainīgie nepieciešamie aprēķināšanai
        sec = Mathf.RoundToInt(timeStart);			//noapaļojām laiku
		
		if (asSeconds)								//ja metodei tiek padota vērtība true - atgriežam tikai sekundes
		{
			return ""+sec;
		}


        h = sec / 3600;								//aprēķinām stundas
        sec -= h * 3600;							//cik sekundes paliek 
        min = sec / 60;								//tā pat ar minūtēm
        sec -= min * 60;
		
		string a, b, c;								//sadalām String uz trim daļām, lai parbaudīt, kad ir jāpieraksta nulles pirms skaitļiem

		if (sec < 10) c = ":0" + sec;
		else	      c = ":" + sec;

		if (min < 10) b = ":0" + min;
		else          b = ":" + min;

		if (h < 10)   a = "0" + h;
		else          a = ""+ h;

        t = a+b+c;									//saliekam visu kopā

		return t;									//atgriežām vērtību
    }
	void Update () {
		timeStart += Time.deltaTime;				//laika starpība
		t = getTime(false);							//dabunām to vērtību pareizajā formatā
        textBox.GetComponent<Text>().text = t;		//izvadām ekranā
    }
}
