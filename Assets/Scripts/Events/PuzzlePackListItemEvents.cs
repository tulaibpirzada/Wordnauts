using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePackListItemEvents : MonoBehaviour {

	public void PuzzlePackListItemTapped() {
		PuzzlePackListItemReferences puzzlePackListItemRef = GetComponent<PuzzlePackListItemReferences> ();
		SingleCluePuzzleSelectionScreenController.Instance.LoadPuzzlePackModelForSelectedListItem (puzzlePackListItemRef);
	}
}
