using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartScreenController : Singleton<LevelStartScreenController> {
    LevelStartScreenReferences levelStartScreenRef;
	PuzzleModel puzzleModel;

	public void ShowScreen(PuzzleModel puzzleModel) {
		this.puzzleModel = puzzleModel;
        GameObject levelStartScreenGameObject = ScreenTransitionManager.Instance.ShowScreen(GameConstants.Screens.LEVEL_START_SCREEN);
		levelStartScreenRef = levelStartScreenGameObject.GetComponent<LevelStartScreenReferences>();
		levelStartScreenRef.clueText.text = puzzleModel.Clue[0];
    }

    public void LoadPuzzle() {
		GamePlayScreenController.Instance.LoadScreen(puzzleModel);
    }
}
