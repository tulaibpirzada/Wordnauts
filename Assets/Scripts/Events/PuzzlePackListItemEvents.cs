using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePackListItemEvents : MonoBehaviour {

	public void PuzzlePackListItemTapped() {
        
        PuzzlePackListItemReferences puzzlePackListItemRef = GetComponent<PuzzlePackListItemReferences> ();
      //  Debug.Log(puzzlePackListItemRef.button.GetComponentInChildren<Button>());
        SingleCluePuzzleSelectionScreenController.Instance.LoadPuzzlePackModelForSelectedListItem (puzzlePackListItemRef);
	}
}
