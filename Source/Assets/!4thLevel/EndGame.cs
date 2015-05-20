using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = "CONGRATULATIONS!\nYOU'VE COLLECTED " + dodajZeby.ileZebow + " TEETH!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
