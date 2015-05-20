using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class escMenu : MonoBehaviour {

	public Canvas menu;
	
	// Update is called once per frame

	void Awake ()
	{
		menu.enabled=false;
	}

	void Update () {
	
		if (Input.GetKey(KeyCode.Escape)) {
			menu.enabled = true;
			Time.timeScale = 0;
		}

	}

	public void resume()
	{
		menu.enabled = false;
		Time.timeScale = 1;
	}

	public void exit()
	{
		Application.Quit();
	}
}
