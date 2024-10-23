using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintScript : MonoBehaviour {


	[SerializeField] GameObject panel;
	[SerializeField] GameObject hint;
	[SerializeField] Animator anim;

	void Start(){


		//anim = GetComponent<Animator> ();
	}

	float counterPanle=0;
	// Use this for initialization


	public void enablePanel(){


			counterPanle = 1;
			

			panel.SetActive (true);
			
		Debug.Log ("OH");

		anim.Play("my Popup", 0, 0.25f);
		   




	}



}
