using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.NetworkSystem;
using System;

public class Win : MonoBehaviour {

	public GameObject ui_win;
	public Text txt_time;

	public GameObject ui_star_1;
	public GameObject ui_star_2;
	public GameObject ui_star_3;

	public GameObject ui_ingame_timer;

	[HideInInspector]
    public int amount_obj = 0;
	
    public void startOver()							//sākt spēli no jaunā
	{
		SceneManager.LoadScene("scene-1-map");
		ui_ingame_timer.SetActive(true);
	}

	void Start()
	{
		ui_win.SetActive(false);					//sākumā nevar redzēt uzvaras logu
	}

	public void endGame()							//paradīt uzvaras logu
	{
		Debug.Log("LOG : Game ended!");
        ui_ingame_timer.SetActive(false);
        ui_win.SetActive(true);
		txt_time.text = Timer.getTime(false);
		int sec = Convert.ToInt32(Timer.getTime(true));
		if(sec/60 < 3) //3 zvaigznes, ja patereja < 3 minutes
		{
			ui_star_1.SetActive(true);
            ui_star_2.SetActive(true);
            ui_star_3.SetActive(true);
        }
        else if(sec/60 < 5) //2 zvaigznes
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
