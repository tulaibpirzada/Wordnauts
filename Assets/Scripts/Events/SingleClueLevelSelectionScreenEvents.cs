using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleClueLevelSelectionScreenEvents : MonoBehaviour {

	public void BackButtonTapped() {
        SingleCluePuzzleSelectionScreenController.Instance.LoadScreen();
	}
}
