using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelListItemEvents : MonoBehaviour {

	public void LevelListItemTapped() {
		LevelListItemReferences levelListItemRef = GetComponent<LevelListItemReferences> ();
		if (levelListItemRef.levelListType == LevelListItemReferences.LevelListType.SingleClueLevelList) {
			
			SingleClueLevelSelectionScreenController.Instance.ShowPuzzleScreen (levelListItemRef);
		} else {
			MultiClueLevelSelectionScreenController.Instance.ShowPuzzleScreen (levelListItemRef);
		}
	}
}
