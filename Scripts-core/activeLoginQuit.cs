using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeLoginQuit : MonoBehaviour {

	private int counter=0;
	[SerializeField] GameObject quitPanel;


	// Use this for initialization


	public void activePanel(){
		counter++;
		if (counter == 10) {
			counter = 0;
			quitPanel.SetActive (true);

		}
	}

}
