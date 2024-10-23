using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphaChanger : MonoBehaviour {


	private int i = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.GetComponent<CanvasGroup> ().alpha <= 0) {

			i = 1;
		}
		else if(gameObject.GetComponent<CanvasGroup> ().alpha >=1){
			i = -1;
		}

		gameObject.GetComponent<CanvasGroup> ().alpha += Time.deltaTime * i/1.5f;
		
	}
}
