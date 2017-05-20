using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCluePuzzleSelectionScreenController : Singleton<SingleCluePuzzleSelectionScreenController> {

	SingleCluePuzzleSelectionScreenReferences singleCluePuzzleSelectionScreenRef;

	public void LoadScreen()
	{
		GameObject puzzleSelectionGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.SINGLE_CLUE_SELECTION_SCREEN);
		singleCluePuzzleSelectionScreenRef = puzzleSelectionGameObject.GetComponent<SingleCluePuzzleSelectionScreenReferences> ();
	}

    public void SlideBackToMainMenu() {
        MainMenuController.Instance.ShowMainMenuScreen();
    }
}
