using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	public GameObject text;						//"welcome" teksts

	
	public void StartGame()				
	{
		SceneManager.LoadScene("scene-1-map");	//Spēles sākums
	}

	public void CloseGame()
	{
		Application.Quit();						//Spēles aizvēršana
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene("scene-0-menu"); //Atgriezties uz galvēno scenu
	}

	void Update () {
		//mainīt teksta krāsu pēc katrā kadra
        text.GetComponent<Text>().color = new Color(Mathf.Sin(Time.time), Mathf.Cos(Time.time), Mathf.Tan(Time.time));
    }
}
