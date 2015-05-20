using UnityEngine;
using System.Collections;

public class tymczas_moven : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (1, 0, 0) * speed * Time.deltaTime);
	}
}
