using UnityEngine;
using System.Collections;

public class Potworek : MonoBehaviour {
	public float Speed=0;
	GameObject go;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, Speed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, Speed);
		GetComponent<Rigidbody> ().freezeRotation = true;
	
	}
	public GameObject explosion;
	public float countdown = 3.0f;


	void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "obstacles" || other.gameObject.tag == "tooth") {
			Vector3 expl;	
			expl = other.gameObject.transform.position;

			Destroy (other.gameObject);

			go = (GameObject)Instantiate (explosion);
			go.gameObject.transform.position = expl;

		}	
		//}
	}


}
