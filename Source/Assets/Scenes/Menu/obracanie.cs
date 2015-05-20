using UnityEngine;
using System.Collections;

public class obracanie : MonoBehaviour {

	public float zapieprzaj = 500;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, Time.deltaTime * zapieprzaj);
	}
}
