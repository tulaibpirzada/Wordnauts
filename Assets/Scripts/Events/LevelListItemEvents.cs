using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelListItemEvents : MonoBehaviour {

	public void LevelListItemTapped() {
		LevelListItemReferences levelListItemRef = GetComponent<LevelListItemReferences> ();
		GamePlayScreenController.Instance.LoadScreen (levelListItemRef.puzzleModel);
//		SingleClueLevelSelectionScreenController.Instance.ShowPuzzleScreen (levelListItemRef);
	}
}
