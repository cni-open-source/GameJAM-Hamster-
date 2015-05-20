using UnityEngine;
using System.Collections;

public class DiscoLight : MonoBehaviour {
	public float TimeMultiplayer = 10.0f;
	public float Phase = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Light>().color = new Color((Mathf.Sin (TimeMultiplayer * Time.realtimeSinceStartup + Phase) + 1.0f)/2.0f, 
		                                        (Mathf.Sin (TimeMultiplayer * Time.realtimeSinceStartup + Phase + 2.0f) + 1.0f)/2.0f, 
		(Mathf.Sin (TimeMultiplayer * Time.realtimeSinceStartup + Phase + 4.0f) + 1.0f)/2.0f);
	}
}
