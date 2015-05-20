using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 10.0f;
	public float jump = 10.0f;
	public float gravity = 9.81f;
	public GameObject canvas;
	public GameObject particleTooth;
	public GameObject bloodObject;
	public AudioClip soundTooth;
	public AudioClip soundJump;
	public AudioClip soundDead;
	public AudioClip soundEndGame;
	public AudioClip musicDead;

	private float _heightToGround;
	private float _zSize;
	private bool _isDoubleJump = false;
	private bool _isJumpClicked = false;
	private bool _isEndLevel = false;
	private bool _isDead = false;

	public void EndLevel()
	{
		if (!_isEndLevel) {
			GetComponent<AudioSource>().Stop ();
			GetComponent<AudioSource>().clip = soundEndGame;
			GetComponent<AudioSource>().Play ();
		}
		_isEndLevel = true;
	}

	// Use this for initialization
	void Start ()
	{
		_isEndLevel = false;
		GetComponent<Rigidbody>().freezeRotation = true;
		_heightToGround = GetComponent<Collider> ().bounds.extents.y * 1.1f;
		_zSize = GetComponent<Collider> ().bounds.extents.z * 1.5f;
	}

	private bool IsOnGround()
	{
		return Physics.Raycast(transform.position, -Vector3.up, _heightToGround);
	}

	private void SoundOnJump()
	{
		GetComponent<AudioSource>().Stop ();
		GetComponent<AudioSource>().clip = soundJump;
		GetComponent<AudioSource>().Play ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (!_isEndLevel) {
			if (col.gameObject.tag == "tooth") {
				Destroy (col.gameObject);
				canvas.transform.FindChild("Text").GetComponent<dodajZeby>().dodajCounter();
				Instantiate(particleTooth, transform.position, new Quaternion());
				GetComponent<AudioSource>().Stop ();
				GetComponent<AudioSource>().clip = soundTooth;
				GetComponent<AudioSource>().Play ();
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (!_isEndLevel) {
			if (col.gameObject.tag == "tooth") {
				Destroy (col.gameObject);
				canvas.transform.FindChild("Text").GetComponent<dodajZeby>().dodajCounter();
				Instantiate(particleTooth, transform.position, new Quaternion());
				GetComponent<AudioSource>().Stop ();
				GetComponent<AudioSource>().clip = soundTooth;
				GetComponent<AudioSource>().Play ();
			}
		}
		if (!_isEndLevel && !_isDead) {
			if (col.gameObject.tag == "dentist") {
				_isDead = true;
				RaycastHit hit;
				Physics.Raycast(transform.position, -Vector3.up, out hit);
				Vector3 pos = transform.position + new Vector3(0.0f, -hit.distance * 0.99f, 0.0f);
				Instantiate (bloodObject, pos, Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f)));

				GetComponent<AudioSource>().Stop ();
				GetComponent<AudioSource>().clip = soundDead;
				GetComponent<AudioSource>().Play ();

				Camera.main.GetComponent<AudioSource> ().Stop ();
				Camera.main.GetComponent<AudioSource>().loop = false;
				Camera.main.GetComponent<AudioSource>().clip = musicDead;
				Camera.main.GetComponent<AudioSource>().Play ();

				dodajZeby.ileZebow = 0;

				Camera.main.GetComponent<die>().died();

				transform.position = new Vector3(0.0f, -55.0f, 0.0f);
			}
		}
	}

	void Update ()
	{
		if (_isEndLevel) {
			GetComponent<Rigidbody> ().velocity = new Vector3(0.0f, 5.0f, 2.5f);

			var camera = Camera.main;
			camera.transform.LookAt (transform.position);
		}
		else if (!_isEndLevel && !_isDead) {
			Vector3 _vel = new Vector3 (GetComponent<Rigidbody> ().velocity.x, GetComponent<Rigidbody> ().velocity.y, GetComponent<Rigidbody> ().velocity.z);
			_vel.z = Input.GetAxis ("Horizontal") * speed;
			float v = Input.GetAxis ("Vertical");

			RaycastHit hit1;
			RaycastHit hit2;
			RaycastHit hit3 = new RaycastHit();
			Physics.Raycast (transform.position + new Vector3 (0.0f, -_heightToGround, 0.0f), new Vector3 (0.0f, 0.0f, 1.0f), out hit1);
			Physics.Raycast (transform.position + new Vector3 (0.0f, 0.0f, 0.0f), new Vector3 (0.0f, 0.0f, 1.0f), out hit2);
//			Physics.Raycast (transform.position + new Vector3 (0.0f, _heightToGround, 0.0f), new Vector3 (0.0f, 0.0f, 1.0f), out hit3);

			float dst = hit1.distance;
			if(dst == 0.0f)
			{
				dst = hit2.distance;
				if(dst == 0.0f)
					dst = hit3.distance;
				else
				{
					if(hit3.distance > 0.0f)
						dst = Mathf.Min (hit2.distance, hit3.distance);
				}
			}
			else
			{
				dst = hit1.distance;
				if(hit2.distance > 0.0f)
				{
					if(hit3.distance > 0.0f)
						dst = Mathf.Min (Mathf.Min (hit1.distance, hit2.distance), hit3.distance);
					else
						dst = Mathf.Min (hit1.distance, hit2.distance);
				}
				else
				{
					if(hit3.distance > 0.0f)
						dst = Mathf.Min (hit1.distance, hit2.distance);
				}
			}

			if (dst > 0.0f && dst < _zSize) {
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - _zSize + dst);
			} else {

				Physics.Raycast (transform.position + new Vector3 (0.0f, -_heightToGround, 0.0f), new Vector3 (0.0f, 0.0f, -1.0f), out hit1);
				Physics.Raycast (transform.position + new Vector3 (0.0f, 0.0f, 0.0f), new Vector3 (0.0f, 0.0f, -1.0f), out hit2);
//				Physics.Raycast (transform.position + new Vector3 (0.0f, _heightToGround, 0.0f), new Vector3 (0.0f, 0.0f, -1.0f), out hit3);

				if((hit1.collider == null || hit1.collider.gameObject.tag != "dentist") && (hit2.collider == null || hit2.collider.gameObject.tag != "dentist") && (hit3.collider == null || hit3.collider.gameObject.tag != "dentist"))
				{
					dst = hit1.distance;
					if(dst == 0.0f)
					{
						dst = hit2.distance;
						if(dst == 0.0f)
							dst = hit3.distance;
						else
						{
							if(hit3.distance > 0.0f)
								dst = Mathf.Min (hit2.distance, hit3.distance);
						}
					}
					else
					{
						dst = hit1.distance;
						if(hit2.distance > 0.0f)
						{
							if(hit3.distance > 0.0f)
								dst = Mathf.Min (Mathf.Min (hit1.distance, hit2.distance), hit3.distance);
							else
								dst = Mathf.Min (hit1.distance, hit2.distance);
						}
						else
						{
							if(hit3.distance > 0.0f)
								dst = Mathf.Min (hit1.distance, hit2.distance);
						}
					}
					
					if (dst > 0.0f && dst < _zSize) {
						transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + _zSize - dst);
					}
				}

			}

			if (v == 0.0f)
				_isJumpClicked = false;
			else if (!_isJumpClicked && !_isDoubleJump) {
				_isDoubleJump = true;
				_vel.y = jump;
				SoundOnJump();
			}

			if (IsOnGround () || transform.position.y <= 0.0f) {
				transform.position = new Vector3 (transform.position.x, Mathf.Max (transform.position.y, 0.0f), transform.position.z);

				if (v > 0.0f) {
					_isJumpClicked = true;
					_isDoubleJump = false;
					_vel.y = jump;
					SoundOnJump();
				}
			} else {
				_vel.y -= gravity * Time.deltaTime;
			}


			GetComponent<Rigidbody> ().velocity = _vel;

			var camera = Camera.main;
		
			camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, transform.position.z);
			camera.transform.LookAt (transform.position);
		}
	}
}
