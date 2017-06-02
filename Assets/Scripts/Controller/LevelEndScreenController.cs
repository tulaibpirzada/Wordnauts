using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScreenController : Singleton<LevelEndScreenController> {

	LevelEndScreenReferences levelEndScreenRef;
    public PuzzleModel puzzleModel;


    public void LoadScreen()
    {
		GameObject levelEndGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.LEVEL_END_SCREEN);
		levelEndScreenRef = levelEndGameObject.GetComponent<LevelEndScreenReferences> ();
        levelEndScreenRef.Star.text = "+"+ puzzleModel.PrestigePoints.ToString();
	}

	public void SlideBackToMainMenu() {
        puzzleModel.UpdateReward();
        MainMenuController.Instance.ShowMainMenuScreen();
        
    }
    
}
