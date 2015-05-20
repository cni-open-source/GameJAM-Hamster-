using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class die : MonoBehaviour {

	public Canvas dieMenu;

	void Awake()
	{
		dieMenu.enabled = false;
	}

	public void died()
	{
		dieMenu.enabled = true;
	}

	public void restart()
	{
		Application.LoadLevel("level1");
	}

	public void quit()
	{
		Application.Quit();
	}



}
