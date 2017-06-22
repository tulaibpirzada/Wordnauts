using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScreenEvents : MonoBehaviour {

	public void screenTapped() {
		LevelEndScreenController.Instance.HandleNavigation ();
	}
}
