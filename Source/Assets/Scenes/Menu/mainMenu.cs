using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

	private Canvas wybierzLevel;
	

	void Start()
	{
		wybierzLevel = GameObject.FindWithTag("wybierzLevel").GetComponent<Canvas> ();
		wybierzLevel.enabled = false;
	}

	public void doMenu()
	{
		Application.LoadLevel ("MENU");
		dodajZeby.ileZebow = 0;
	}

	public void startuj()
	{
		Application.LoadLevel("level1");
	}

	public void loadlevel()
	{
		wybierzLevel.enabled = true;
	}

	public void load1()
	{
		Application.LoadLevel("level1");
	}

	public void load2()
	{
		Application.LoadLevel("level2");
	}

	public void load3()
	{
		Application.LoadLevel("level3");
	}

	public void exit()
	{
		Application.Quit();
	}
}
