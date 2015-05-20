using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelPassed : MonoBehaviour {

	public Canvas levelIsPassed;
	public string ktorylevel= "level3" ;
	public GameObject hamster;


	public bool CzyKoniec = false;
	void OnTriggerEnter (Collider player)
	{
		if (player.tag == "Player") {
			Debug.Log("dupsko");
			levelIsPassed.enabled = true;
			CzyKoniec = true;
			hamster.GetComponent<PlayerController>().EndLevel();
		}
	}
	
	
	public void nextLevel()
	{
		Application.LoadLevel(ktorylevel);
	}


}
