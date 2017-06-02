﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : Singleton<MainMenuController> {

	MainMenuReferences mainMenuRef;

	public void ShowMainMenuScreen()
	{
		GameObject menuMenuGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.MAIN_MENU_SCREEN);
		mainMenuRef = menuMenuGameObject.GetComponent<MainMenuReferences> ();
        mainMenuRef.Percentage.text = PlayerModel.Instance.completionPercent.ToString() +"%";
        mainMenuRef.Star.text = PlayerModel.Instance.stars.ToString();

    }

	public void CheckAndLoadDailyPuzzle() {
		if (PlayerModel.Instance.dailyLevel.isAvailable)
        {
            //Show daily level screen
			PuzzleModel puzzleModel = PopulateDailyPuzzleData();
            LevelEndScreenController.Instance.puzzleModel = puzzleModel;
            LevelStartScreenController.Instance.ShowScreen(puzzleModel);
		}
        else
        {
			// Show screen "play again tomorrow"
		}
	}

	private PuzzleModel PopulateDailyPuzzleData() {
		PuzzleModel puzzleModel = new PuzzleModel();
		puzzleModel.Populate (DatabaseModel.Instance.dailyLevelSnapshot, DailyLevelModel.Instance.LevelPath);
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

	}
}
