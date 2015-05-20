using UnityEngine;
using System.Collections;

public class Meta : MonoBehaviour {

	public levelPassed levelPassed;
	public CanvasGroup CanvasGroup;
	public Canvas Koniec;

	void Awake(){
		Koniec.enabled = false;

	}
	// Update is called once per frame
	void Update () {
		if (levelPassed.CzyKoniec == true && CanvasGroup.alpha <=1 ) {
			Koniec.enabled = true;
			CanvasGroup.alpha += 0.01f;
			if (CanvasGroup.alpha > 1){ CanvasGroup.alpha = 1;}

		}
	}
}
