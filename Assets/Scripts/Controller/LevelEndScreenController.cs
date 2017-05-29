using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScreenController : Singleton<LevelEndScreenController> {

	LevelEndScreenReferences levelEndScreenRef;

	public void LoadScreen()
	{
		GameObject levelEndGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.LEVEL_END_SCREEN);
		levelEndScreenRef = levelEndGameObject.GetComponent<LevelEndScreenReferences> ();
	}

	public void SlideBackToMainMenu() {
		MainMenuController.Instance.ShowMainMenuScreen();
	}
}
