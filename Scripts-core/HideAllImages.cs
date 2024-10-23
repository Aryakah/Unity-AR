using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAR;
public class HideAllImages : MonoBehaviour {


	[SerializeField] GameObject Cashs;

	public void HideAllimages(){

		if (Cashs.activeSelf == true) {

			Cashs.SetActive (false);
			ARBuilder.Instance.CameraDeviceBehaviours [0].SetFocusMode (CameraDeviceBaseBehaviour.FocusMode.Triggerauto);
		} else {

			Cashs.SetActive (true);
			ARBuilder.Instance.CameraDeviceBehaviours [0].SetFocusMode (CameraDeviceBaseBehaviour.FocusMode.Triggerauto);

		}

	}


}
