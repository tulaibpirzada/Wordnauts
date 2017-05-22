using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : Singleton<MainMenuController> {

	MainMenuReferences mainMenuRef;

	public void ShowMainMenuScreen()
	{
		GameObject menuMenuGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.MAIN_MENU_SCREEN);
		mainMenuRef = menuMenuGameObject.GetComponent<MainMenuReferences> ();
	}

	public void CheckAndLoadDailyPuzzle() {
		if (PlayerModel.Instance.dailyLevel.isAvailable)
        {
            //Show daily level screen
            LevelStartScreenController.Instance.ShowScreen();
		}
        else
        {
			// Show screen "play again tomorrow"
		}
	}

	public void ShowSingleCluePuzzleSelectionScreen() {
		SingleCluePuzzleSelectionScreenController.Instance.LoadScreen ();
	}

	public void ShowMultiCluePuzzleSelectionScreen() {

	}

	public void ShowGetMoreHintsPopup() {
		
	}

	public void ShowSettingsPopup() {

	}
}
