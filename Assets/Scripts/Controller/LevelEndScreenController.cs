using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScreenController : Singleton<LevelEndScreenController> {

	LevelEndScreenReferences levelEndScreenRef;
    public PuzzleModel puzzleModel;

	private void SendUpdateToServer() {
		
		//update percentage
		PlayerModel.Instance.UpdateCompletionPercentage();
		//update stars and hints
		PlayerModel.Instance.UpdateStarsAndHints(puzzleModel.PrestigePoints, puzzleModel.Hints);
		//update level no. / puzzle pack
		//send update call
		SendData.Instance.UpdatePlayerData();
	}


	public void LoadScreen(PuzzleModel puzzleModel)
    {
		this.puzzleModel = puzzleModel;
		SendUpdateToServer ();
		GameObject levelEndGameObject = ScreenTransitionManager.Instance.ShowScreen (GameConstants.Screens.LEVEL_END_SCREEN);
		levelEndScreenRef = levelEndGameObject.GetComponent<LevelEndScreenReferences> ();
        levelEndScreenRef.Star.text = "+"+ puzzleModel.PrestigePoints.ToString();
	}

	public void SlideBackToMainMenu() {
        puzzleModel.UpdateReward();
        MainMenuController.Instance.ShowMainMenuScreen();
        
    }
    
}
