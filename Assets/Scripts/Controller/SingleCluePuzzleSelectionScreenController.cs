using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCluePuzzleSelectionScreenController : Singleton<SingleCluePuzzleSelectionScreenController> {

	SingleCluePuzzleSelectionScreenReferences singleCluePuzzleSelectionScreenRef;

	public void LoadScreen()
	{
		GameObject puzzleSelectionGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.SINGLE_CLUE_SELECTION_SCREEN);
		singleCluePuzzleSelectionScreenRef = puzzleSelectionGameObject.GetComponent<SingleCluePuzzleSelectionScreenReferences> ();
        PopulateScrollView();

	}

    private void PopulateScrollView() {
        for (int index = 0; index < DatabaseModel.Instance.singleClueSnapshot.ChildrenCount; index++) {
            GameObject listItemGameObject = Instantiate(singleCluePuzzleSelectionScreenRef.puzzlePackListItem) as GameObject;
            listItemGameObject.transform.SetParent(singleCluePuzzleSelectionScreenRef.scrollView.content, true);
            listItemGameObject.transform.localPosition = Vector3.zero;
            listItemGameObject.transform.localScale = Vector3.one;

        }
    }

    public void SlideBackToMainMenu() {
        MainMenuController.Instance.ShowMainMenuScreen();
    }
}
