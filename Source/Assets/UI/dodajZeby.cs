using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dodajZeby : MonoBehaviour {


	static public int ileZebow = 0;
	Text counter;
	
	void Start () {
		counter = GetComponent<Text>();
		//dodajCounter (0);
	}


	public void dodajCounter ()
	{
		ileZebow ++;
		counter.text = + ileZebow + "x" ;
		//counter = ileZebow;
	}

}
