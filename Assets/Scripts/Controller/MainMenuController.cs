using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : Singleton<MainMenuController> {

	MainMenuReferences mainMenuRef;

	public void ShowMainMenuScreen()
	{
		GameObject menuMenuGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.MAIN_MENU_SCREEN);
		mainMenuRef = menuMenuGameObject.GetComponent<MainMenuReferences> ();
        mainMenuRef.percentageLabel.text = PlayerModel.Instance.completionPercent.ToString() +"%";
        mainMenuRef.starLabel.text = PlayerModel.Instance.stars.ToString();
		mainMenuRef.progressBar.fillAmount =  (PlayerModel.Instance.completionPercent * 0.1f) / 100.0f;

    }

	public void CheckAndLoadDailyPuzzle() {
		if (PlayerModel.Instance.IsDailyLevelAvailableToday())
        {
            //Show daily level screen
			PuzzleModel puzzleModel = PopulateDailyPuzzleData();
            LevelStartScreenController.Instance.ShowScreen(puzzleModel);
		}
        else
        {
            // Show screen "play again tomorrow"

			ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.NO_MORE_DAILY_LEVELS_POPUP);
        }
	}

	private PuzzleModel PopulateDailyPuzzleData() {
		PuzzleModel puzzleModel = new PuzzleModel();
		puzzleModel.Populate (DatabaseModel.Instance.dailyLevelSnapshot,1, DailyLevelModel.Instance.LevelPath);
		return puzzleModel;
	}

	public void ShowSingleCluePuzzleSelectionScreen() {
		SingleCluePuzzleSelectionScreenController.Instance.LoadScreen ();
	}

	public void ShowMultiCluePuzzleSelectionScreen() {
		MultiClueLevelSelectionScreenController.Instance.LoadScreen ();
	}

	public void ShowGetMoreHintsPopup() {
		
	}

	public void ShowSettingsPopup() {

        SettingScreenController.Instance.LoadScreen();
	}
}
