using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCluePuzzleSelectionScreenController : Singleton<SingleCluePuzzleSelectionScreenController> {

	SingleCluePuzzleSelectionScreenReferences singleCluePuzzleSelectionScreenRef;
	private List<GameObject> puzzleItemList;
	public enum ListItemState {
		Locked,
		Unlocked,
		Done
	}

	public void LoadScreen()
	{
		GameObject puzzleSelectionGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.SINGLE_CLUE_PUZZLE_PACK_SELECTION_SCREEN);
		singleCluePuzzleSelectionScreenRef = puzzleSelectionGameObject.GetComponent<SingleCluePuzzleSelectionScreenReferences> ();
        PopulateScrollView();

	}

    private void PopulateScrollView() {
		puzzleItemList = new List<GameObject> ();
		for (int index = 0; index < MultiplePackModel.Instance.TotalPacks; index++) {
            GameObject listItemGameObject = Instantiate(singleCluePuzzleSelectionScreenRef.puzzlePackListItem) as GameObject;
            listItemGameObject.transform.SetParent(singleCluePuzzleSelectionScreenRef.scrollView.content, true);
            listItemGameObject.transform.localPosition = Vector3.zero;
            listItemGameObject.transform.localScale = Vector3.one;
			puzzleItemList.Add (listItemGameObject);
			PuzzlePackListItemReferences puzzlePackListItemRef = listItemGameObject.GetComponent<PuzzlePackListItemReferences> ();
			puzzlePackListItemRef.titleLabel.text = "Puzzle Pack " + (index + 1).ToString ();
			if (index < PlayerModel.Instance.singleClue.PackNo) {
				puzzlePackListItemRef.tickIcon.SetActive(true);
				puzzlePackListItemRef.newIcon.SetActive(false);
				puzzlePackListItemRef.arrowIcon.SetActive(false);
				puzzlePackListItemRef.lockIcon.SetActive(false);
				puzzlePackListItemRef.puzzlePackModel = MultiplePackModel.Instance.packsList [index];
			} else if (index == PlayerModel.Instance.singleClue.PackNo) {
				puzzlePackListItemRef.tickIcon.SetActive(false);
				puzzlePackListItemRef.newIcon.SetActive(true);
				puzzlePackListItemRef.arrowIcon.SetActive(true);
				puzzlePackListItemRef.lockIcon.SetActive(false);
				puzzlePackListItemRef.puzzlePackModel = MultiplePackModel.Instance.packsList [index];
			} else if (index > PlayerModel.Instance.singleClue.PackNo) {
				puzzlePackListItemRef.tickIcon.SetActive(false);
				puzzlePackListItemRef.newIcon.SetActive(false);
				puzzlePackListItemRef.arrowIcon.SetActive(false);
				puzzlePackListItemRef.lockIcon.SetActive(true);
				puzzlePackListItemRef.puzzlePackModel = null;
			}
        }
    }

    public void SlideBackToMainMenu() {
		foreach (GameObject puzzleItem in puzzleItemList) {
			Destroy (puzzleItem);
		}
		puzzleItemList.Clear ();
        MainMenuController.Instance.ShowMainMenuScreen();
    }

	public void LoadPuzzlePackModelForSelectedListItem(PuzzlePackListItemReferences puzzlePackListItemRef) {
		SingleClueLevelSelectionScreenController.Instance.LoadScreen (puzzlePackListItemRef.puzzlePackModel);
	}
}
