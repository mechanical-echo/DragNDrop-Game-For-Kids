using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.NetworkSystem;
using System;
/*----------------------------------------------------------------------------------------------------
									Skripts uzvaras ekrānām
 ----------------------------------------------------------------------------------------------------*/
public class Win : MonoBehaviour {

	public GameObject ui_win;						//uzvaras logs
	public Text txt_time;							//laiks uzvaras logā

	public GameObject ui_star_1;					//zvaigznes
	public GameObject ui_star_2;
	public GameObject ui_star_3;

	public GameObject ui_ingame_timer;				//laika teksts spēlē

	[HideInInspector]
    public int amount_obj = 0;						//pareizi ievietoto mašīnu skaits
	
    public void startOver()							//sākt spēli no jaunā - atvērt ainu no jaunā un ieslēgt spēles laiku atpakaļ
	{
		SceneManager.LoadScene("scene-1-map");		
		ui_ingame_timer.SetActive(true);
	}

	void Start()
	{
		ui_win.SetActive(false);					//sākumā pāslēpt uzvaras logu
	}

	public void endGame()							//paradīt uzvaras logu
	{
		Debug.Log("LOG : Game ended!");

        ui_ingame_timer.SetActive(false);			//pāslēpt spēles laiku
        ui_win.SetActive(true);						//parādīt uzvaras logu
		txt_time.text = Timer.getTime(false);		//dabūt patērēto laiku
		
		int sec = Convert.ToInt32(Timer.getTime(true)); //dabūt sekundes, lai aprēķināt zvaigžņu skaitu

		if(sec/60 < 2) //3 zvaigznes, ja patereja < 2 minutes
		{
			ui_star_1.SetActive(true);
            ui_star_2.SetActive(true);
            ui_star_3.SetActive(true);
        }
        else if(sec/60 < 3) //2 zvaigznes
		{
            ui_star_1.SetActive(true);
            ui_star_2.SetActive(true);
            ui_star_3.SetActive(false);
        }
		else //1 zvaigzne
		{
            ui_star_1.SetActive(true);
            ui_star_2.SetActive(false);
            ui_star_3.SetActive(false);
        }
	}

	
}
